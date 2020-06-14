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
    public bool canAnimate = true;
    public bool foundClone = false;

    void Start()
    {
        position = transform.position;
        ShipObject = GameObject.Find("Ship").transform;
        transform.SetParent(ShipObject.transform, true);
    }

    void Update()
    {
        if (Ship.hasDied && !foundClone)
        {
            foundClone = true;
            ShipObject = GameObject.Find("Ship(Clone)").transform;
        }
        if (canAnimate)
        {
            transform.SetParent(ShipObject.transform, true);
            canAnimate = false;
            StartCoroutine(muzzleAnimation());
        }
        if (ShipShoot.weapon3 || ShipShoot.allWeaponsDisabled)
        {
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
        canAnimate = true;
    }
}
