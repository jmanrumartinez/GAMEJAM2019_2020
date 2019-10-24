using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject deathMenu;

    public Image bgSlider;
    public Image playerHealth;
    public Slider slider;
    public Slider cooldownSlider;
    public GameObject cdSLider;

    public Text scoreText;
    public Text deathScoreText;

    public int score;
    public int PlayerStartingHealth;
    public int currentPlayerHealth;
    public int DamageDealt;
    private bool cooldown;
    public float timer;
    public float ready;

    public static bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        SetupSlider(PlayerStartingHealth);
        currentPlayerHealth = PlayerStartingHealth;
        isPaused = false;
        cooldown = false;
        timer = 0;
        ready = 1;
    }

    // Update is called once per frame
    void Update()
    {
        SetScore(score);
        UpdateSlider(currentPlayerHealth);
        UpdateCooldownSlider();

        if (Input.GetKeyDown(KeyCode.Alpha1))
            RecieveDamage(DamageDealt);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            EnemyKilled(20);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            cooldown = true;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMenu.activeInHierarchy)
                PauseGame();
            else if (pauseMenu.activeInHierarchy)
                ContinueGame();
        }

 
        if (currentPlayerHealth <= 0)
            SetDeathScore();

    }

    #region GameUI

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
        isPaused = true;
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public bool IsPaused()
    {
        return isPaused;
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }

    public void SetDeathScore()
    {
        deathMenu.SetActive(true);
        deathScoreText.text = score.ToString("00000");
    }

    public void UpdateCooldownSlider()
    {
        if (cooldown)
        {
            cdSLider.SetActive(true);
            cooldownSlider.value = timer;
            timer += Time.deltaTime;
            if (timer >= ready)
            {
                cooldown = false;
                cdSLider.SetActive(false);
                timer = 0;
            }
        }
    }

    #endregion

    #region MainMenuUI

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    #endregion

}
