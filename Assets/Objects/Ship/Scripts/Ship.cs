using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{
    public static bool shield = false;
    public static bool hasDied = false;
    private Animator animator;
    private AudioSource[] audioSources;
    private BoxCollider2D boxCollider2D;
    [SerializeField] private Sprite[] healthBarSpriteArray;
    private AudioClip shipDeath;
    [SerializeField] public static int shipHealth = 3;
    private AudioClip shipImpact;
    private AudioClip shipLaser;
    private SpriteRenderer spriteRenderer;
    public Sprite explosion0;
    public Sprite explosion1;
    public Sprite explosion2;
    public Sprite explosion3;
    public Sprite explosion4;
    public GameObject ship;
    private Vector2 position;
    Renderer rend;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        position = transform.position;
        spriteRenderer = GameObject.FindWithTag("HealthBar").GetComponent<SpriteRenderer>();
        audioSources = GetComponents<AudioSource>();
        shipLaser = audioSources[0].clip;
        shipImpact = audioSources[1].clip;
        shipDeath = audioSources[2].clip;
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        if (Lives.respawning)
        {
            StartCoroutine(respawning());
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // TODO: Need to make a list of things that can damage the ship and check if the gameObject exists in that list
        // This if statement is unsustainable as more hostile objects are added
        if (col.gameObject.CompareTag("EnemyProjectile") || col.gameObject.CompareTag("BasicEnemy") ||
            col.gameObject.CompareTag("Asteroid"))
            if (shield == false && !Lives.respawning && !ShipMovement.movementDisabled)
            {
                if (ShipShoot.blueWeapons)
                {
                    ShipShoot.blueWeapons = false;
                    if (ShipShoot.weapon1)
                    {
                        ShipShoot.canShoot = true;
                    }
                    if (ShipShoot.weapon2)
                    {
                        ShipShoot.canFire = true;
                    }
                    if (ShipShoot.weapon3)
                    {
                        ShipShoot.canShootPoweredLaser = true;
                    }
                }
                shipHealth -= 1;
                audioSources[1].PlayOneShot(shipImpact);
                animator.SetTrigger("Damaged");
            }

        if (col.gameObject.CompareTag("HealthPack") && shipHealth < 3) shipHealth++;

        switch (shipHealth)
        {
            case 3:
                spriteRenderer.sprite = healthBarSpriteArray[10];
                break;
            // case 9:
            //     spriteRenderer.sprite = healthBarSpriteArray[9];
            //   break;
            //case 8:
            //    spriteRenderer.sprite = healthBarSpriteArray[8];
            //   break;
            case 2:
                spriteRenderer.sprite = healthBarSpriteArray[7];
                break;
            /* case 6:
                spriteRenderer.sprite = healthBarSpriteArray[6];
                break;
            case 5:
                spriteRenderer.sprite = healthBarSpriteArray[5];
                break;
            case 4:
                spriteRenderer.sprite = healthBarSpriteArray[4];
                break;
            case 3:
                spriteRenderer.sprite = healthBarSpriteArray[3];
                break;
            case 2:
                spriteRenderer.sprite = healthBarSpriteArray[2];
                break; */
            case 1:
                spriteRenderer.sprite = healthBarSpriteArray[4];
                break;
            case 0:
                Lives.lives--;
                hasDied = true;
                shipHealth = -1;
                spriteRenderer.sprite = healthBarSpriteArray[0];
                ShipMovement.columnPosition = 3;
                animator.SetTrigger("Explode");
                boxCollider2D.size = new Vector2(0, 0);
                ShipShoot.allWeaponsDisabled = true;
                ShipMovement.movementDisabled = true;
                AudioSource.PlayClipAtPoint(shipDeath, new Vector2(0, 0));
                if (Lives.lives > 0)
                {
                    StartCoroutine(respawn());
                }

                if (Lives.lives == 0)
                {
                    StartCoroutine(GameOver());
                }
                break;
        }
    }

    public IEnumerator respawning()
    {
        yield return new WaitForSeconds(0.15f);
        rend.material.color = Color.Lerp(Color.black, Color.black, Mathf.PingPong(Time.time, 1));
        yield return new WaitForSeconds(0.15f);
        rend.material.color = Color.Lerp(Color.white, Color.white, Mathf.PingPong(Time.time, 1));
        yield return new WaitForSeconds(0.15f);
        rend.material.color = Color.Lerp(Color.black, Color.black, Mathf.PingPong(Time.time, 1));
        yield return new WaitForSeconds(0.15f);
        rend.material.color = Color.Lerp(Color.white, Color.white, Mathf.PingPong(Time.time, 1));
        yield return new WaitForSeconds(0.15f);
        rend.material.color = Color.Lerp(Color.black, Color.black, Mathf.PingPong(Time.time, 1));
        yield return new WaitForSeconds(0.15f);
        rend.material.color = Color.Lerp(Color.white, Color.white, Mathf.PingPong(Time.time, 1));
        yield return new WaitForSeconds(0.15f);
        Lives.respawning = false;

    }
    public IEnumerator respawn()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadSceneAsync("Game Over");
    }
}