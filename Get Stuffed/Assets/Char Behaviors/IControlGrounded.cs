using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IControlGrounded : IBehavior
{
    Vector3 velocity = Vector3.zero;
    int forward;
    int backward;
    int right;
    int left;
    int jump;
    private Agent _agent;

    public void Activate(Agent agent)
    {
        // Debug.Log("Control Grounded");
        _agent = agent;
    }

    // Update is called once per frame
    public void Update()
    {
        if (!_agent.CheckGround()) {
            _agent.ActivateBehavior("Airborne");
            return;
        }
        else {
            // modify velocity based on key inputs
            if (Input.GetKey(KeyCode.W)) {
                forward = 1;
                _agent.Velocity += _agent.transform.forward;
            }
            else forward = 0;
            if (Input.GetKey(KeyCode.S)) {
                backward = 1;
                _agent.Velocity -= _agent.transform.forward;
            }
            else backward = 0;
            if (Input.GetKey(KeyCode.D)) {
                right = 1;
                _agent.Velocity += _agent.transform.right;
            }
            else right = 0;
            if (Input.GetKey(KeyCode.A)) {
                left = 1;
                _agent.Velocity -= _agent.transform.right;
            }
            else left = 0;

            // if no input set non vertical velocity to 0
            if (forward + backward + right + left == 0) {
                _agent.Velocity = new Vector3(0, velocity.y, 0);
            }
            
            // add impulse to velocity on jump
            if (Input.GetKey(KeyCode.Space)) {
                jump = 1;
                // Debug.Log("Jump");
                _agent.Velocity += Vector3.up * jump * _agent.Jump_Speed;
            }
            else jump = 0;
            //Debug.Log("jump " + jump);
        }     
    }
}
