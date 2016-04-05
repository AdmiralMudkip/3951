using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerScript : MonoBehaviour {
    float timeLeft = 30;
    int timerr = 0;
    Text text;
    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.deltaTime != 0)
            timeLeft -= Time.deltaTime;
        text.text = "Time remaining: " + timerr;
    }
}
