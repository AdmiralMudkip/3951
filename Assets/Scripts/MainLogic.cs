using UnityEngine;
using UnityEngine.UI;

public class MainLogic : MonoBehaviour {
    private GameObject lockPivot;
    private GameObject pickPivot;
    private int sweetSpotWidth = 10;
    private int sweetSpotAngle = 90;
    int score = 0;
    Text t;
    // Use this for initialization
    void Start() {
        lockPivot = GameObject.Find("LockPivot");
        pickPivot = GameObject.Find("PickPivot");
        t = GameObject.Find("Text").GetComponent<Text>();
    }

    void lockPicked() {
        sweetSpotAngle = 270 + Random.Range(0, 180);
        lockPivot.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        t.text = "Score: " + ++score;
    }

    void Update() {
        float pickRotation = Mathf.Atan2(Input.mousePosition.y - Camera.main.WorldToScreenPoint(pickPivot.transform.position).y, Input.mousePosition.x - Camera.main.WorldToScreenPoint(pickPivot.transform.position).x) * Mathf.Rad2Deg;
        if (Mathf.DeltaAngle(pickRotation, 0) > 90)
            pickRotation = 180;
        else if (Mathf.DeltaAngle(pickRotation, 0) > 0)
            pickRotation = 0;

        //lock rotation from start
        float lockRotation = Mathf.DeltaAngle(0, lockPivot.transform.eulerAngles.z);
        if (Mathf.Abs(lockRotation) >= 90) {
            lockPicked();
        } else {
            float allowedRotation = Mathf.Max(0, (90 + sweetSpotWidth / 2 - Mathf.Abs(Mathf.DeltaAngle(pickPivot.transform.eulerAngles.z, sweetSpotAngle))));
            if (allowedRotation < Mathf.Abs(lockRotation)) {
                lockPivot.transform.rotation = Quaternion.Euler(new Vector3(0, 0, allowedRotation * Mathf.Sign(lockRotation)));
                pickRotation += Random.Range(-3, 3);
            }
        }
        pickPivot.transform.rotation = Quaternion.Euler(new Vector3(0, 0, pickRotation - 90));
    }
}