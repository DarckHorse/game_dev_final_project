using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private const float SPEED = 5.0f;
    private const float JUMP_SPEED = 5.0f;
    private const float GRAVITY = -5.0f;
    Vector3 m_velocity;

    Vector3 m_move;
    CharacterController m_cc;
    
    // Start is called before the first frame update
    void Start()
    {
        m_cc = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_cc.isGrounded)
        {
            m_move = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
            m_move = m_move * SPEED;
            
            if (Input.GetAxis("Jump") > 0)
            {
                m_move += Vector3.up * JUMP_SPEED;
            }
        }
        else
        {
            m_move += Vector3.up * GRAVITY * Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        m_cc.Move(m_move * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
    }
}
