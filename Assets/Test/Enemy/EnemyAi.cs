﻿using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float forceup;
    public float forceforward;

    public Transform Attackpoint;
    
    public float health;

    public AudioManager AudioManager;

    public GameObject self;
    public Transform startpoint;
    public TextMeshPro TextMeshPro;
    
    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
        
    void Start () {
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        self.transform.position = startpoint.position;
       
    }
    private void Awake()
    {
        AudioManager = FindObjectOfType<AudioManager>();
        player = GameObject.Find("Camera Offset").transform;
        agent = GetComponent<NavMeshAgent>();
        alreadyAttacked = false;
    }

    private void Update()
    {
        TextMeshPro.text = "Health: " + (health);
        
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        
        if(agent.velocity.magnitude < 0.1f && !playerInAttackRange && !playerInAttackRange) SearchWalkPoint();

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        
        transform.LookAt(player, Vector3.up);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x*0, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z*0);
    }

    private void AttackPlayer()
    {
                    
        //Make sure enemy doesn't move
        agent.SetDestination(this.agent.transform.position);

        agent.acceleration = 0f;

        transform.LookAt(player, Vector3.up);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x*0, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z*0);
       
        
        if (!alreadyAttacked)
        {
            AudioManager.Play("Gun Fire");
            
           ///Attack code here
            Rigidbody rb = Instantiate(projectile, Attackpoint.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * forceforward, ForceMode.Impulse);
            rb.AddForce(transform.up * forceup, ForceMode.Impulse);
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        AudioManager.Play("EnemyDie");
        walkPoint = startpoint.position;
        agent.acceleration = 0f;
        self.transform.position = startpoint.position;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}