using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class Leash : MonoBehaviour
{
    public float SPEED_BOOST = 3.0f;

    private Vector3 m_home;

    public delegate void onComplete();
    public onComplete OnComplete;

    UnityEngine.AI.NavMeshAgent m_agent;
    
    void Awake()
    {
        Debug.Log("leash awake");
        m_agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        // record m_home location
        m_home = transform.position;
    }

    void OnEnable()
    {
        m_agent.SetDestination(m_home);

        // this is a bit hacky, assumes a very simple model of how speed might be modified
        // should have a movement component that keeps a stack of speed mods and calculates how they work together
        // then we can add/remove our boost without concern for what other mods are in play
        // (all buff/debuff systems have this issue)
        m_agent.speed *= SPEED_BOOST;
    }

    void Update()
    {
        if (Vector3.Distance(m_home, transform.position) < 1.0f)
        {
            // done, if anyone cares
            m_agent.speed /= SPEED_BOOST;
            // the delegate allows this script to not depend on the controlling script (e.g. Guard)
            OnComplete();
        }
    }
}
