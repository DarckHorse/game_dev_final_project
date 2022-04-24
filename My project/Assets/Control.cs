using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{

    //Rigidbody m_rb;
    CharacterController m_cc;

    private const float SPEED = 3.0f;
    private const float JUMP_SPEED = 3.0f;
    private const float GRAVITY = -5.0f;

    
    public GameObject m_bullet;
    public Transform m_barrel;
    public Transform firePoint;

    Vector3 user_input;

    public float shootCooldown;

    public void shoot()
    {
        GameObject bullet = Instantiate(m_bullet, firePoint.position, firePoint.rotation);
        bullet.GetComponent<BulletBeh>().Fire(m_barrel, 50.0f);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.up * 50.0f, ForceMode.Impulse);
        Destroy(bullet, 1f);
    }

    // Start is called before the first frame update
    void Start()
    {
        //m_rb = GetComponent<Rigidbody>();
        m_cc = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked; 
    }

    // Update is called once per frame
    void Update()
    {
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
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0));
    }

    void FixedUpdate()
    {
        //m_rb.AddForce(move * ACCEL, ForceMode.Acceleration);
        m_cc.Move(user_input * SPEED * Time.deltaTime);


        if (Input.GetAxis("Fire1") > 0)
        {
            if(shootCooldown <= 0.005f){
                shoot();
                shootCooldown = .1f;}
        }
        shootCooldown = shootCooldown - Time.deltaTime;

        /*if (Input.GetAxis("Fire1") > 0) {
            GameObject bullet = Instantiate(m_bullet, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Bullet>().Fire(m_barrel, 50.0f);
        }*/
    }
}

