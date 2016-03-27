using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour {

    static SceneManager Instance;
    Button b;

    void Awake()
    {
        if (Instance != null)
        {
            GameObject.Destroy(gameObject);
        }
        else
        {
            GameObject.DontDestroyOnLoad(gameObject);
            Instance = this;
        }
    }

    void Start()
    {
        Button b = GameObject.Find("SinglePlayer").GetComponent<Button>();
        b.onClick.AddListener(() => { startSinglePlayer(); });
    }
    
    void startSinglePlayer()
    {

    }

}
