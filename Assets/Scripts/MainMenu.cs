using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

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
        startButton = startButton.GetComponent<Button>();
        quitButton = quitButton.GetComponent<Button>();
        startServerButton = startServerButton.GetComponent<Button>();
        connectServerButton = connectServerButton.GetComponent<Button>();

        // manager = new NetworkManager();

        //manager.networkPort = 1337;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void StartLevel()
    {
       //SceneManager.LoadScene(1);
    }

    public void StartMultiPlayerHost()
    {
        manager.StartServer();
        //SceneManager.LoadScene(1);
    }
    public void StartMultiplayerConnect()
    {
        manager.networkAddress = "127.0.0.1";
        manager.StartClient();
       // SceneManager.LoadScene(1);
    }
}