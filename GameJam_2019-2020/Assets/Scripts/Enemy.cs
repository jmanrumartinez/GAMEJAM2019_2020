using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum State {
    PATROLING, 
    ATTACKING, 
}

public class Enemy : MonoBehaviour
{
    [Header("Enemy")]
    private State state;
    private float health = 100.0f;
    private int damage;
    private float movementSpeed = 5.0f; 
    private float distanceBetweenEnemyPlayer;
    private RaycastHit2D hit; 

    public float distanceToAttack = 50.0f;

    [Header("Player")]
    public GameObject player; 
    public Transform playerTransform; 

    private void Start() {
        ChangeState(State.PATROLING);         
    }

    private void Update() {
        Debug.DrawRay(transform.position, playerTransform.position, Color.red);
        Behaviour(state);
    }

    public void RecieveDamage(float damage) {
        health -= damage; 
    }

    private void ChangeState(State newState) {
        state = newState;
        Debug.Log("Changed to: " + newState);
    }

    private void MoveToPlayer() {
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, Time.deltaTime * movementSpeed);
        transform.LookAt(playerTransform);
    }

    private void Behaviour(State state) {
        switch (state) {
            case State.PATROLING:
                MoveToPlayer();
                break;
            case State.ATTACKING:
                // TODO: Cuando el jugador entre en el radio de poder atacar, atacará al enemigo
                break;
            default:
                Debug.Log("Not defined");
                break; 
        }
    }

    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.tag == "Player") {
            ChangeState(State.ATTACKING); 
        }
    }
}
