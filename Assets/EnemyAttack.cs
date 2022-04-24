using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAttack : MonoBehaviour
{
    //killing
    public GameObject gameOverText, restart, player2, Panel;
    //Animations
    Animator anim;

    //Agent
    public NavMeshAgent agent;

    public float dambing = 6.0f;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //patroling
    public float speed;
    public Transform[] moveSpots;
    private int randomSpot;

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    [SerializeField] float stoppingdistance;
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake() 
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    private void Start() 
    {
        Panel.SetActive (false);
        gameOverText.SetActive (false);
        restart.SetActive (false);
        anim = GetComponent<Animator>();
        agent.autoBraking = false;
        Update();
        randomSpot = Random.Range(0, moveSpots.Length);
    }
    private void Update() 
    {
        float dis = Vector3.Distance(transform.position, player.transform.position);
        if (dis < stoppingdistance)
        {
            AttackPlayer();
        }else
        {
            Pattroling();
        }
        //check for sight and attck range 
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange && !agent.pathPending && agent.remainingDistance < 0.5f) Pattroling ();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer ();
        if (playerInSightRange && playerInAttackRange) AttackPlayer ();
       
    }

    private void Pattroling ()
    {
        anim.SetBool("ISWalking", true);
        anim.SetBool("IsRunning", false);
        
        agent.destination = moveSpots[randomSpot].position;
        randomSpot = (randomSpot + 1) % moveSpots.Length;

        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;

    }

    private void ChasePlayer()
    {
        anim.SetBool("IsRunning", true);
        agent.speed = Random.Range(3f, 5f);
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);
        
        gameObject.GetComponent<NavMeshAgent>().isStopped = true;
        if (!alreadyAttacked)
        {
            //Attack code here
            anim.SetBool("IsAttacking", true);
            alreadyAttacked = true;
        }
        //if (alreadyAttacked)
     //   {
      //      gameOverText.SetActive (true);
       //       restart.SetActive (true);
       //     Panel.SetActive (true);
      //  }
        
    }
}