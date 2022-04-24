using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 m_velocity;

    // Start is called before the first frame update
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

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += m_velocity * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        Health hp = other.GetComponent<Health>();
        if(hp != null)
        {
            hp.TakeDamage(10);
        }
    }
}
