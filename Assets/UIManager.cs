using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI scoreText;
    public GameObject creditPanel;
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void OpenGameCredits()
    {
        creditPanel.SetActive(true);
    }

    public void CloseGameCredits()
    {
        creditPanel.SetActive(false); 
    }
}
