using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            velocity = (_agent.transform.forward * Input.GetAxis("Vertical") + _agent.transform.right * Input.GetAxis("Horizontal")) * _agent.Speed;
            
            if (Input.GetAxis("Jump") > 0)
            {
                velocity += Vector3.up * _agent.Jump_speed;
            }

            _agent.Velocity += velocity;
        }     
    }
}
