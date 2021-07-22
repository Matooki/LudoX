using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;
using Mirror;
using UnityEngine.SceneManagement;
using System;
using System.Linq;

public class MyNetworkManager : NetworkManager
{
    [Scene] [SerializeField] private string menuScene = string.Empty;
    [Header("Room")]
    [SerializeField] private NetworkRoomPlayerLobby roomPlayerPrefab = null;

    public static event Action OnClientConnected;
    public static event Action OnClientDisconnected;
    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        base.OnServerAddPlayer(conn);

        CSteamID steamId = SteamMatchmaking.GetLobbyMemberByIndex(SteamLobby.LobbyId, numPlayers - 1);

        var playerInfoDisplay = conn.identity.GetComponent<PlayerInfoDisplay>();

        playerInfoDisplay.SetSteamId(steamId.m_SteamID);

        if (SceneManager.GetActiveScene().name == menuScene)
        {
            NetworkRoomPlayerLobby roomPlayerInstance = Instantiate(roomPlayerPrefab);
            NetworkServer.AddPlayerForConnection(conn, roomPlayerInstance.gameObject);
        }
    }

    public override void OnStartServer() => spawnPrefabs = Resources.LoadAll<GameObject>("SpawnablePrefabs").ToList(); 
    

    public override void OnStartClient()
    {
        var spawnPrefabs = Resources.LoadAll<GameObject>("SpawnablePrefabs");
        foreach (var prefab in spawnPrefabs)
        {
            NetworkClient.RegisterPrefab(prefab);
        }
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);

        OnClientConnected?.Invoke();
    }

    public override void OnClientDisconnect(NetworkConnection conn)
    {
        base.OnClientDisconnect(conn);

        OnClientDisconnected?.Invoke();
    }

    public override void OnServerConnect(NetworkConnection conn)
    {
        if (numPlayers >= maxConnections)
        {
            conn.Disconnect();
            return;
        }
        if (SceneManager.GetActiveScene().name != menuScene) 
        {
            conn.Disconnect();
            return;
        }
    }

    

}
