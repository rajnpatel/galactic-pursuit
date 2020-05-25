using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFire : MonoBehaviour
{
    private const float velX = 0;
    private Rigidbody2D rb;
    private float speed = 30f;
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
    public Sprite fire21;
    public Sprite fire22;
    public Sprite fire23;
    public Sprite fire24;
    public Sprite fire25;
    public Sprite fire26;
    public Sprite fire27;
    public Sprite fire28;
    public Sprite fire29;
    public Sprite fire30;
    public Sprite fire31;
    public Sprite fire32;
    public Sprite fire33;
    public Sprite fire34;
    public Sprite fire35;
    public Sprite fire36;
    public Sprite fire37;
    public Sprite fire38;
    public Sprite fire39;
    public Sprite fire40;
    public Sprite fire41;
    public Sprite fire42;
    public Sprite fire43;
    public Sprite fire44;
    public Sprite fire45;
    public Sprite fire46;
    public Sprite fire47;
    public Sprite fire48;
    public Sprite fire49;
    public Sprite fire50;
    public Sprite fire51;
    public Sprite fire52;
    public Sprite fire53;
    public Sprite fire54;
    public Sprite fire55;
    public Sprite fire56;
    public Sprite fire57;
    public Sprite fire58;
    public Sprite fire59;
    public Sprite fire60;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(FireAnimation());
    }

    private void Update()
    {
        rb.velocity = new Vector2(velX, speed);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("BasicEnemy")
        || col.gameObject.CompareTag("Asteroid")) Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    public IEnumerator FireAnimation()
    {
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire1;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire2;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire3;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire4;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire5;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire6;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire7;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire8;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire9;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire10;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire11;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire12;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire13;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire14;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire15;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire16;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire17;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire18;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire19;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire20;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire21;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire22;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire23;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire24;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire25;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire26;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire27;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire28;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire29;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire30;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire31;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire32;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire33;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire34;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire35;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire36;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire37;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire38;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire39;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire40;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire41;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire42;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire43;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire44;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire45;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire46;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire47;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire48;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire49;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire50;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire51;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire52;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire53;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire54;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire55;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire56;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire57;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire58;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire59;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = fire60;
    }
}