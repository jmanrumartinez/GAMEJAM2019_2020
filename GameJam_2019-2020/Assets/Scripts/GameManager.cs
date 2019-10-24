using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;

    [Header("Enemy Spawners")]
    public EnemySpawner[] enemySpawners;

    public int maxEnemies = 10;
    public int enemiesSpawned = 0;

    private float timeTranscurredGeneratingEnemies = 0;
    private float timeToGenerateEnemies = 0;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else if (instance != null) {
            Destroy(gameObject);
        }
    }

    private void Start() {
        for (int i = 0; i < 4; i++) {
            int selectedInitialSpawner = (int)Mathf.Floor(Random.Range(0.0f, 4.0f));
            enemySpawners[selectedInitialSpawner].GenerateEnemy();
            enemiesSpawned++;
        }
    }

    private void Update() {
        timeToGenerateEnemies += Time.deltaTime;

        if (timeToGenerateEnemies >= 0.5f) {
            if (enemiesSpawned < maxEnemies) {
                GenerateEnemies();
            }
            timeToGenerateEnemies = 0;
        }
    }

    public void DecreaseSpanwedEnemies() {
        enemiesSpawned--;
    }

    public void GenerateEnemies() {
        int selectedSpawner = (int)Mathf.Floor(Random.Range(0.0f, 4.0f));
        float timeToSpawn = Random.Range(0.0f, 1.5f);
        timeTranscurredGeneratingEnemies += Time.deltaTime;

        if (timeTranscurredGeneratingEnemies >= timeToSpawn) {
            enemySpawners[selectedSpawner].GenerateEnemy();
            enemiesSpawned++; 
        }
    }
}

