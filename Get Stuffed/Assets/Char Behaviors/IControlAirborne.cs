using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IControlAirborne : IBehavior
{    
    Vector3 velocity = Vector3.zero;
    float gravity = -.5f;
    private Agent _agent;
    // Start is called before the first frame update
    public void Activate(Agent agent)
    {
        Debug.Log("Control Airborne");
        _agent = agent;
    }

    // Update is called once per frame
    public void Update()
    {
        if (_agent.CheckGround()) {
            // Debug.Log("Grounded");
            _agent.ActivateBehavior("Grounded");
            return;
        }
        else {
            velocity += Vector3.up * gravity * Time.deltaTime;
            _agent.Velocity = velocity;
        }
    }
}
