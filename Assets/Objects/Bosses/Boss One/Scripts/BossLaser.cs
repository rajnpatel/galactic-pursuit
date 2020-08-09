using UnityEngine;

public class BossLaser : MonoBehaviour
{
    private const float velX = 0;

    private Rigidbody2D rb;
    private float velY;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (Level1EnemyHurt.level1Enemies == 1)
        {
            velY = -7f;
        }
        else if (Level2EnemyHurt.level2Enemies <= 2)
        {
            velY = -8f;
        }
        else if (Level3EnemyHurt.level3Enemies <= 11)
        {
            velY = -9f;
        }
    }

    private void Update()
    {
        rb.velocity = new Vector2(velX, velY);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ship") ||
            col.gameObject.CompareTag("Shield") ||
            col.gameObject.CompareTag("Asteroid"))
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}