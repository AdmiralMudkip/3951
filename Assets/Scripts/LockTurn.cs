using UnityEngine;
using System.Collections;

public class LockTurn : MonoBehaviour {

    public float speed = 90;
    public float resetspeed = 120;
    
    void Start ()
    {
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A) && (transform.eulerAngles.z < 90 || transform.eulerAngles.z > 359))
        {
            transform.Rotate(Vector3.forward, speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) && (transform.eulerAngles.z > 270 || transform.eulerAngles.z < 1))
        {
            transform.Rotate(Vector3.back, speed * Time.deltaTime);
        }
        else if (transform.eulerAngles.z < 359 && transform.eulerAngles.z >= 269)
        {
            transform.Rotate(Vector3.forward, resetspeed * Time.deltaTime);
        }
        else if (transform.eulerAngles.z > 1 && transform.eulerAngles.z <= 91)
        {
            transform.Rotate(Vector3.back, resetspeed * Time.deltaTime);
        }
    }
}
