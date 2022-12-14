using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Control : MonoBehaviour
{
    protected Agent _agent;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<Agent>();
        InitBehaviors();
    }

    protected virtual void InitBehaviors()
    {
        _agent.AddBehavior("Airborne", new IAirborne());
        _agent.AddBehavior("Grounded", new IGrounded());
        _agent.AddBehavior("Percieve", new IPercieve());
        _agent.AddBehavior("OnAware", new IChase());
        // Debug.Log("AI Behaviors Added");
        _agent.ActivateMovementBehavior("Percieve");
        _agent.ActivateBehavior("Airborne");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {

    }
}
