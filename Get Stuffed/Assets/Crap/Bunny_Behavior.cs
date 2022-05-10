using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny_Behavior : MonoBehaviour
{
    public delegate void OnTakeDamage(int amt);
    public OnTakeDamage onTakeDamage;
    public delegate void OnDeath();
    public OnDeath onDeath;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 50;
    }

    // Update is called once per frame
    public void TakeDamage(int amt)
    {
        health -=amt;
        if(onTakeDamage != null)
        {
            onTakeDamage(amt);
        }

        if(health <= 0)
        {
            if(onDeath != null)
            {
                onDeath();
            }
            Destroy(gameObject);
        }       
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            health -=10;
            Debug.Log("you took damage");
        }
    }

    public void OnAware(GameObject other)
    {

    }
}
