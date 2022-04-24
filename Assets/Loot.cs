using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    private float ROT_SPEED = 150.0f;
    private float SPEED = 20.0f;
    private Transform m_target;
    // Start is called before the first frame update
    void Start()
    {
        //transform.parent.GetComponent<Health>().onDeath += Drop;
    }

    void Drop()
    {
        GetComponent<Renderer>().enabled = true;
        transform.localPosition = Vector3.zero;
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * ROT_SPEED * Time.deltaTime, Space.World);
        if(m_target)
        {
            transform.position = Vector3.MoveTowards(transform.position, m_target.position, SPEED * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            m_target = other.transform;
        }
    }
}
