using UnityEngine;
using System.Collections;

public class LockTurn : MonoBehaviour {

    public float speed;
    public float resetspeed;
    public float clampangle;

    void Start() {
        speed = 90;
        resetspeed = 120;
        clampangle = resetspeed / 60;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(Vector3.forward, speed * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(Vector3.back, speed * Time.deltaTime);
        } else {
            float delta = Mathf.DeltaAngle(transform.eulerAngles.z, 0);
            if (Mathf.Abs(delta) < clampangle) {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            } else {
                transform.Rotate(Vector3.forward, resetspeed * Time.deltaTime * Mathf.Sign(delta));
            }
        }
    }
}
