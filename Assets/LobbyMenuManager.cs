using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;
using Steamworks;

public class LobbyMenuManager : NetworkBehaviour
{
    [SerializeField] private MyNetworkManager networkManager = null;

    [Header("UI")]
    [SerializeField] private GameObject landingPagePanel = null;
        public void StartGame()
    {
        SceneManager.LoadScene("Ludo");
    }

    public void HostLobby()
    {
        networkManager.StartHost();
        landingPagePanel.SetActive(false);
    }
}
