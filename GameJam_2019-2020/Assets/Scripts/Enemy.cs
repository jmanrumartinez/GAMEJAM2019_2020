using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum State {
    PATROLING, 
    EXPLODING, 
}

public class Enemy : MonoBehaviour
{
    [Header("Enemy")]
    private State state;
    private float health = 100.0f;
    private float damage = 50.0f;
    private float movementSpeed = 5.0f; 

    [Header("Player")]
    public GameObject player; 
    public Transform playerTransform; 

    private void Start() {
        ChangeState(State.PATROLING);         
    }

    private void Update() {
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
            case State.EXPLODING:
                // 1. Decrease player health
                // 2. Play explode animation
                // 3. Destroy GameObject (byself)
                break;
            default:
                Debug.Log("State not defined");
                break; 
        }
    }

    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.tag == "Player") {
            ChangeState(State.EXPLODING); 
        }
    }
}
