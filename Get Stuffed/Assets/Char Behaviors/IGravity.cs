using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGravity : IBehavior
{
    public float GRAVITY = -9.8f;
    Agent _agent;

    // Start is called before the first frame update
    public void Activate(Agent agent)
    {
        _agent = agent;
    }

    // Update is called once per frame
    public void Update()
    {
        _agent.Velocity += Vector3.up * GRAVITY * Time.deltaTime;
    }
}
