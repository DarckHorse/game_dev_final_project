using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBeh : MonoBehaviour
{
    Vector3 m_velocity;

    private Vector3 GRAVITY = new Vector3(0, -10.0f, 0);

    //this script doesnt really do anything

    void Start()
    {
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
        //m_velocity += GRAVITY * Time.deltaTime;
        //Debug.Log(transform.position);
    }
}