using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IControlGrounded : IBehavior
{
    Vector3 velocity_norm;
    private Agent _agent;

    public void Activate(Agent agent)
    {
        Debug.Log("Control Grounded");
        _agent = agent;
    }

    // Update is called once per frame
    public void Update()
    {
        if (!_agent.CheckGround()) {
            _agent.ActivateBehavior("Airborne");
            return;
        }
        else {
            velocity_norm = _agent.transform.forward * Input.GetAxis("Vertical") + _agent.transform.right * Input.GetAxis("Horizontal");
            _agent.Velocity += new Vector3(velocity_norm.x, 0, velocity_norm.z) * _agent.Speed;

            if (Input.GetAxis("Jump") > 0)
            {
                _agent.Velocity += Vector3.up * _agent.Jump_Speed;
            }
        }     
    }
}
