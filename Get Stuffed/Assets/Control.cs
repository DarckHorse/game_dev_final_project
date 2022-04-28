using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    CharacterController m_cc;

    private const float SPEED = 2.0f;
    private const float JUMP_SPEED = 2.0f;
    private const float GRAVITY = -5.0f;

    
    public GameObject m_bullet; //bullet prefab
    public Transform m_barrel;  
    public Transform firePoint;

    Vector3 user_input;

    public float shootCooldown;

    //shoots gun
    public void shoot()
    {
        //firePoint is at the end of the gun
        GameObject bullet = Instantiate(m_bullet, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.up * 25.0f, ForceMode.Impulse);
        Destroy(bullet, 1f);
    }

    // Start is called before the first frame update
    void Start()
    {
        m_cc = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0));
    }

    void FixedUpdate()
    {
        m_cc.Move(user_input * SPEED * Time.deltaTime);

        if (Input.GetAxis("Fire1") > 0)
        {
            if(shootCooldown <= 0.005f){
                shoot();
                shootCooldown = .30f;}
        }
        shootCooldown = shootCooldown - Time.deltaTime;

        
        if(m_cc.isGrounded)
        {
            user_input = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
            user_input = user_input * SPEED;
            
            if(Input.GetAxis("Jump") > 0)
            {
                user_input += Vector3.up * JUMP_SPEED;
            }
        }
        else
        {
        user_input += Vector3.up * GRAVITY * Time.deltaTime;
        }
        

    }
}

