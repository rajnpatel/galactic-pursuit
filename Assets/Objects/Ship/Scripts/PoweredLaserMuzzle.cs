using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoweredLaserMuzzle : MonoBehaviour
{
    Transform ShipObject;
    private Vector2 position;
    public Sprite muzzle2;
    public Sprite muzzle3;
    public Sprite muzzle4;
    public Sprite muzzle5;
    public Sprite muzzle6;
    public Sprite muzzle7;
    public Sprite muzzle8;
    public Sprite muzzle9;
    public Sprite muzzle10;
    public static bool canAnimateMuzzle = true;
    void Start()
    {
        position = transform.position;
        if (!Ship.hasDied)
        {
            ShipObject = GameObject.Find("Ship").transform;
            transform.SetParent(ShipObject.transform, true);
        }
        else
        {
            ShipObject = GameObject.Find("Ship(Clone)").transform;
            transform.SetParent(ShipObject.transform, true);
        }
    }

    void Update()
    {
        if (canAnimateMuzzle)
        {
            transform.SetParent(ShipObject.transform, true);
            canAnimateMuzzle = false;
            StartCoroutine(muzzleAnimation());
        }
        if (!ShipShoot.weapon3 || ShipShoot.allWeaponsDisabled)
        {
            Debug.Log("asdf");
            Destroy(gameObject);
        }
    }
    public IEnumerator muzzleAnimation()
    {
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().sprite = muzzle3;
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().sprite = muzzle4;
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().sprite = muzzle5;
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().sprite = muzzle6;
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().sprite = muzzle7;
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().sprite = muzzle8;
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().sprite = muzzle9;
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().sprite = muzzle10;
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().sprite = muzzle2;
        canAnimateMuzzle = true;
    }
}
