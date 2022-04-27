using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class Chase : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent m_agent;
    private Transform m_target;
    public Transform Target {
        get { return m_target; }
        set { m_target = value; }
    }

    void Awake()
    {
        Debug.Log("chase awake");
        m_agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void OnEnable()
    {
        Debug.Log("chase onenable");
    }

    void Start()
    {
        Debug.Log("chase start");
    }

    // Update is called once per frame
    void Update()
    {
        if (m_target) {
            m_agent.SetDestination(m_target.position);
        }        
    }

    
}
