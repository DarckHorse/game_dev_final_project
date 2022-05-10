using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class EnemyChase : MonoBehaviour
{
    private NavMeshAgent enemy;
    public GameObject Player;
    public float EnemyDistanceRun = .1f;
    
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);

        if(distance < EnemyDistanceRun)
        {

            enemy.SetDestination(Player.transform.position);
            //Vector3 dirtoPlayer = transform.position - Player.transform.position;
            //Vector3 newPos = transform.position - dirtoPlayer;
            //enemy.SetDestination(newPos);
        }
    }
    
}
