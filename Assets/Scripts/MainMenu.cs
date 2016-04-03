using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEditor.SceneManagement;

using System.Collections;

public class MainMenu : MonoBehaviour
{
    
    public Button startButton, quitButton, startServerButton, connectServerButton;
    
    //static SceneManager Instance;
    NetworkManager manager;

    void Awake()
    {
        DontDestroyOnLoad(manager);
    }

    void Start()
    {
        //startButton = startButton.GetComponent<Button>();
        //quitButton = quitButton.GetComponent<Button>();
        //startServerButton = startServerButton.GetComponent<Button>();
        //connectServerButton = connectServerButton.GetComponent<Button>();

        manager = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();

        manager.networkPort = 1337;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void StartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void StartMultiPlayerHost()
    {
        manager.StartServer();
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    public void StartMultiplayerConnect()
    {
        manager.networkAddress = "127.0.0.1";
        manager.StartClient();
        //something about getting the IP
        //UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}