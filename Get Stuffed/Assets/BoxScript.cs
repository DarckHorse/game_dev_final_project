using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{

    Renderer m_Renderer;

    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = GetComponent<Renderer> ();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            m_Renderer.material.SetColor("_Color", Color.red);
            //Debug.Log("hit by bullet");
        }

        if(other.gameObject.tag == "Player")
        {
            m_Renderer.material.SetColor("_Color", Color.blue);
            //Debug.Log("hit by player");
        }
    }
}
