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
    public float health = 100.0f;
    public float damage = 1.0f;
    public float movementSpeed = 5.0f;
    public int score = 50;
    public Animator animator;
    public GameObject explosion;
    public GameObject enemyMesh;

    [Header("Player")]
    public GameObject player; 
    public Transform playerTransform;

    [Header("GameManager")]
    public GameManager gameManager;

    private void Start() {
        player = GameObject.FindWithTag("Player");
        playerTransform = player.transform;
        ChangeState(State.PATROLING);
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Update() {
        Behaviour(state);
    }

    public void Kill() {
        Destroy(this.gameObject); 
    }

    public int GetScore() {
        return score; 
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
                Instantiate(explosion, transform.position, transform.rotation);
                gameManager.DecreaseSpanwedEnemies();
                Destroy(this.gameObject); 
                break;
            default:
                Debug.Log("State not defined");
                break; 
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            ChangeState(State.EXPLODING);
        }
    }
}
