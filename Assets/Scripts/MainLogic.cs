using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class MainLogic : MonoBehaviour
{
    // these are set from within the editor and don't need to be initialized here
    public GameObject lockPivot;
    public GameObject pickPivot;
    public Text Score;
    public Text Timer;

    float speed = 90;
    float resetspeed = 120;
    float clampangle;

    int sweetSpotWidth = 10;
    int sweetSpotAngle = 90;

    int timerStartValue = 60;
    int score = 0;

    float nextPickAt;
    float gameEndAt;
    float pickStress;

    Vector3 zeroVector = new Vector3(0, 0, 0);

    NetworkClient client;
    // Use this for initialization
    void Start()
    {
        clampangle = resetspeed / 60;

        gameEndAt = Time.time + timerStartValue;
        nextPickAt = Time.time;

        /*if (MainMenu.client != null)
        {
            client = MainMenu.client;
            client.RegisterHandler(PICK_MSG_TYPES.lockpicked, resetOtherEndPosition);
            client.RegisterHandler(PICK_MSG_TYPES.win, OnWin);
            client.RegisterHandler(PICK_MSG_TYPES.lose, OnLose);
            client.RegisterHandler(PICK_MSG_TYPES.restart, OnRestart);
            client.RegisterHandler(PICK_MSG_TYPES.quit, OnQuit);
            return;
        }
        NetworkServer.RegisterHandler(PICK_MSG_TYPES.lockpicked, resetOtherEndPosition);
        NetworkServer.RegisterHandler(PICK_MSG_TYPES.win, OnWin);
        NetworkServer.RegisterHandler(PICK_MSG_TYPES.lose, OnLose);
        NetworkServer.RegisterHandler(PICK_MSG_TYPES.restart, OnRestart);
        NetworkServer.RegisterHandler(PICK_MSG_TYPES.quit, OnQuit);*/
    }

    public void restart()
    {
        score = 0;
        Score.text = "Score: 0";
        gameEndAt = Time.time + timerStartValue;
        nextPickAt = Time.time;
    }

    public void menu()
    {
        SceneManager.LoadScene("Main");
    }

    void lockPicked()
    {
        sweetSpotAngle = 270 + Random.Range(0, 180);// set new hidden angle
        lockPivot.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));// reset lockpick
        Score.text = "Score: " + ++score;// set text
    }

    void Update()
    {
        if (gameEndAt > Time.time)// time still remaining
        {
            Timer.text = "Time remaining: " + (int)(gameEndAt - Time.time);// update timer
            if (Time.time > nextPickAt)
            {
                float pickRotation = Mathf.DeltaAngle(Mathf.Atan2(Input.mousePosition.y - Camera.main.WorldToScreenPoint(pickPivot.transform.position).y, Camera.main.WorldToScreenPoint(pickPivot.transform.position).x - Input.mousePosition.x) * Mathf.Rad2Deg - 90, 0);
                // checks to see if the pick is at the boundaries, clamp it's rotation
                if (pickRotation > 90)
                {
                    pickRotation = 90;
                }
                else if (pickRotation < -90)
                {
                    pickRotation = -90;
                }

                // get the lock's current rotation
                float lockRotation = Mathf.DeltaAngle(lockPivot.transform.eulerAngles.z, 0);
                // get the distance between the sweetspot and the current rotation to calculate how far the lock can turn
                float maximumLockRotation = Mathf.Max(0, 90 + sweetSpotWidth / 2 - Mathf.Abs(Mathf.DeltaAngle(pickRotation, sweetSpotAngle)));

                // turning too much, lockpick isn't close enough
                if (Mathf.Abs(lockRotation) > maximumLockRotation)
                {
                    pickStress += 3 * Time.deltaTime;
                    if (pickStress > 1)
                    {
                        nextPickAt = 1 + Time.time;// pick becomes available in 1 sec
                        pickStress = 0;
                        lockPivot.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));// set it out of bounds completely
                    }
                    pickRotation += Random.Range(-3, 3);// shake the lockpick

                    if (Mathf.Abs(lockRotation) < clampangle)
                        lockPivot.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                    else
                        lockPivot.transform.Rotate(Vector3.forward, resetspeed * Time.deltaTime * Mathf.Sign(lockRotation) + Random.Range(-3, 3));
                }
                else
                {
                    // rotating the lock based on keypresses
                    if (Input.GetKey(KeyCode.A))
                        lockPivot.transform.Rotate(Vector3.forward, speed * Time.deltaTime);
                    else if (Input.GetKey(KeyCode.D))
                        lockPivot.transform.Rotate(Vector3.back, speed * Time.deltaTime);
                    else
                    {
                        if (pickStress > 0)
                            pickStress -= Time.deltaTime;
                        if (Mathf.Abs(lockRotation) < clampangle)
                            lockPivot.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                        else
                            lockPivot.transform.Rotate(Vector3.forward, resetspeed * Time.deltaTime * Mathf.Sign(lockRotation));
                    }
                }
                pickPivot.transform.rotation = Quaternion.Euler(new Vector3(0, 0, pickRotation));
                if (Mathf.Abs(lockRotation) >= 90)
                {
                    lockPicked();
                }
            }
            else
            {
                pickPivot.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
            }
        }
    }

    public class PICK_MSG_TYPES
    {
        public static short lockpicked = 201;
        public static short restart = 202;
        public static short win = 203;
        public static short lose = 204;
        public static short quit = 205;
    }
    public class ScoreMessage : MessageBase
    {
        int i;
        public ScoreMessage(int a)
        {
            i = a;
        }
    }
}