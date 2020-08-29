using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidExplosion : MonoBehaviour
{
    public Sprite explosion2;
    public Sprite explosion3;
    public Sprite explosion4;
    public Sprite explosion5;
    public Sprite explosion6;
    public Sprite explosion7;
    public Sprite explosion8;
    public Sprite explosion9;
    public Sprite explosion10;
    public Sprite explosion11;
    public Sprite explosion12;
    public Sprite explosion13;
    public Sprite explosion14;
    public Sprite explosion15;
    public Sprite explosion16;
    public Sprite explosion17;
    public Sprite explosion18;
    public Sprite explosion19;
    public Sprite explosion20;
    public Sprite explosion21;
    private AudioSource[] audioSources;
    private Rigidbody2D rb;
    public float velY = -3f;
    private const float velX = 0;
    private AudioClip explosionSound;

    void Start()
    {
        StartCoroutine(explosionAnimation());
        rb = GetComponent<Rigidbody2D>();
        audioSources = GetComponents<AudioSource>();
        explosionSound = audioSources[0].clip;
        audioSources[0].PlayOneShot(explosionSound);
    }

    private void Update()
    {
        rb.velocity = new Vector2(velX, velY);
    }
    public IEnumerator explosionAnimation()
    {
        yield return new WaitForSeconds(0.015f);
        gameObject.GetComponent<SpriteRenderer>().sprite = explosion2;
        yield return new WaitForSeconds(0.015f);
        gameObject.GetComponent<SpriteRenderer>().sprite = explosion3;
        yield return new WaitForSeconds(0.015f);
        gameObject.GetComponent<SpriteRenderer>().sprite = explosion4;
        yield return new WaitForSeconds(0.015f);
        gameObject.GetComponent<SpriteRenderer>().sprite = explosion5;
        yield return new WaitForSeconds(0.015f);
        gameObject.GetComponent<SpriteRenderer>().sprite = explosion6;
        yield return new WaitForSeconds(0.015f);
        gameObject.GetComponent<SpriteRenderer>().sprite = explosion7;
        yield return new WaitForSeconds(0.015f);
        gameObject.GetComponent<SpriteRenderer>().sprite = explosion8;
        yield return new WaitForSeconds(0.015f);
        gameObject.GetComponent<SpriteRenderer>().sprite = explosion9;
        yield return new WaitForSeconds(0.015f);
        gameObject.GetComponent<SpriteRenderer>().sprite = explosion10;
        yield return new WaitForSeconds(0.015f);
        gameObject.GetComponent<SpriteRenderer>().sprite = explosion11;
        yield return new WaitForSeconds(0.015f);
        gameObject.GetComponent<SpriteRenderer>().sprite = explosion12;
        yield return new WaitForSeconds(0.015f);
        gameObject.GetComponent<SpriteRenderer>().sprite = explosion13;
        yield return new WaitForSeconds(0.015f);
        gameObject.GetComponent<SpriteRenderer>().sprite = explosion14;
        yield return new WaitForSeconds(0.015f);
        gameObject.GetComponent<SpriteRenderer>().sprite = explosion15;
        yield return new WaitForSeconds(0.015f);
        gameObject.GetComponent<SpriteRenderer>().sprite = explosion16;
        yield return new WaitForSeconds(0.015f);
        Destroy(gameObject);
    }
}
