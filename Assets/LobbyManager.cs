using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Fusion.Sockets;
using System;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    [SerializeField] private NetworkRunner _runner;
    [SerializeField] private Button _createRoomButton;
    [SerializeField] private Button _joinRoomButton;
    [SerializeField] private TMP_InputField _roomNameInput;
    [SerializeField] private SceneRef _gameSceneName;
    [SerializeField] private TextMeshProUGUI _statusText;
    [SerializeField] private GameObject _playerPrefab;



    void Start()
    {
        _createRoomButton.onClick.AddListener(CreateRoom);
        _joinRoomButton.onClick.AddListener(JoinRoom);
    }

    private async void CreateRoom()
    {
        SetStatus("Creating room...");
        await InitializeNetworkRunner(GameMode.Host, _roomNameInput.text);
    }

    private async void JoinRoom()
    {
        SetStatus("Joining room...");
        await InitializeNetworkRunner(GameMode.Client, _roomNameInput.text);
    }

    private async System.Threading.Tasks.Task InitializeNetworkRunner(GameMode mode, string roomName)
    {
        if (string.IsNullOrEmpty(roomName))
        {
            roomName = "Room" + UnityEngine.Random.Range(0, 10000);
        }

        _runner = gameObject.AddComponent<NetworkRunner>();
        _runner.ProvideInput = true;

        var startGameArgs = new StartGameArgs()
        {
            GameMode = mode,
            SessionName = roomName,
            Scene = _gameSceneName,
            SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>()
        };

        try
        {
            var result = await _runner.StartGame(startGameArgs);
            if (!result.Ok)
            {
                SetStatus($"Failed to start: {result.ShutdownReason}");
                Debug.LogError($"Failed to start: {result.ShutdownReason}");
            }
            else
            {
                SetStatus("Connected successfully!");
                _runner.AddCallbacks(new NetworkCallbacks(_playerPrefab));
            }
        }
        catch (Exception e)
        {
            SetStatus($"Error: {e.Message}");
            Debug.LogError($"Error starting game: {e}");
        }
    }

    private void SetStatus(string status)
    {
        if (_statusText != null)
        {
            _statusText.text = status;
        }
        Debug.Log(status);
    }

    private void OnDisable()
    {
        if (_runner != null)
        {
            _runner.Shutdown();
        }
    }


}

