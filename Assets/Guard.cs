using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    // scripts used by the Guard (add them all to the entity)
    private Patrol m_patrol;
    private Chase m_chase;
    private Leash m_leash;

    // components that we rely on
    private Awareness m_aware;

    // parameters
    private float LEASH_DISTANCE = 30.0f;    

    void Awake()
    {
        m_patrol = GetComponent<Patrol>();
        m_chase = GetComponent<Chase>();
        m_leash = GetComponent<Leash>();
        m_aware = GetComponent<Awareness>();
    }

    void Start()
    {
        // just to be sure
        m_chase.enabled = false;
        m_leash.enabled = false;

        // start with patrol, subscribe to "become aware" transition
        m_patrol.enabled = true;
        m_aware.onAware += OnPatrolAware;
    }

    void OnPatrolAware(Transform target)
    {
        // currently we only start chasing from patrol, but this could support awareness coming in
        //  during other states
        // we might need to check here which state we're in like we do in Update

        // transition patrol -> chase
        if (target.gameObject.name == "Player") {
            m_patrol.enabled = false;
            m_aware.onAware += OnPatrolAware;

            m_chase.Target = target;
            m_chase.enabled = true;
        }
    }

    void OnLeashComplete()
    {
        // leash is done, back to patrol
        m_leash.enabled = false;
        m_leash.OnComplete -= OnLeashComplete;

        m_patrol.enabled = true;
        m_aware.onAware += OnPatrolAware;
    }

    void Update()
    {
        // state machine
        if (m_chase.enabled) {
            // while chasing, leash based on distance
            //  this isn't an event handler b/c we don't have an event coming from another component like awareness
            //  instead, we're polling here looking for the transition
            if (Vector3.Distance(transform.position, m_chase.Target.position) > LEASH_DISTANCE) {
                m_chase.enabled = false;
                m_chase.Target = null;

                m_leash.enabled = true;
                m_leash.OnComplete += OnLeashComplete;
            }
        }
        
        // we don't have polling needs for patrol or leash, but those would be additional else branches here

    }
}