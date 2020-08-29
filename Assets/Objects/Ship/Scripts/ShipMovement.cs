using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

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
    private Vector2 levelClear;
    public static bool level1Transition = false;
    public static bool level1EndMovement = true;
    public static bool transitionToLevel2 = false;
    public static bool level2Transition = false;
    public static bool level2EndMovement = true;
    public static bool transitionToLevel3 = false;
    public static bool endGameTransition = false;
    public static bool endGameMovement = true;
    public static bool transitionToEndGame = false;
    public bool movingShip = false;
    public static bool movingToCenter = true;
    public static bool initialMove = true;
    public static bool shipCanMoveUp = false;
    string GooglePlay_ID = "3758045";
    bool TestMode = false;

    private void Start()
    {
        levelClear.x = ((Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0f, 1))).x);
        levelClear.y = ((Camera.main.ViewportToWorldPoint(new Vector3(0f, 1.5f, 1))).y);
        position = transform.position;
        target.y = ((Camera.main.ViewportToWorldPoint(new Vector3(0, 0.06f, 1))).y);
        Advertisement.Initialize(GooglePlay_ID, TestMode);
    }

    private void Update()
    {
        if (level1Transition && level1EndMovement)
        {
            level1Transition = false;
            shipCanMoveUp = true;
            StartCoroutine(disableShipMovementForLevel2());
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
                position.y = Mathf.MoveTowards(transform.position.y, levelClear.y, Time.deltaTime * 14f);
                transform.position = position;
            }
            if (position.y == levelClear.y && movementDisabled && shipCanMoveUp)
            {
                Advertisement.Show();
                shipCanMoveUp = false;
                movingToCenter = true;
                transitionToLevel2 = true;
                level1EndMovement = true;
            }
        }

        if (level2Transition && level2EndMovement)
        {
            level2Transition = false;
            shipCanMoveUp = true;
            StartCoroutine(disableShipMovementForLevel3());
        }
        if (!level2EndMovement)
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
                position.y = Mathf.MoveTowards(transform.position.y, levelClear.y, Time.deltaTime * 14f);
                transform.position = position;
            }
            if (position.y == levelClear.y && movementDisabled && shipCanMoveUp)
            {
                Advertisement.Show();
                shipCanMoveUp = false;
                movingToCenter = true;
                transitionToLevel3 = true;
                level2EndMovement = true;
            }
        }
        if (endGameTransition && endGameMovement)
        {
            endGameTransition = false;
            shipCanMoveUp = true;
            StartCoroutine(disableShipMovementForEndGame());
        }
        if (!endGameMovement)
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
                position.y = Mathf.MoveTowards(transform.position.y, levelClear.y, Time.deltaTime * 14f);
                transform.position = position;
            }
            if (position.y == levelClear.y && movementDisabled)
            {
                shipCanMoveUp = false;
                movingToCenter = true;
                transitionToEndGame = true;
                endGameMovement = true;
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
            //target.y has to be declared again or the positioning is not consistent among multiple resolutions for some reason
            target.y = ((Camera.main.ViewportToWorldPoint(new Vector3(0, 0.06f, 1))).y);
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
                if (columnPosition == 5)
                {
                    Instantiate(MovingLeftWind, new Vector3(transform.position.x + 0.5f, transform.position.y), transform.rotation);
                    target.x = (Camera.main.ViewportToWorldPoint(new Vector3(0.7f, 0f, 1))).x;
                    locked = true;
                    columnPosition--;
                }
                else if (columnPosition == 4)
                {
                    Instantiate(MovingLeftWind, new Vector3(transform.position.x + 0.5f, transform.position.y), transform.rotation);
                    target.x = (Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0f, 1))).x;
                    locked = true;
                    columnPosition--;
                }
                else if (columnPosition == 3)
                {
                    Instantiate(MovingLeftWind, new Vector3(transform.position.x + 0.5f, transform.position.y), transform.rotation);
                    target.x = (Camera.main.ViewportToWorldPoint(new Vector3(0.3f, 0f, 1))).x;
                    locked = true;
                    columnPosition--;
                }
                else if (columnPosition == 2)
                {
                    Instantiate(MovingLeftWind, new Vector3(transform.position.x + 0.5f, transform.position.y), transform.rotation);
                    target.x = (Camera.main.ViewportToWorldPoint(new Vector3(0.1f, 0f, 1))).x;
                    locked = true;
                    columnPosition--;
                }
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
                if (columnPosition == 1)
                {
                    Instantiate(MovingRightWind, new Vector3(transform.position.x - 0.5f, transform.position.y), transform.rotation);
                    target.x = (Camera.main.ViewportToWorldPoint(new Vector3(0.3f, 0f, 1))).x;
                    locked = true;
                    columnPosition++;
                }
                else if (columnPosition == 2)
                {
                    Instantiate(MovingRightWind, new Vector3(transform.position.x - 0.5f, transform.position.y), transform.rotation);
                    target.x = (Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0f, 1))).x;
                    locked = true;
                    columnPosition++;
                }
                else if (columnPosition == 3)
                {
                    Instantiate(MovingRightWind, new Vector3(transform.position.x - 0.5f, transform.position.y), transform.rotation);
                    target.x = (Camera.main.ViewportToWorldPoint(new Vector3(0.7f, 0f, 1))).x;
                    locked = true;
                    columnPosition++;
                }
                else if (columnPosition == 4)
                {
                    Instantiate(MovingRightWind, new Vector3(transform.position.x - 0.5f, transform.position.y), transform.rotation);
                    target.x = (Camera.main.ViewportToWorldPoint(new Vector3(0.9f, 0f, 1))).x;
                    locked = true;
                    columnPosition++;
                }
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
        moveLeft = true;
        if (moveLeft)
        {
            canDoAction = false;

            if (
                !locked && columnPosition != 1
            )
                if (columnPosition == 5)
                {
                    Instantiate(MovingLeftWind, new Vector3(transform.position.x + 0.5f, transform.position.y), transform.rotation);
                    target.x = (Camera.main.ViewportToWorldPoint(new Vector3(0.7f, 0f, 1))).x;
                    locked = true;
                    columnPosition--;
                }
                else if (columnPosition == 4)
                {
                    Instantiate(MovingLeftWind, new Vector3(transform.position.x + 0.5f, transform.position.y), transform.rotation);
                    target.x = (Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0f, 1))).x;
                    locked = true;
                    columnPosition--;
                }
                else if (columnPosition == 3)
                {
                    Instantiate(MovingLeftWind, new Vector3(transform.position.x + 0.5f, transform.position.y), transform.rotation);
                    target.x = (Camera.main.ViewportToWorldPoint(new Vector3(0.3f, 0f, 1))).x;
                    locked = true;
                    columnPosition--;
                }
                else if (columnPosition == 2)
                {
                    Instantiate(MovingLeftWind, new Vector3(transform.position.x + 0.5f, transform.position.y), transform.rotation);
                    target.x = (Camera.main.ViewportToWorldPoint(new Vector3(0.1f, 0f, 1))).x;
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
        moveRight = true;
        if (moveRight)
        {
            canDoAction = false;
            if (!locked && columnPosition != 5)
            {
                if (columnPosition == 1)
                {
                    Instantiate(MovingRightWind, new Vector3(transform.position.x - 0.5f, transform.position.y), transform.rotation);
                    target.x = (Camera.main.ViewportToWorldPoint(new Vector3(0.3f, 0f, 1))).x;
                    locked = true;
                    columnPosition++;
                }
                else if (columnPosition == 2)
                {
                    Instantiate(MovingRightWind, new Vector3(transform.position.x - 0.5f, transform.position.y), transform.rotation);
                    target.x = (Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0f, 1))).x;
                    locked = true;
                    columnPosition++;
                }
                else if (columnPosition == 3)
                {
                    Instantiate(MovingRightWind, new Vector3(transform.position.x - 0.5f, transform.position.y), transform.rotation);
                    target.x = (Camera.main.ViewportToWorldPoint(new Vector3(0.7f, 0f, 1))).x;
                    locked = true;
                    columnPosition++;
                }
                else if (columnPosition == 4)
                {
                    Instantiate(MovingRightWind, new Vector3(transform.position.x - 0.5f, transform.position.y), transform.rotation);
                    target.x = (Camera.main.ViewportToWorldPoint(new Vector3(0.9f, 0f, 1))).x;
                    locked = true;
                    columnPosition++;
                }
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
    public IEnumerator disableShipMovementForLevel2()
    {
        yield return new WaitForSeconds(2.0f);
        movementDisabled = true;
        level1EndMovement = false;
    }
    public IEnumerator disableShipMovementForLevel3()
    {
        yield return new WaitForSeconds(2.0f);
        movingToCenter = true;
        movementDisabled = true;
        level2EndMovement = false;
    }

    public IEnumerator disableShipMovementForEndGame()
    {
        yield return new WaitForSeconds(2.0f);
        movingToCenter = true;
        movementDisabled = true;
        endGameMovement = false;
    }
}