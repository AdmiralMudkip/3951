using UnityEngine;

public class MainLogic : MonoBehaviour {
    private GameObject lockPivot;
    private GameObject pickPivot;
    private int sweetSpotWidth = 10;
    private int sweetSpotAngle = 90;
    // Use this for initialization
    void Start() {
        lockPivot = GameObject.Find("LockPivot");
        pickPivot = GameObject.Find("PickPivot");
    }

    void lockPicked() {
        sweetSpotAngle = 270 + Random.Range(0, 180);
        lockPivot.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    void Update() {
        float angle = Mathf.Atan2(Input.mousePosition.y - Camera.main.WorldToScreenPoint(pickPivot.transform.position).y, Input.mousePosition.x - Camera.main.WorldToScreenPoint(pickPivot.transform.position).x) * Mathf.Rad2Deg;
        if (Mathf.DeltaAngle(angle, 0) > 90)
            angle = 180;
        else if (angle < Mathf.DeltaAngle(angle, 0))
            angle = 0;
        pickPivot.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

        //lock rotation from start
        float lockRotation = Mathf.DeltaAngle(0, lockPivot.transform.eulerAngles.z);
        if (Mathf.Abs(lockRotation) >= 90) {
            lockPicked();
        } else {
            float allowedRotation = Mathf.Max(0, (90 + sweetSpotWidth / 2 - Mathf.Abs(Mathf.DeltaAngle(pickPivot.transform.eulerAngles.z, sweetSpotAngle))));
            if (allowedRotation < Mathf.Abs(lockRotation)) {
                lockPivot.transform.rotation = Quaternion.Euler(new Vector3(0, 0, allowedRotation * Mathf.Sign(lockRotation)));
            }
        }
    }
}