using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPercieve : IBehavior
{
    private Agent _agent;

    public void Activate(Agent agent)
    {
        _agent = agent;
        Debug.Log("Mob percieve start");
    }

    public void Update()
    {

    }

    void OnTriggerEnter(Collision collision)
    {
        Debug.Log("Boom");
        if (collision.collider.GetType() == typeof(SphereCollider)) {
            Debug.Log("chase him");
            if (collision.collider.tag != _agent.transform.tag) {
                _agent.target = collision.collider.gameObject;
                _agent.ActivateBehavior("OnAware");
                Debug.Log("Mob OnAware Activarted");
            }
        }
    }
}
