using UnityEngine;

public class PickMove : MonoBehaviour {
    private Vector3 object_pos;
    void Start () {
        object_pos = Camera.main.WorldToScreenPoint(GameObject.Find("PivotPoint").transform.position);
    }

    // Update is called once per frame
    void Update () {
        float angle = Mathf.Atan2(Input.mousePosition.y - object_pos.y, Input.mousePosition.x - object_pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle-90));
    }
}
