using System.Collections;
using UnityEngine;

public class AsteroidAppear : MonoBehaviour
{
    public GameObject Asteroid;
    private bool canAppear = true;
    private float RandomNum;
    public static bool asteroidSound = false;
    private AudioSource[] audioSources;
    private AudioClip explosionSound;
    private AudioClip laserImpactSound;

    private void Start()
    {
        audioSources = GetComponents<AudioSource>();
        laserImpactSound = audioSources[0].clip;
    }
    private void Update()
    {
        if (asteroidSound)
        {
            asteroidSound = false;
            audioSources[0].PlayOneShot(laserImpactSound);
        }

        float[] xCoordinates = {

    (Camera.main.ViewportToWorldPoint(new Vector3(0.1f, 0f, 1))).x,
    (Camera.main.ViewportToWorldPoint(new Vector3(0.3f, 0f, 1))).x,
    (Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0f, 1))).x,
    (Camera.main.ViewportToWorldPoint(new Vector3(0.7f, 0f, 1))).x,
    (Camera.main.ViewportToWorldPoint(new Vector3(0.9f, 0f, 1))).x

    };
        RandomNum = xCoordinates[Random.Range(0, 4)];
        if (!canAppear || ShipMovement.movementDisabled || Level1EnemyHurt.level1Enemies > 61) return;
        canAppear = false;
        StartCoroutine(NoAppear());


    }
    private IEnumerator NoAppear()
    {
        yield return new WaitForSeconds((float)RandomHandler.AsteroidRandomAppear());
        Instantiate(Asteroid, new Vector2(RandomNum, 7), transform.rotation);
        canAppear = true;
    }
}