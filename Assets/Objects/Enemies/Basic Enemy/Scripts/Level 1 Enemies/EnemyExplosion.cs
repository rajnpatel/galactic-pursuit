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
    private AudioSource[] audioSources;
    private AudioClip explosionSound;
    private AudioClip laserImpactSound;
    private AudioClip fireImpactSound;
    private AudioClip poweredLaserImpactSound;
    public static bool laserSound = false;
    public static bool fireSound = false;
    public static bool poweredLaserSound = false;
    void Start()
    {
        StartCoroutine("explosionAnimation");
        audioSources = GetComponents<AudioSource>();
        laserImpactSound = audioSources[0].clip;
        explosionSound = audioSources[1].clip;
        fireImpactSound = audioSources[2].clip;
        poweredLaserImpactSound = audioSources[3].clip;
        if (laserSound)
        {
            laserSound = false;
            audioSources[0].PlayOneShot(laserImpactSound);
        }
        else if (fireSound)
        {
            fireSound = false;
            audioSources[2].PlayOneShot(fireImpactSound);
        }
        else if (poweredLaserSound)
        {
            poweredLaserSound = false;
            audioSources[3].PlayOneShot(poweredLaserImpactSound);
        }
        audioSources[1].PlayOneShot(explosionSound);
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
