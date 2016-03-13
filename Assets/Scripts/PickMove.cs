using UnityEngine;
using System.Collections;

public class PickMove : MonoBehaviour {

    float x, y;
	void Start () {
	    x = Screen.width / 2;
        y = Screen.height / 3;
    }

    // Update is called once per frame
    void Update () {
        //transform.Rotate(new Vector3(x, y), Mathf.Tan((x / Input.mousePosition.x)));
        //Debug.Log(Input.mousePosition.x);
        //Input.mousePosition.x
    }
}
