using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShield : MonoBehaviour
{
    private Vector2 position;
    private readonly float speed = 7f;
    private Vector2 target;
    private int health = 100;
    public Sprite shieldNormal;
    public Sprite shieldHurt;
    public static bool shield = true;
    public static bool triggered = false;
    public static bool relocating = false;

    private void Start()
    {
        position = transform.position;
        target.y = (Camera.main.ViewportToWorldPoint(new Vector3(0f, .7375f, 1))).y;
    }
    void Update()
    {
        if (position.y > target.y)
        {
            position.y = Mathf.MoveTowards(transform.position.y, target.y, Time.deltaTime * speed);
            transform.position = position;
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("ShipBullet")
         || col.gameObject.CompareTag("PoweredLaser"))
        {
            StartCoroutine(shieldDamaged());
            health--;
        }

        else if (col.gameObject.CompareTag("FireProjectile"))
        {
            StartCoroutine(shieldDamaged());
            health -= 2;
        }
        if (health <= 0)
        {
            shield = false;

            if (Level3EnemyHurt.level3Enemies > 45)
            {
                triggered = true;
            }
            else
            {
                relocating = true;
            }
            Destroy(gameObject);
        }
    }
    public IEnumerator shieldDamaged()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = shieldHurt;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = shieldNormal;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = shieldHurt;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = shieldNormal;
    }
}
