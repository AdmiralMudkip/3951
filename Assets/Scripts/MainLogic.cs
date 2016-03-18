using UnityEngine;

public class MainLogic : MonoBehaviour {
    private GameObject lockPivot;
    private GameObject pickPivot;
    private int sweetSpotWidth = 45;
    private int sweetSpotAngle = 90;
	// Use this for initialization
	void Start () {
        lockPivot = GameObject.Find("LockPivot");
        pickPivot = GameObject.Find("PickPivot");
    }
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Abs(Mathf.DeltaAngle(lockPivot.transform.eulerAngles.z, 0)) > (90 + sweetSpotWidth / 2 - Mathf.Abs(Mathf.DeltaAngle(pickPivot.transform.eulerAngles.z, sweetSpotAngle))))
        {
            lockPivot.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else if (Mathf.Abs(Mathf.DeltaAngle(lockPivot.transform.eulerAngles.z, 0)) >= 90)
        {
            sweetSpotAngle = Random.Range(0, 360);
        }
    }
}
