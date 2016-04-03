using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Networking;

public class NetTest : NetworkBehaviour
{
    int d = 0;

    public int SendMessageToServer(int i)
    {
        CmdsendToServer(i);
        return d;
    }
    public int SendMessageToClient(int i)
    {
        RpcSendToClient(i);
        return d;
    }

    [Command]
    void CmdsendToServer(int data)
    {
        d = data;
    }
    
    [ClientRpc]
    void RpcSendToClient(int data)
    {
        d = data;
    }
}