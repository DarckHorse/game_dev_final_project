using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float hp = 1;
    protected Agent _agent;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<Agent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0) {
            _agent.Die();
        }
    }

    void OnTriggerEnter(Collider collider) 
    {
        if (collider.gameObject.tag == "Weapon") {
            //hp -= collider.gameObject.GetComponent<WeaponAgent>().Damage;
            TakeDamage(1.5f);
        }
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            _agent.Die();
        }
    }



    
}