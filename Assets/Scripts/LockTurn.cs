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
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward, speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back, speed * Time.deltaTime);
        }
        else if (Mathf.DeltaAngle(transform.eulerAngles.z,0) > 0)
        {
            transform.Rotate(Vector3.forward, speed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(Vector3.back, speed * Time.deltaTime);
        }

    }
}
