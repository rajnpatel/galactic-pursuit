using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindAnimation : MonoBehaviour
{
    public Sprite wind2;
    public Sprite wind3;
    public Sprite wind4;
    public Sprite wind5;
    public Sprite wind6;
    public Sprite wind7;
    public Sprite wind8;
    public Sprite wind9;
    public Sprite wind10;
    public Sprite wind11;
    public Sprite wind12;
    public Sprite wind13;
    public Sprite wind14;
    public Sprite wind15;
    public Sprite wind16;

    void Start()
    {
        StartCoroutine("movingAnimation");
    }
    public IEnumerator movingAnimation()
    {
        yield return new WaitForSeconds(0.02f);
        gameObject.GetComponent<SpriteRenderer>().sprite = wind2;
        yield return new WaitForSeconds(0.02f);
        gameObject.GetComponent<SpriteRenderer>().sprite = wind3;
        yield return new WaitForSeconds(0.02f);
        gameObject.GetComponent<SpriteRenderer>().sprite = wind4;
        yield return new WaitForSeconds(0.02f);
        gameObject.GetComponent<SpriteRenderer>().sprite = wind5;
        yield return new WaitForSeconds(0.02f);
        gameObject.GetComponent<SpriteRenderer>().sprite = wind6;
        yield return new WaitForSeconds(0.02f);
        gameObject.GetComponent<SpriteRenderer>().sprite = wind7;
        yield return new WaitForSeconds(0.02f);
        gameObject.GetComponent<SpriteRenderer>().sprite = wind8;
        yield return new WaitForSeconds(0.02f);
        gameObject.GetComponent<SpriteRenderer>().sprite = wind9;
        yield return new WaitForSeconds(0.02f);
        gameObject.GetComponent<SpriteRenderer>().sprite = wind10;
        yield return new WaitForSeconds(0.02f);
        gameObject.GetComponent<SpriteRenderer>().sprite = wind11;
        yield return new WaitForSeconds(0.02f);
        gameObject.GetComponent<SpriteRenderer>().sprite = wind12;
        yield return new WaitForSeconds(0.02f);
        gameObject.GetComponent<SpriteRenderer>().sprite = wind13;
        yield return new WaitForSeconds(0.02f);
        gameObject.GetComponent<SpriteRenderer>().sprite = wind14;
        yield return new WaitForSeconds(0.02f);
        gameObject.GetComponent<SpriteRenderer>().sprite = wind15;
        yield return new WaitForSeconds(0.02f);
        gameObject.GetComponent<SpriteRenderer>().sprite = wind16;
        Destroy(gameObject);
    }
}
