using Fusion.Sockets;
using Fusion;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkRunnerController : MonoBehaviour,INetworkRunnerCallbacks
{
    [SerializeField] private NetworkRunner networkRunner;

    private NetworkRunner networkRunnerInstance;


    public async void StartGame(GameMode mode, string room)
    {
        if(networkRunnerInstance == null)
        {
            networkRunnerInstance = Instantiate(networkRunner);
        }

        networkRunnerInstance.AddCallbacks(this);

        var StartGameArgs = new StartGameArgs()
        {
            GameMode = mode,
            SessionName = room,
            PlayerCount = 2,
            SceneManager = networkRunnerInstance.GetComponent<INetworkSceneManager>()

        };

        var result = await networkRunnerInstance.StartGame(StartGameArgs);

        if(result.Ok)
        {
            LobbyUIManager.Instance.StatusCheck("Connection Successfully!");
            networkRunnerInstance.SetActiveScene("Multiplayer");
        }
        else
        {
            LobbyUIManager.Instance.StatusCheck($"Failed to start: {result.ShutdownReason}");
            Debug.LogError($"Failed to start: {result.ShutdownReason}");
        }
    }














    public void OnConnectedToServer(NetworkRunner runner)
    {
        Debug.Log("OnConnectedToServer");
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
        Debug.Log("OnConnectFailed");
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
        Debug.Log("OnConnectRequest");
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
        Debug.Log("OnCustomAuthenticationResponse");
    }

    public void OnDisconnectedFromServer(NetworkRunner runner)
    {
        Debug.Log("OnDisconnectedFromServer");
    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
        Debug.Log("OnHostMigration");
    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
        Debug.Log("OnInput");
    }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
        Debug.Log("OnInputMissing");
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        Debug.Log("OnPlayerJoined");
        
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        Debug.Log("OnPlayerLeft");
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
    {
        Debug.Log("OnReliableDataReceived");
    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {
        Debug.Log("OnSceneLoadDone");
    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {
        Debug.Log("OnSceneLoadStart");
    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
        Debug.Log("OnSessionListUpdate");
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
        Debug.Log("OnShutdown");
        const String SCENE_NAME = "Lobby";
        SceneManager.LoadScene(SCENE_NAME);
    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
        Debug.Log("OnUserSimulationMessage");
    }
}
