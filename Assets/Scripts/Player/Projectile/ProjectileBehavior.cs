using System.Collections;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    Rigidbody2D rb_projectile;
    void Start()
    {
        rb_projectile = GetComponent<Rigidbody2D>();
        StartCoroutine(ProjectileDestroy());
    }

    IEnumerator ProjectileDestroy()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject, 2f);
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
