using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    InputField IP;
    Text t;
    Button b;
    int i;
    NetworkManager netManager;
    NetTest n;

    void Awake()
    {
        DontDestroyOnLoad(netManager);
        netManager = NetworkManager.singleton;
    }

    void Start()
    {
        n = new NetTest();
        t = GameObject.Find("test").GetComponent<Text>();
        b = GameObject.Find("testingbutton").GetComponent<Button>();
        netManager = NetworkManager.singleton;
        //IP = connectServerButton.GetComponent<InputField>();        
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void testClick()
    {
        i++;
        int z = 0;
        if (Network.isClient)
            z = n.SendMessageToServer(i);
        
        if (Network.isServer)
            z = n.SendMessageToClient(i);

        t.text = z.ToString();
    }


    public void StartSinglePlayer()
    {
        SceneManager.LoadScene(1);
    }

    public void StartMultiPlayerHost()
    {
        netManager.StartServer();
        t.text = "Server started, waiting for connection.";


        //SceneManager.LoadScene(1);
    }
    public void StartMultiplayerConnect()
    {

        netManager.networkAddress = "127.0.0.1";
        netManager.StartClient();

        //t.text = "Connected to server";

        
        //SceneManager.LoadScene(1);
    }


    
}

