using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{ 
    public GameObject m_bullet; //bullet prefab
    public Transform m_barrel;  
    public Transform firePoint;
    public float shotCooldown;
    protected Agent _agent;

    // //shoots gun
    // public void shoot()
    // {
    //     //firePoint is at the end of the gun
    //     GameObject bullet = Instantiate(m_bullet, firePoint.position, firePoint.rotation);
    //     Rigidbody rb = bullet.GetComponent<Rigidbody>();
    //     rb.AddForce(firePoint.up * 25.0f, ForceMode.Impulse);
    //     Destroy(bullet, 1f);
    // }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _agent = GetComponent<Agent>();
        InitBehaviors();
    }

    protected virtual void InitBehaviors()
    {
        _agent.AddBehavior("Airborne", new IAirborne());
        _agent.AddBehavior("Grounded", new IGrounded());
        _agent.AddBehavior("Health", new IHealth());
        Debug.Log("Player Behaviors Added");
        _agent.ActivateBehavior("Airborne");
        _agent.ActivateBehavior("Health");
        Debug.Log("Player Behaviors Activated");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0));
    }

    void FixedUpdate()
    {
        if (Input.GetAxis("Fire1") > 0)
        {
            Debug.Log("Fire");
        //     if(shotCooldown <= 0.005f){
        //         shoot();
        //         shotCooldown = .30f;}
        }
        // shotCooldown = shotCooldown - Time.deltaTime;

        
        // if(_agent.CC.isGrounded)
        // {
            
        //     if(Input.GetAxis("Jump") > 0)
        //     {
        //         velocity += Vector3.up * jump_speed;
        //     }
        // }
    }
}

