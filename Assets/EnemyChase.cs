using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyChase : MonoBehaviour
{
    private NavMeshAgent enemy;
    public GameObject Player;
    public float EnemyDistanceRun = 7.0f;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);

        if(distance < EnemyDistanceRun)
        {
            Vector3 dirtoPlayer = transform.position - Player.transform.position;
            Vector3 newPos = transform.position - dirtoPlayer;
            enemy.SetDestination(newPos);
        }
    }
}
