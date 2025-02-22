using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public NavMeshAgent enemy;
    private Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        // References the transform of the player to the variable only once at start
        Player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Enemy sets player's position as its goal and it keeps updating
        enemy.SetDestination(Player.position);
    }
}
