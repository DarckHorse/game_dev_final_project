using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public GameObject blood;
    public GameObject explosion;
    public float time = 1f;
    private int hp = 5;
    public float bulletSpeed = 15f;
    
    



    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            hp -= 1;
            GameObject e = Instantiate(blood) as GameObject;
            e.transform.position = transform.position;
            Destroy(e, 1f);
        }
        if(other.gameObject.tag == "Specialbullet")
        {
            hp -= 2;
            GameObject e = Instantiate(blood) as GameObject;
            e.transform.position = transform.position;
            Destroy(e, 1f);
        }
        
    }


    // Update is called once per frame
    void Update()
    {  
        if (hp <= 0) {
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = transform.position;
            gameObject.SetActive(false);
            Destroy(e, .5f);
        }

    }

    
    private void OnTriggerStay2D(Collider2D other)
    {
        // kill condition
        if (other.gameObject.tag == "Player") {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        } 
    }
}