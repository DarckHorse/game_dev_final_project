using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 m_velocity;

    private Vector3 GRAVITY = new Vector3(0, -10.0f, 0);

    void Start()
    {
        GetComponent<Renderer>().enabled = false;
        m_velocity = Vector3.zero;
    }

    public void Fire(Transform start, float speed)
    {
        transform.position = start.position;
        m_velocity = start.forward * speed;
        GetComponent<Renderer>().enabled = true;
    }

    void FixedUpdate()
    {
        transform.position += m_velocity *  Time.deltaTime;  
        m_velocity += GRAVITY * Time.deltaTime;
        //Debug.Log(transform.position);
    }

    /*public void OnTriggerEnter(Collider other)
    {
        Health hp = other.GetComponent<Health>();
        if (hp) {
            hp.TakeDamage(10);
        }
    }*/
}
