using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public static int lives = 3;
    public GameObject ship;
    private Vector2 target;
    public Sprite three;
    public Sprite two;
    public static bool liveTwoRespawn = true;
    public Sprite one;
    public static bool liveOneRespawn = true;
    public Sprite zero;
    public static bool respawning = false;
    void Start()
    {
        if (.5 <= Camera.main.aspect)
        {
            target.y = ((Camera.main.ViewportToWorldPoint(new Vector3(0f, 0.06f, 1))).y);
        }
        else
        {
            target.y = ((Camera.main.ViewportToWorldPoint(new Vector3(0f, 0, 1))).y);
        }
        target.x = ((Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0, 1))).x);

        if (lives == 3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = three;
        }
        else if (lives == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = two;
        }
        else if (lives == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = one;
        }
    }

    void Update()
    {
        if (lives == 3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = three;
        }
        else if (lives == 2 && liveTwoRespawn)
        {
            liveTwoRespawn = false;
            StartCoroutine(respawn());
            gameObject.GetComponent<SpriteRenderer>().sprite = two;
        }
        else if (lives == 1 && liveOneRespawn)
        {
            liveOneRespawn = false;
            StartCoroutine(respawn());
            gameObject.GetComponent<SpriteRenderer>().sprite = one;
        }
        else if (lives == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = zero;
        }
    }
    public IEnumerator respawn()
    {
        yield return new WaitForSeconds(2);
        ShipShoot.weapon1 = true;
        ShipShoot.weapon2 = false;
        ShipShoot.weapon3 = false;
        ShipShoot.canShoot = true;
        Ship.shipHealth = 3;
        Ship.shield = false;
        ShipMovement.movementDisabled = false;
        ShipShoot.allWeaponsDisabled = false;
        Instantiate(ship, new Vector3(target.x, target.y), transform.rotation);
        respawning = true;
    }
}
