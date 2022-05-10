using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class Patrol : MonoBehaviour
{
    public Transform[] m_waypoints = new Transform[2];
    UnityEngine.AI.NavMeshAgent m_agent;
    int nextWaypoint = 0;

    void Awake()
    {
        Debug.Log("patrol awake");
    }

    void Start()
    {
        Debug.Log("patrol start");
        m_agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        m_agent.SetDestination(m_waypoints[nextWaypoint].position);
    }

    void OnEnable()
    {
        Debug.Log("patrol onenable");
    }

    // Update is called once per frame
    void Update()
    {
        if (m_agent.remainingDistance < 0.001f) {
            nextWaypoint = (nextWaypoint + 1) % m_waypoints.Length;
            m_agent.SetDestination(m_waypoints[nextWaypoint].position);
        }
    }

}
