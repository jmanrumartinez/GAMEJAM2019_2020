using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject pauseMenu;

    public Image bgSlider;
    public Image playerHealth;
    public Slider slider;

    public Text scoreText;

    public int score;
    public int PlayerStartingHealth;
    public int currentPlayerHealth;
    public int DamageDealt;

    // Start is called before the first frame update
    void Start()
    {
        SetupSlider(PlayerStartingHealth);
        currentPlayerHealth = PlayerStartingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        SetScore(score);
        UpdateSlider(currentPlayerHealth);

        if (Input.GetKeyDown(KeyCode.Alpha1))
            RecieveDamage(DamageDealt);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            EnemyKilled(20);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMenu.activeInHierarchy)
                PauseGame();
            else if (pauseMenu.activeInHierarchy)
                ContinueGame();
        }
    }

    public void SetScore(int enemyScore)
    {
        scoreText.text = enemyScore.ToString("00000");
    }

    public void SetupSlider(int playerHealth)
    {
        slider.minValue = 0;
        slider.maxValue = playerHealth;
        slider.value = playerHealth;
    }

    public void UpdateSlider(int currentHealth)
    {
        slider.value = currentHealth;
        if (currentHealth == 3)
            playerHealth.color = Color.green;
        if (currentHealth == 2)
            playerHealth.color = Color.yellow;
        if (currentHealth == 1)
            playerHealth.color = Color.red;
    }

    public int RecieveDamage(int damage)
    {
        currentPlayerHealth -= damage;
        return currentPlayerHealth;
    }

    public void EnemyKilled(int enemyPoints)
    {
        score += enemyPoints;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

}
