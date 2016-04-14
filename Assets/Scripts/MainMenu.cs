using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System;
using System.Collections;


/// <summary>
/// Authors: Jason Burns, Markus Linseisen, Naseem Hammoud.
/// 
/// This is an attempt at a networked game, copying Skyrim and Bethesda's 
/// 'lockpicking' minigame.  It was supposed to be networked, but unfortunately we were 
/// not able to acheive this component of the game.
/// </summary>
public class MainMenu : MonoBehaviour
{
    InputField IP;
    Text t;
    Button b;
    public static NetworkClient client;

    int i;

    void Start()
    {
        t = GameObject.Find("test").GetComponent<Text>();
        b = GameObject.Find("testingbutton").GetComponent<Button>();
    }


    public void testClick()
    {
        string myIp = new System.Net.WebClient().DownloadString(@"http://icanhazip.com").Trim();
        t.text = myIp.ToString();
    }


    public void StartSinglePlayer()
    {
        SceneManager.LoadScene(1);
    }

    public void StartMultiPlayerHost()
    {
        t.text = "Server started, waiting for connection.";

        //NetworkServer.Listen(8888);
        //NetworkServer.RegisterHandler(500, clientconnection);

        //SceneManager.LoadScene(1);
    }
    public void StartMultiplayerConnect()
    {
        //client.Connect("127.0.0.1", 8888);
        //if (client.isConnected)
        //{
        //    Client.send(500, new tempMsg());    
        //    SceneManager.LoadScene(1);
        //}

        //SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
