using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGrounded : IBehavior
{
    private Agent _agent;

    public void Activate(Agent agent)
    {
        Debug.Log("Mob Grounded start");
        _agent = agent;
    }

    // Update is called once per frame
    public void Update()
    {
        if (!_agent.CheckGround()) {
            _agent.ActivateBehavior("Airborne");
            return;
        }        
    }
}
