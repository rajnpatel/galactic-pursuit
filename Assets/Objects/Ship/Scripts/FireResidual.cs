using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireResidual : MonoBehaviour
{
    public Sprite fire1;
    public Sprite fire2;
    public Sprite fire3;
    public Sprite fire4;
    public Sprite fire5;
    public Sprite fire6;
    public Sprite fire7;
    public Sprite fire8;
    public Sprite fire9;
    public Sprite fire10;
    public Sprite fire11;
    public Sprite fire12;
    public Sprite fire13;
    public Sprite fire14;
    public Sprite fire15;
    public Sprite fire16;
    public Sprite fire17;
    public Sprite fire18;
    public Sprite fire19;
    public Sprite fire20;
    // The 2 booleans below are needed as without it the fire residual effect will sometimes
    // cause all of the code to occur twice, i.e., instantation of the fire residual effect,
    // the explosion of the enemy, the explosion audio, and even the level1Enemies decrementing.
    public static bool canFollowEnemy = true;
    public static bool canFollowAsteroid = true;

    void Start()
    {
        StartCoroutine(FireAnimation());
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Asteroid") && canFollowAsteroid)
        {
            canFollowAsteroid = false;
            transform.SetParent(col.gameObject.transform, true);
            StartCoroutine(canFollowAsteroidDelay());
        }
        if (col.gameObject.CompareTag("BasicEnemy") && canFollowEnemy)
        {
            canFollowEnemy = false;
            transform.SetParent(col.gameObject.transform, true);
            StartCoroutine(canFollowEnemyDelay());
        }
    }

    public IEnumerator FireAnimation()
    {
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire1;
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire2;
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire3;
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire4;
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire5;
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire6;
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire7;
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire8;
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire9;
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire10;
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire11;
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire12;
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire13;
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire14;
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire15;
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire16;
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire17;
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire18;
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire19;
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire20;
        yield return new WaitForSeconds(0.01f);
        Destroy(gameObject);
    }
    public IEnumerator canFollowEnemyDelay()
    {
        yield return new WaitForSeconds(0.01f);
        canFollowEnemy = true;
    }
    public IEnumerator canFollowAsteroidDelay()
    {
        yield return new WaitForSeconds(0.01f);
        canFollowAsteroid = true;
    }
}
