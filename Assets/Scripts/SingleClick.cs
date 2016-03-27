using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class SingleClick : MonoBehaviour {
    Button b;
	// Use this for initialization
	void Awake () {
        b = GetComponent<Button>();
        b.onClick.AddListener(StartSingle);
	}

    void StartSingle()
    {
        Debug.LogError("test");
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
