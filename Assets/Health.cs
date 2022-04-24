using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int m_health;
    public delegate void OnTakeDamage(int amt);
    public OnTakeDamage onTakeDamage;
    public delegate void OnDeath();
    public OnDeath onDeath;
    // Start is called before the first frame update
    void Start()
    {
        m_health = 50;
    }

    // Update is called once per frame
    public void TakeDamage(int amt)
    {
        m_health -= amt;
        if(onTakeDamage != null)
        {
            onTakeDamage(amt);
        }

        if(m_health <=0)
        {
            if(onDeath != null)
            {
                onDeath();
            }
            Destroy(gameObject);
        }
    }
}
