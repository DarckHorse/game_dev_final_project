using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAgent : MonoBehaviour
{
    CharacterController cc;
    public GameObject target;
    public float projectile_speed;
    public int hitpoints;
    
    public CharacterController CC
    {
        get { return cc; }
    }

    float damage;
    public float Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    // behavior system
    private Dictionary<string, WBehavior> _behaviors = new Dictionary<string, WBehavior>();
    private List<WBehavior> _currentBehaviors;


    void Start()
    {
        setCharAtt();
    }

    // add named behavior for this entity
    public void AddBehavior(string name, WBehavior behavior)
    {
        _behaviors.Add(name, behavior);
    }

    // activate behavior by name
    public void ActivateBehavior(string name)
    {
        _currentBehaviors.Add(_behaviors[name]);
        _currentBehaviors[_currentBehaviors.Count - 1].Activate(this);
    }

    void FixedUpdate()
    {
        for (int i = 0; i < _currentBehaviors.Count; i++) {            
        _currentBehaviors[i].Update();
        }        
    }

    void setCharAtt()
    {
        if (gameObject.tag == "Water Gun") {
            projectile_speed = 1;
            damage = 1;
        }
    }
}
