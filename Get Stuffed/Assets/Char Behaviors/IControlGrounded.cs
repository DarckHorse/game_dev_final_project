using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IControlGrounded : IBehavior
{
    Vector3 velocity = Vector3.zero;
    private Agent _agent;

    public void Activate(Agent agent)
    {
        Debug.Log("Control Grounded");
        _agent = agent;
        // _agent.velocity = new Vector3(_agent.velocity.x, 0, _agent.velocity.z);
    }

    // Update is called once per frame
    public void Update()
    {
        if (!_agent.CheckGround()) {
            _agent.ActivateBehavior("Airborne");
            return;
        }
        else {
            // Debug.Log("access velocity?");
            // Debug.Log(Input.GetAxis("Vertical"));
            velocity = (_agent.transform.forward * Input.GetAxis("Vertical") + _agent.transform.right * Input.GetAxis("Horizontal")) * _agent.Speed;
            
            if (Input.GetAxis("Jump") > 0)
            {
                // Debug.Log("Jump?");
                velocity += Vector3.up * _agent.Jump_speed;
            }

            velocity = new Vector3(Math.Clamp(velocity.x, -1 * _agent.Speed, _agent.Speed), velocity.y, Math.Clamp(velocity.z, -1 * _agent.Speed, _agent.Speed));
            // Debug.Log(velocity);

            _agent.CC.Move(velocity * Time.deltaTime);
        }     
    }
}
