using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float hp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0) {
            Die();
        }
    }

    void OnTriggerEnter(Collider collider) 
    {
        if (collider.gameObject.tag == "Weapon") {
            hp -= collider.gameObject.GetComponent<WeaponAgent>().Damage;
        }
    }
}
