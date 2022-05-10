using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBeh : MonoBehaviour
{
    Vector3 m_velocity;
    private float speed = 25f;

    void Start()
    {
        
    }

    void Update()
    {   
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
