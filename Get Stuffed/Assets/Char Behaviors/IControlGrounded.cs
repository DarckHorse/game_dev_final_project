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
    }

    // Update is called once per frame
    public void Update()
    {
        if (!_agent.CheckGround()) {
            _agent.ActivateBehavior("Airborne");
            return;
        }
        else {
            {
                _agent.velocity = _agent.transform.forward * Input.GetAxis("Vertical") + _agent.transform.right * Input.GetAxis("Horizontal");
                _agent.velocity = _agent.velocity * _agent.Speed;
                
                if (Input.GetAxis("Jump") > 0)
                {
                    _agent.velocity += Vector3.up * _agent.Jump_speed;
                }
            }
        }     
    }
}
