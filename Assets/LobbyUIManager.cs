using Fusion;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUIManager : MonoBehaviour
{
    public static LobbyUIManager Instance;

    [SerializeField] private Button createRoomButton;
    //[SerializeField] private Button joinRoomButton;
    [SerializeField] private TMP_InputField roomNameInput;
    [SerializeField] private TextMeshProUGUI statusText;


    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateRoom()
    {
        if (roomNameInput.text.Length > 2)
        {
            StatusCheck("Creating Room...");
            GlobalManager.Instance.networkRunnerController.StartGame(GameMode.Host, roomNameInput.text);       
        }
    }

    public void JoinRoom()
    {
        if(roomNameInput.text.Length > 2)
        {
            StatusCheck("Joining Room...");
            GlobalManager.Instance.networkRunnerController.StartGame(GameMode.Client, roomNameInput.text);
        }
    }

    public void StatusCheck(string status)
    {
        if(statusText != null)
        {
            statusText.text = status;
        }
    }
}
