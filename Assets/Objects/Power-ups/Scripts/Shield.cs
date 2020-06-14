using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public static int shieldHealth = 3;
    public GameObject shield;
    public static bool shieldCanAppear = false;
    Rigidbody2D rb;
    Transform ShipObject;
    public Sprite shieldNormal;
    public Sprite shieldHurt;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ShipObject = GameObject.Find("Ship").transform;
    }
    void Update()
    {
        if (Ship.hasDied)
        {
            ShipObject = GameObject.Find("Ship(Clone)").transform;
        }
        if (Ship.shield == true && shieldCanAppear == true)
        {
            shieldCanAppear = false;
            Instantiate(shield, ShipObject.position, transform.rotation);
        }
        transform.position = ShipObject.position;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        // TODO: Need to make a list of things that can damage the ship and check if the gameObject exists in that list
        // This if statement is unsustainable as more hostile objects are added
        if (ShipMovement.movementDisabled == false &&
            col.gameObject.CompareTag("EnemyProjectile") ||
            col.gameObject.CompareTag("BasicEnemy") ||
            col.gameObject.CompareTag("Asteroid")
        )
        {
            StartCoroutine(shieldDamaged());
            shieldHealth--;
        }
        if (shieldHealth == 0)
        {
            Ship.shield = false;
            Destroy(gameObject);
        }
    }
    public IEnumerator shieldDamaged()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = shieldHurt;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = shieldNormal;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = shieldHurt;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = shieldNormal;
    }
}