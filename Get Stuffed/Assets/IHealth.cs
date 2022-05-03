using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IHealth : IBehavior
{
    Agent _agent;
    float hitpoints;

    // Start is called before the first frame update
    public void Activate(Agent agent)
    {
        _agent = agent;
        hitpoints = _agent.Hitpoints;
    }

    // Update is called once per frame
    public void Update()
    {
        if (hitpoints <= 0) {
            _agent.Die();
        }
    }

    void OnTriggerEnter(Collision collision)
    {
        if (collision.collider.GetType() == typeof(CapsuleCollider)) {
            if (collision.collider.tag != "Weapon") {
                hitpoints -= collision.collider.gameObject.GetComponent<WeaponAgent>().Damage;
                collision.collider.gameObject.SetActive(false);
            }
        }
    }
}
