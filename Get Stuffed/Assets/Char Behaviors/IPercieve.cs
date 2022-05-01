using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPercieve : IBehavior
{
    private Agent _agent;

    public void Activate(Agent agent)
    {
        _agent = agent;
    }

    public void Update()
    {

    }

    void OnTriggerStay(Collision collision)
    {
        if (collision.collider.GetType() == typeof(SphereCollider)) {
            if (collision.collider.tag != _agent.transform.tag) {
                _agent.target = collision.collider.gameObject;
                _agent.ActivateBehavior("OnAware");
            }
        }
    }
}
