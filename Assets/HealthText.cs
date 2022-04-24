using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    private float m_timer;
    private float LIFESPAN = 3.0f;
    private float SPEED = 5.0f;
    private Vector3 m_startPos;
    private Renderer m_renderer;
    // Start is called before the first frame update
    void Start()
    {

        transform.parent.GetComponent<Health>().onTakeDamage += ShowDamage;
        m_renderer = GetComponentInChildren<Renderer>();
        m_renderer.enabled = false;
        m_startPos = transform.localPosition;


    }

    void ShowDamage(int amt)
    {
        m_timer = LIFESPAN;
        transform.localPosition = m_startPos;
        GetComponentInChildren<TMPro.TextMeshPro>().text = amt.ToString();
        m_renderer.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform);

        if(m_timer > 0)
        {
            m_timer -= Time.deltaTime;
            transform.position += Vector3.up * SPEED * Time.deltaTime;
        }
        else
        {
            m_renderer.enabled = false;
        }
    }
}
