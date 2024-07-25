using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConnectionManager : MonoBehaviour
{
    [SerializeField] private NetworkRunner _networkRunnerPrefab;

    private NetworkRunner _runner;
    void Start()
    {
        InitializeNetworkRunner();
    }

    private async void InitializeNetworkRunner()
    {
        if(_runner == null)
        {
            _runner = Instantiate(_networkRunnerPrefab);
            
        }
        await _runner.StartGame(new StartGameArgs()
        {
            GameMode = GameMode.AutoHostOrClient,
            SceneManager = _runner.GetComponent<NetworkSceneManagerDefault>()
        });

        SceneManager.LoadScene("Lobby");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
