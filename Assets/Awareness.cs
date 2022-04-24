using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Awareness : MonoBehaviour
{
    public delegate void OnAware(Transform target);
    public OnAware onAware;

    private Transform m_target;
    public Transform Target
    {
        get { return m_target; }
        set { m_target = value; }
    }

    void OnTriggerEnter(Collider collider)
    {
        m_target = collider.transform;
        if (onAware != null) {
            onAware(m_target);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (m_target == collider.transform) {
            m_target = null;
        }
    }
}