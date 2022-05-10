using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IChase : IBehavior
{
    public GameObject target;
    Vector3 velocity_norm;
    Agent _agent;

    public void Activate(Agent agent)
    {        
        _agent = agent;
        Debug.Log("Mob chase start");
        target = _agent.target;
    }

    // Update is called once per frame
    public void Update()
    {
        velocity_norm = (target.transform.position - _agent.transform.position).normalized;
        _agent.Velocity += new Vector3(velocity_norm.x, 0, velocity_norm.z) * _agent.Speed;    
    }

    void FixedUpdate()
    {

    }

    void OnTriggerLeave(Collision collision)
    {
        if (collision.collider.GetType() == typeof(SphereCollider)) {
            if (collision.collider.gameObject != target) {
                _agent.ActivateBehavior("IPercieve");                
                Debug.Log(" Mob Percieve Activated");
            }
        }
    }
    
}
