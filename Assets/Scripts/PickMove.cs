using UnityEngine;

public class PickMove : MonoBehaviour {
    void Start () {
    }

    // Update is called once per frame
    void Update () {
        float angle = Mathf.Atan2(Input.mousePosition.y - Camera.main.WorldToScreenPoint(transform.position).y, Input.mousePosition.x - Camera.main.WorldToScreenPoint(transform.position).x) * Mathf.Rad2Deg;
        if (Mathf.DeltaAngle(angle, 0) > 90)
            angle = 180;
        else if (angle < Mathf.DeltaAngle(angle, 0))
            angle = 0;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle-90));
    }
}
