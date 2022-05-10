using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class RunAway : MonoBehaviour
{

    UnityEngine.AI.NavMeshAgent m_agent;
    public Transform m_target;
    public float speed = 6f;
        

    bool toggle = false;

    void Awake()
    {
        Debug.Log("run away awake");
        m_agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (toggle)
        {
            //m_agent.transform.position =  m_target.position + new Vector3(180f,0,0) * Time.deltaTime;
            m_agent.transform.position = Vector3.MoveTowards(m_agent.transform.position, m_target.position, -1 * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            toggle = true;
            Debug.Log("grazed by bullet");
        }
    }
}
