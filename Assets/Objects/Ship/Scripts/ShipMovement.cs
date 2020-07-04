using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ShipMovement : MonoBehaviour
{
    public static bool movementDisabled = false;
    private bool canDoAction = true;
    public static int columnPosition = 3;
    private bool locked;
    private bool moveLeft;
    private float movementDistance;
    private bool moveRight;
    private Vector2 position;
    private readonly float speed = 15f;
    private Vector2 target;
    private Vector2 touchedPos;
    public GameObject MovingLeftWind;
    public GameObject MovingRightWind;
    private Camera mainCamera;
    private Vector2 fingerDown;
    private Vector2 fingerUp;
    public bool detectSwipeOnlyAfterRelease = false;
    private float SWIPE_THRESHOLD = 0f;
    public bool canMove = true;
    public static bool swipeToMove = false;
    public static bool taptoMove = true;
    public static bool level1Transition = false;
    public static bool level1EndMovement = true;
    private Vector2 levelClear;
    public bool movingShip = false;
    public static bool movingToCenter = true;
    public static bool transitionToLevel2 = false;
    public static bool initialMove = true;
    public static bool shipCanMoveUp = false;

    private void Start()
    {
        levelClear.x = ((Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 1.5f, 1))).x);
        levelClear.y = ((Camera.main.ViewportToWorldPoint(new Vector3(0f, 1.5f, 1))).y);
        movementDistance = Screen.width / (Screen.width / 1.5f);
        position = transform.position;
        if (.5 <= Camera.main.aspect)
        {
            target.y = ((Camera.main.ViewportToWorldPoint(new Vector3(0f, 0.06f, 1))).y);
        }
        else
        {
            target.y = ((Camera.main.ViewportToWorldPoint(new Vector3(0f, 0, 1))).y);
        }
    }

    private void Update()
    {
        if (level1Transition && level1EndMovement)
        {
            StartCoroutine(disableShipMovement());
        }
        if (!level1EndMovement)
        {
            transform.position = position;
            if (position.x != levelClear.x && movingToCenter)
            {
                position.x = Mathf.MoveTowards(transform.position.x, levelClear.x, Time.deltaTime * 3f);
                transform.position = position;
            }

            if (position.x == levelClear.x && shipCanMoveUp)
            {
                columnPosition = 3;
                movingToCenter = false;
                position.y = Mathf.MoveTowards(transform.position.y, levelClear.y, Time.deltaTime * 15f);
                transform.position = position;
            }
            if (position.y == levelClear.y && movementDisabled)
            {
                shipCanMoveUp = false;
                movingToCenter = true;
                transitionToLevel2 = true;
            }
        }

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUp = touch.position;
                fingerDown = touch.position;
            }

            //Detects Swipe while finger is still moving
            if (touch.phase == TouchPhase.Moved && canMove && PauseMenu.gameIsPaused == false && swipeToMove && !movementDisabled)
            {

                if (!detectSwipeOnlyAfterRelease)
                {
                    canMove = false;
                    fingerDown = touch.position;
                    checkSwipe();
                }
            }

            //Detects swipe after finger is released
            if (touch.phase == TouchPhase.Ended)
            {
                /*fingerDown = touch.position;
                checkSwipe();*/
                canMove = true;
            }
        }

        if (position.y != target.y && initialMove)
        {
            position.y = Mathf.MoveTowards(transform.position.y, target.y, Time.deltaTime * 7f);
            transform.position = position;
            if (position.y == target.y)
            {
                initialMove = false;
            }
        }

        if (Input.GetKeyDown("left") && canDoAction && PauseMenu.gameIsPaused == false && !movementDisabled)
        {
            moveLeft = true;
        }

        if (Input.GetKeyDown("right") && canDoAction && PauseMenu.gameIsPaused == false && !movementDisabled)
        {
            moveRight = true;
        }


        if (Input.touchCount > 0 && !movementDisabled && taptoMove && !movementDisabled)

            switch (Input.GetTouch(0).phase)
            {
                case TouchPhase.Began:
                    if (Input.GetTouch(0).position.x < Screen.width / 2 &&
                        Input.GetTouch(0).position.y < Screen.height / 2 && PauseMenu.gameIsPaused == false)
                    {
                        moveLeft = true;
                    }
                    else if (Input.GetTouch(0).position.x > Screen.width / 2 &&
                             Input.GetTouch(0).position.y < Screen.height / 2 && PauseMenu.gameIsPaused == false)
                    {
                        moveRight = true;
                    }
                    break;
            }

        if (moveLeft)
        {
            canDoAction = false;

            if (
                !locked && columnPosition != 1
            )
            {
                Instantiate(MovingLeftWind, new Vector3(transform.position.x + 0.5f, transform.position.y), transform.rotation);
                target.x = transform.position.x - movementDistance;
                locked = true;
                columnPosition--;
            }

            position.x =
                Mathf.MoveTowards(transform.position.x,
                    target.x,
                    Time.deltaTime * speed);
            transform.position = position;
            if (transform.position.x == target.x)
            {
                moveLeft = false;
                locked = false;
                canDoAction = true;
            }
        }

        if (moveRight)
        {
            canDoAction = false;
            if (!locked && columnPosition != 5)
            {
                Instantiate(MovingRightWind, new Vector3(transform.position.x - 0.5f, transform.position.y), transform.rotation);
                target.x = transform.position.x + movementDistance;
                locked = true;
                columnPosition++;
            }

            position.x = Mathf.MoveTowards(transform.position.x,
                target.x,
                Time.deltaTime * speed);
            transform.position = position;
            if (transform.position.x == target.x)
            {
                moveRight = false;
                locked = false;
                canDoAction = true;
            }
        }
    }

    void checkSwipe()
    {
        //Check if Vertical swipe
        if (verticalMove() > SWIPE_THRESHOLD && verticalMove() > horizontalValMove())
        {
            //Debug.Log("Vertical");
            if (fingerDown.y - fingerUp.y > 0)//up swipe
            {
                OnSwipeUp();
            }
            else if (fingerDown.y - fingerUp.y < 0)//Down swipe
            {
                OnSwipeDown();
            }
            fingerUp = fingerDown;
        }

        //Check if Horizontal swipe
        else if (horizontalValMove() > SWIPE_THRESHOLD && horizontalValMove() > verticalMove())
        {
            //Debug.Log("Horizontal");
            if (fingerDown.x - fingerUp.x > 0)//Right swipe
            {

                OnSwipeRight();
            }
            else if (fingerDown.x - fingerUp.x < 0)//Left swipe
            {


                OnSwipeLeft();
            }
            fingerUp = fingerDown;
        }

        //No Movement at-all
        else
        {
            //Debug.Log("No Swipe!");
        }
    }

    float verticalMove()
    {
        return Mathf.Abs(fingerDown.y - fingerUp.y);
    }

    float horizontalValMove()
    {
        return Mathf.Abs(fingerDown.x - fingerUp.x);
    }

    //////////////////////////////////CALLBACK FUNCTIONS/////////////////////////////
    void OnSwipeUp()
    {
        Debug.Log("Swipe UP");
    }

    void OnSwipeDown()
    {
        Debug.Log("Swipe Down");
    }

    void OnSwipeLeft()
    {
        Debug.Log("Swipe Left");
        moveLeft = true;
        if (moveLeft)
        {
            canDoAction = false;

            if (
                !locked && columnPosition != 1
            )
            {
                Instantiate(MovingLeftWind, new Vector3(transform.position.x + 0.5f, transform.position.y), transform.rotation);
                target.x = transform.position.x - movementDistance;
                locked = true;
                columnPosition--;
            }

            position.x =
                Mathf.MoveTowards(transform.position.x,
                    target.x,
                    Time.deltaTime * speed);
            transform.position = position;
            if (transform.position.x == target.x)
            {
                moveLeft = false;
                locked = false;
                canDoAction = true;
            }
        }
    }

    void OnSwipeRight()
    {
        Debug.Log("Swipe Right");
        moveRight = true;
        if (moveRight)
        {
            canDoAction = false;
            if (!locked && columnPosition != 5)
            {
                Instantiate(MovingRightWind, new Vector3(transform.position.x - 0.5f, transform.position.y), transform.rotation);
                target.x = transform.position.x + movementDistance;
                locked = true;
                columnPosition++;
            }

            position.x = Mathf.MoveTowards(transform.position.x,
                target.x,
                Time.deltaTime * speed);
            transform.position = position;
            if (transform.position.x == target.x)
            {
                moveRight = false;
                locked = false;
                canDoAction = true;
            }
        }
    }
    public IEnumerator disableShipMovement()
    {
        yield return new WaitForSeconds(2.0f);
        shipCanMoveUp = true;
        movementDisabled = true;
        level1EndMovement = false;
        level1Transition = false;
    }
}