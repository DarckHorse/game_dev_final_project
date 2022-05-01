using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
//------------------------------------------------------------------------------------------
    // Variables

    public GameObject target;
    CharacterController cc;
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
    private List<IBehavior> _currentBehaviors;

    // add named behavior for this entity
    public void AddBehavior(string name, IBehavior behavior)
    {
        _behaviors.Add(name, behavior);
    }

    // activate behavior by name
    public void ActivateBehavior(string name)
    {
        _currentBehaviors.Add(_behaviors[name]);
        _currentBehaviors[_currentBehaviors.Count - 1].Activate(this);
        Debug.Log("Behavior Activated");
    }

//------------------------------------------------------------------------------------------------------
    // Agent Code

    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();
        setCharAtt();
    }



    void FixedUpdate()
    {
        // Debug.Log(_currentBehaviors.Count);
        // for (int i = 0; i < _currentBehaviors.Count; i++) {            
        //     _currentBehaviors[i].Update();
        // }
        CC.Move(velocity);        
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
            speed = 5;
            jump_speed = 1;
            hitpoints = 50;
        }
    }
    public bool CheckGround()
    {
        return cc.isGrounded;
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}

