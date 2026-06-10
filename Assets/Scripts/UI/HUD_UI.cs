using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD_UI : MonoBehaviour
{
    public GameObject tutorialPanel;
    public GameObject scorePanel;
    public GameObject gameOverPanel;
    public GameObject victoryPanel;

    public GameObject objectiveMessage;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OcultarTutorialUI()
    {
        if (tutorialPanel != null) tutorialPanel.SetActive(false);
        if (scorePanel != null) scorePanel.SetActive(true);
    }

    public void ShowGameOverUI()
    {
        if (gameOverPanel != null) gameOverPanel.SetActive(true);
    }

    public void ShowVictoryUI()
    {
        if (victoryPanel != null) victoryPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
