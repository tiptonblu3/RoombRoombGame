using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class enemy : MonoBehaviour
{
    [Header("Basic Stats")]
    public float health;
    public float attack;
    public float defense;
    public float speed;

    public NavMeshAgent EnemyMonster;
    public Transform Player;

    [Header("Attack Stuff")]
    public float attackSpeed;

    // Notes:
    /*
    1. Make parent enemy object (probably call it enemy spawner), and have all enemies spawn under it.
    2. Spawner loop (might have to save that for game manager)
    3. function for player taking damage, might have to do that in player
    */


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(EnemyMonster.isOnNavMesh);
        EnemyMonster.stoppingDistance = 0f;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null && EnemyMonster != null)
        {
            EnemyMonster.SetDestination(Player.position);// immediately makes the enemy target the player and march towards them.
        } 
    }
}
