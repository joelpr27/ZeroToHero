using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class MultiplayerMenu : NetworkBehaviour
{
    public NetworkManager networkManager;

    public void Host()
    {
        networkManager.StartHost();
    }

    public void Client()
    {
        networkManager.StartClient();
    }
}
