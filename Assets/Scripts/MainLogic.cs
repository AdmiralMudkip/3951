using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour {

    public void LoadOnClick(int button)
    {
        SceneManager.LoadScene(button);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
