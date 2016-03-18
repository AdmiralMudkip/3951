using UnityEngine;

public class PickMove : MonoBehaviour {
    void Start () {
    }

    // Update is called once per frame
    void Update () {
        float angle = Mathf.Atan2(Input.mousePosition.y - Camera.main.WorldToScreenPoint(transform.position).y, Input.mousePosition.x - Camera.main.WorldToScreenPoint(transform.position).x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle-90));
    }
}
