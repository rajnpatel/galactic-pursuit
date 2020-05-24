using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosion : MonoBehaviour
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
    void Start()
    {
        StartCoroutine("explosionAnimation");
    }
    public IEnumerator explosionAnimation()
    {
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = explosion2;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = explosion3;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = explosion4;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = explosion5;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = explosion6;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = explosion7;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = explosion8;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = explosion9;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = explosion10;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = explosion11;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = explosion12;
        yield return new WaitForSeconds(0.05f);
        Destroy(gameObject);
    }
}
