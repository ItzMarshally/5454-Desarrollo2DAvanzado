using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject tutorialPanel;
    public GameObject scorePanel;

    private bool tutorialActive = true;

    void Start()
    {
        if (tutorialPanel != null)
        {
            tutorialPanel.SetActive(true);
            Time.timeScale = 0f;
            tutorialActive = true;
        }

        if (scorePanel != null)
        {
            scorePanel.SetActive(false);
        }
    }

    void Update()
    {
        if (tutorialActive && Input.GetKeyDown(KeyCode.X))
        {
            OcultarTutorial();
        }
    }

    void OcultarTutorial()
    {
        tutorialPanel.SetActive(false);

        if (scorePanel != null)
        {
            scorePanel.SetActive(true);
        }

        Time.timeScale = 1f;          
        tutorialActive = false;
    }
}
