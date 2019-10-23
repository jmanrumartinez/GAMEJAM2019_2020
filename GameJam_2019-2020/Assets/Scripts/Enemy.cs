using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class Enemy : MonoBehaviour
{

    [Header("Enemy")]
    private int health;
    private int damage; 
    private Vector3 position;
    public NavMeshAgent agent;

    [Header("Player")]
    public GameObject player;
    private Vector3 posPlayer;

    private void Update() {
        posPlayer = player.transform.position;
        agent.SetDestination(posPlayer); 
    }
}
