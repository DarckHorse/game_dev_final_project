using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAirborne : IBehavior
{
    float gravity = 10;
    private Agent _agent;
    // Start is called before the first frame update
    public void Activate(Agent agent)
    {
        Debug.Log("Airborne");
        _agent = agent;
    }

    // Update is called once per frame
    public void Update()
    {
        if (_agent.CheckGround()) {
            _agent.ActivateBehavior("Grounded");
            return;
        }
        else {
            _agent.velocity += Vector3.down * gravity;
        }
    }
}
