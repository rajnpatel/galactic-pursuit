using UnityEngine;

public class Multiplier : MonoBehaviour
{
    private float multiplier;

    [SerializeField] private Sprite[] multiplierSpriteArray;

    private SpriteRenderer spriteRenderer;
    public GameObject multiplierIcon;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 1));

    }

    private void Update()
    {
        switch (ShipShoot.multiplier)
        {
            case 1:
                spriteRenderer.sprite = multiplierSpriteArray[0];
                break;
            case 2:
                spriteRenderer.sprite = multiplierSpriteArray[1];
                break;
            case 3:
                spriteRenderer.sprite = multiplierSpriteArray[2];
                break;
            case 4:
                spriteRenderer.sprite = multiplierSpriteArray[3];
                break;
            case 5:
                spriteRenderer.sprite = multiplierSpriteArray[4];
                break;
        }
    }
}