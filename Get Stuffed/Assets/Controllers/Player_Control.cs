using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{ 
    public GameObject m_bullet; //bullet prefab
    public Transform m_barrel;  
    public Transform firePoint;
    public float shotCooldown;
    int hitpoints = 50;
    protected Agent _agent;

    //for weapons
    private int weapon = 1;
    private int damage = 1;
    private float range = 1000f;

    //shoots gun
    public void shoot()
    {
        //firePoint is at the end of the gun
        if(weapon == 1)
        {
            RaycastHit hit;
            Debug.DrawRay(firePoint.transform.position, firePoint.transform.up * range, Color.yellow, .05f);
            if(Physics.Raycast(firePoint.transform.position, firePoint.transform.up, out hit, range))
            {
                Debug.Log(hit.transform.name);
                Health health = hit.transform.GetComponent<Health>();
                if(health != null)
                {
                    health.TakeDamage(damage);
                }
            }
        }

        if(weapon == 2)
        {
            GameObject bullet = Instantiate(m_bullet, firePoint.position, firePoint.rotation);
            bullet.transform.Rotate(-90.0f, 0.0f, Random.Range(0.0f, 360.0f), Space.Self);
            Destroy(bullet, 1f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _agent = GetComponent<Agent>();
        InitBehaviors();
    }

    protected virtual void InitBehaviors()
    {
        _agent.AddBehavior("Airborne", new IControlAirborne());
        _agent.AddBehavior("Grounded", new IControlGrounded());
        // Debug.Log("Player Behaviors Added");
        _agent.ActivateBehavior("Airborne");
        // Debug.Log("Player Behaviors Activated");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0));
        if (hitpoints <= 0) {
            _agent.Die();
        }
        
        if(Input.GetKeyDown("1"))
        {
            weapon = 1;
        }
        else if(Input.GetKeyDown("2"))
        {
            weapon = 2;
        }
        else if(Input.GetKeyDown("3"))
        {
            weapon = 3;
        }
    }

    void FixedUpdate()
    {
        if (Input.GetAxis("Fire1") > 0)
        {
            
             if(shotCooldown <= 0.005f){
                 //Debug.Log("Fire");
                 shoot();
                 switch(weapon)
                 {
                    case 1:
                        shotCooldown = .1f;
                        break;
                    case 2:
                        shotCooldown = 1f;
                        break;
                    case 3:
                        shotCooldown = 4f;
                        break;
                 }
                
                 }
        }
         shotCooldown = shotCooldown - Time.deltaTime;

        
        // if(_agent.CC.isGrounded)
        // {
            
        //     if(Input.GetAxis("Jump") > 0)
        //     {
        //         velocity += Vector3.up * jump_speed;
        //     }
        // }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Weapon") {
            if(collider != null)
            {
                //hitpoints -= (int)collider.gameObject.GetComponent<WeaponAgent>().Damage;
            }
            
        }
    }
}

