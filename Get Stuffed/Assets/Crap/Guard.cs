using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    // scripts used by the Guard (add them all to the entity)
    private Patrol m_patrol;
    private IChase m_chase;
    private Leash m_leash;

    // components that we rely on
    private IPercieve m_aware;

    // parameters
    private float LEASH_DISTANCE = 30.0f;    

    void Awake()
    {

    }

    void Start()
    {

    }

    void OnPatrolAware(Transform target)
    {

    }

    void OnLeashComplete()
    {

    }

    void Update()
    {

    }
}
