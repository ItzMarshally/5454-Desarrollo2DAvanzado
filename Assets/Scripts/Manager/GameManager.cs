using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool tutorialActive = true;
    private HUD_UI hudUI;

    public float scoreToWin = 15f;
    private ScoreSystem scoreSystem;
    private bool gameEnded = false;
    void Start()
    {
        hudUI = GetComponent<HUD_UI>();
        scoreSystem = FindObjectOfType<ScoreSystem>();

        if (hudUI.tutorialPanel != null)
        {
            hudUI.tutorialPanel.SetActive(true);
            Time.timeScale = 0f;
            tutorialActive = true;
        }

        if (hudUI.scorePanel != null)
        {
            hudUI.scorePanel.SetActive(false);
        }

        if (hudUI.gameOverPanel != null)
        {
            hudUI.gameOverPanel.SetActive(false);
        }

        if (hudUI.victoryPanel != null)
        {
            hudUI.victoryPanel.SetActive(false);
        }

        if (hudUI.objectiveMessage != null)
        {
            hudUI.objectiveMessage.SetActive(false);
        }
    }

    void Update()
    {
        if (tutorialActive && Input.GetKeyDown(KeyCode.X))
        {
            OcultarTutorial();
        }

        if (!gameEnded && scoreSystem != null && scoreSystem.score >= scoreToWin)
        {
            WinGame();
        }
    }

    void OcultarTutorial()
    {
        hudUI.OcultarTutorialUI();

        Time.timeScale = 1f;        
        tutorialActive = false;

        if (hudUI.objectiveMessage != null)
        {
            hudUI.objectiveMessage.SetActive(true);
            StartCoroutine(HideObjectiveMessage(4f));
        }
    }

    IEnumerator HideObjectiveMessage(float delay)
    {
        yield return new WaitForSeconds(delay);
        hudUI.objectiveMessage.SetActive(false);
    }

    public void GameOver()
    {
        if (gameEnded) return;

        hudUI.ShowGameOverUI();
        Time.timeScale = 0f;
        gameEnded = true;
    }

    void WinGame()
    {
        gameEnded = true;
        hudUI.ShowVictoryUI();
        StartCoroutine(ReturnToMenuAfterDelay(3f));
    }

    IEnumerator ReturnToMenuAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
