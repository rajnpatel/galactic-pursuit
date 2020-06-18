using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelText : MonoBehaviour
{
    public float alphaLevel1 = .1f;

    void Start()
    {
        StartCoroutine(fadeIn());
    }

    void Update()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaLevel1);
    }
    public IEnumerator fadeIn()
    {
        yield return new WaitForSeconds(0.1f);
        alphaLevel1 += 0.05f;
        yield return new WaitForSeconds(0.1f);
        alphaLevel1 += 0.05f;
        yield return new WaitForSeconds(0.1f);
        alphaLevel1 += 0.05f;
        yield return new WaitForSeconds(0.1f);
        alphaLevel1 += 0.05f;
        yield return new WaitForSeconds(0.1f);
        alphaLevel1 += 0.05f;
        yield return new WaitForSeconds(0.1f);
        alphaLevel1 += 0.05f;
        yield return new WaitForSeconds(0.1f);
        alphaLevel1 += 0.05f;
        yield return new WaitForSeconds(0.1f);
        alphaLevel1 += 0.05f;
        yield return new WaitForSeconds(0.1f);
        alphaLevel1 += 0.05f;
        yield return new WaitForSeconds(0.1f);
        alphaLevel1 += 0.05f;
        yield return new WaitForSeconds(0.1f);
        alphaLevel1 += 0.05f;
        yield return new WaitForSeconds(0.1f);
        alphaLevel1 += 0.05f;
        yield return new WaitForSeconds(0.1f);
        alphaLevel1 += 0.05f;
        yield return new WaitForSeconds(0.1f);
        alphaLevel1 += 0.05f;
        yield return new WaitForSeconds(0.1f);
        alphaLevel1 += 0.05f;
        yield return new WaitForSeconds(0.1f);
        alphaLevel1 += 0.05f;
        yield return new WaitForSeconds(0.1f);
        alphaLevel1 += 0.05f;
        yield return new WaitForSeconds(0.1f);
        alphaLevel1 += 0.05f;
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
