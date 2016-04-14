using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class MainLogic : MonoBehaviour {
    public GameObject lockPivot;
    public GameObject pickPivot;
    public Text Score;
    public Text Timer;

    public float speed;
    public float resetspeed;
    public float clampangle;

    private int sweetSpotWidth;
    private int sweetSpotAngle;

    int timerStartValue;
    int score;

    float nextPickAt;
    float gameEndAt;
    float pickStress;

    NetworkManager m;
    // Use this for initialization
    void Start() {
        speed = 90;
        resetspeed = 120;
        clampangle = resetspeed / 60;

        sweetSpotWidth = 10;
        sweetSpotAngle = 90;

        timerStartValue = 60;

        restart();
    }

    public void restart() {
        score = 0;
        Score.text = "Score: 0";
        gameEndAt = Time.time + timerStartValue;
        nextPickAt = Time.time;
    }

    public void menu() {
        SceneManager.LoadScene("Main");
    }

    void lockPicked() {
        sweetSpotAngle = 270 + Random.Range(0, 180);
        lockPivot.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        Score.text = "Score: " + ++score;
    }

    void Update() {
        if (gameEndAt > Time.time)
        {
            Timer.text = "Time remaining: " + (int)(gameEndAt - Time.time);
            if (Time.time > nextPickAt)
            {
                float pickRotation = Mathf.DeltaAngle(Mathf.Atan2(Input.mousePosition.y - Camera.main.WorldToScreenPoint(pickPivot.transform.position).y, Camera.main.WorldToScreenPoint(pickPivot.transform.position).x - Input.mousePosition.x) * Mathf.Rad2Deg - 90, 0);
                if (pickRotation > 90)
                    pickRotation = 90;
                if (pickRotation < -90)
                    pickRotation = -90;

                float lockRotation = Mathf.DeltaAngle(lockPivot.transform.eulerAngles.z, 0);
                float maximumLockRotation = Mathf.Max(0, 90 + sweetSpotWidth / 2 - Mathf.Abs(Mathf.DeltaAngle(pickRotation, sweetSpotAngle)));

                if (Mathf.Abs(lockRotation) > maximumLockRotation)
                {
                    pickStress += 3 * Time.deltaTime;
                    if (pickStress > 1)
                    {
                        nextPickAt = 1 + Time.time;
                        pickStress = 0;
                        lockPivot.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                    }
                    pickRotation += Random.Range(-3, 3);
                    if (Mathf.Abs(lockRotation) < clampangle)
                        lockPivot.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                    else
                        lockPivot.transform.Rotate(Vector3.forward, resetspeed * Time.deltaTime * Mathf.Sign(lockRotation) + Random.Range(-3, 3));
                }
                else {
                    if (Input.GetKey(KeyCode.A))
                        lockPivot.transform.Rotate(Vector3.forward, speed * Time.deltaTime);
                    else if (Input.GetKey(KeyCode.D))
                        lockPivot.transform.Rotate(Vector3.back, speed * Time.deltaTime);
                    else {
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
            else {
                pickPivot.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
            }
        }
    }
}