using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed;
    public Transform player;

    public float enemyHealth;

    private Animator enemyAnimator;

    public GameObject UI;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        UI = GameObject.FindGameObjectWithTag("UI");
        enemyAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            enemyAnimator.SetFloat("Horizontal", direction.x);
            enemyAnimator.SetFloat("Vertical", direction.y);
            enemyAnimator.SetFloat("Speed", direction.magnitude);
        }

        else
        {
            enemyAnimator.SetFloat("Speed", 0);
        }

        if (enemyHealth <= 0)
        {
            UI.GetComponent<ScoreSystem>().AddScore();
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            enemyHealth--;
        }
    }
}
