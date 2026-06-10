using UnityEngine;

public class EnemySpawners : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate;
    public float spawnDistance;

    public GameObject player;

    public float timeSinceLastSpawn;

    private ScoreSystem scoreSystem;

    //Dificultad
    public float tiempoMinimoSpawn = 0.8f;
    public float reduccionPorBaja = 0.15f;
    public float aumentoVelocidadPorBaja = 0.2f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        scoreSystem = FindObjectOfType<ScoreSystem>();
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        float ritmoActual = CalcularRitmoSpawn();

        if (timeSinceLastSpawn >= spawnRate && player.GetComponent<PlayerHealth>().playerHealth > 0)
        {
            SpawnEnemy();
            timeSinceLastSpawn = 0f;
        }

    }

    float CalcularRitmoSpawn()
    {
        if (scoreSystem == null) return spawnRate;

        float ritmoCalculado = spawnRate - (scoreSystem.score * reduccionPorBaja);
        return Mathf.Max(ritmoCalculado, tiempoMinimoSpawn);
    }

    void SpawnEnemy()
    {
        Vector2 spawnPosition = Random.insideUnitCircle.normalized * spawnDistance;
        spawnPosition += (Vector2)transform.position;

        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        EnemyBehaviour enemyBehaviour = newEnemy.GetComponent<EnemyBehaviour>();
        if (enemyBehaviour != null && scoreSystem != null)
        {
            enemyBehaviour.speed += (scoreSystem.score * aumentoVelocidadPorBaja);
        }
    }
}
