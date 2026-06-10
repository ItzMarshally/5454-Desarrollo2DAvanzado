using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth;
    public float maxHealth;

    public Slider healthSlider;

    void Start()
    {
        playerHealth = maxHealth;

        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth; 
            healthSlider.value = playerHealth; 
        }
    }

    void Update()
    {
        if (playerHealth < 0)
        {
            playerHealth = 0;
        }

        if (playerHealth <= 0)
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.GameOver();
            }

            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            playerHealth--;

            if (healthSlider != null)
            {
                healthSlider.value = playerHealth;
            }

        }
    }
}
