using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class Agent : MonoBehaviour
{
//------------------------------------------------------------------------------------------
    // Variables

    public GameObject target;
    public GameObject level;
    CharacterController cc;
    MeshRenderer mesh_rend;

    public CharacterController CC
    {
        get { return cc; }
    }
    float speed;
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    float jump_speed;
    public float Jump_Speed
    {
        get { return jump_speed; }
        set { jump_speed = value; }
    }
    float hitpoints;
    public float Hitpoints
    {
        get { return hitpoints; }
        set { hitpoints = value; }
    }
    public Vector3 velocity = Vector3.zero;
    public Vector3 Velocity
    {
        get { return velocity; }
        set { velocity = value; }
    }

//-------------------------------------------------------------------------------------------------------
    // behavior system

    private Dictionary<string, IBehavior> _behaviors = new Dictionary<string, IBehavior>();
    private IBehavior _currentBehavior;
    private IBehavior _movementBehavior;

    // add named behavior for this entity
    public void AddBehavior(string name, IBehavior behavior)
    {
        _behaviors.Add(name, behavior);
    }

    // activate behavior by name
    public void ActivateBehavior(string name)
    {
        _currentBehavior = _behaviors[name];
        _currentBehavior.Activate(this);
        // Debug.Log(name + " Behavior Activated");
    }

    // activate behavior by name
    public void ActivateMovementBehavior(string name)
    {
        _movementBehavior = _behaviors[name];
        _movementBehavior.Activate(this);
        // Debug.Log(name + "  Behavior Activated");
    }

//------------------------------------------------------------------------------------------------------
    // Agent Code

    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();
        mesh_rend = gameObject.GetComponent<MeshRenderer>();
        setCharAtt();
    }



    void FixedUpdate()
    {
        // Debug.Log(_currentBehaviors.Count);
        // for (int i = 0; i < _currentBehaviors.Count; i++) {            
        //     _currentBehaviors[i].Update();
        // }
        if (_currentBehavior != null) {
        _currentBehavior.Update();
        }
        if (_movementBehavior != null) {
        _movementBehavior.Update();
        }
        
        // cap !vertical velocity at speed

        // Debug.Log(velocity);
        CC.Move(new Vector3(Math.Clamp(velocity.x, -1 * speed, speed), velocity.y, Math.Clamp(velocity.z, -1 * speed, speed)));
        
        //if(transform.position.y <= -100)
        //{
        //    Die();
        //}
    }

    private void OnTriggerStay(Collider other)
    {

    }

//---------------------------------------------------------------------------------------------------------------
    // Helper Functions

    void setCharAtt()
    {
        if (gameObject.tag == "Bunny") {
            speed = 3;
            jump_speed = 2;
            hitpoints = 3;
        }
        else if (gameObject.tag == "Player") {
            speed = .5f;
            jump_speed = 5;
            hitpoints = 50;
        }
    }
    public bool CheckGround()
    {
        return cc.isGrounded;
    }

    public void Die()
    {
        
        level.GetComponent<GenerateEnemies>().Dec();
        
        Destroy(gameObject);
        
    }
}

