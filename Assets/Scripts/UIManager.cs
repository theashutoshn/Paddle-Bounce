using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI aiScoreText;
    public GameObject creditPanel;
    public GameObject winPanel;
    public GameObject loosePanel;
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void PlayerScoreUpdate(int score)
    {
        playerScoreText.text = score.ToString();
    }
    
    public void AIScoreUpdate(int score)
    {
        aiScoreText.text = score.ToString();
    }



    public void OpenGameCredits()
    {
        creditPanel.SetActive(true);
    }

    public void CloseGameCredits()
    {
        creditPanel.SetActive(false); 
    }


    public void WinPanel()
    {
        loosePanel.SetActive(false);
        winPanel.SetActive(true);
    }

    public void LoosePanel()
    {
        winPanel.SetActive(false);
        loosePanel.SetActive(true);
    }
}
