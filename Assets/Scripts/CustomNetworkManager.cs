using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CustomNetworkManager : NetworkManager {

    string currentMessage;

	// Use this for initialization
	void Start () {
	
	}

    NetworkManager netManager;

    void Awake()
    {
        netManager = NetworkManager.singleton;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    new void StartServer()
    {
        netManager.StartServer();
    }
    void OnServerConnect()
    {

    }



    new void StartClient()
    {
        netManager.StartClient();
    }

    void SendMessage()
    {
        if (string.IsNullOrEmpty(currentMessage.Trim()))
            return;

        //CmdChatMessage(currentMessage);
        currentMessage = "";
    }

    /*[Command]
    void CmdChatMessage(string message)
    {
        RpcReceiveChatMessage(message);
    }

    

    [ClientRpc]
    void RpcReceiveChatMessage(string message)
    {
        // this will be called on the client
    }*/

}
