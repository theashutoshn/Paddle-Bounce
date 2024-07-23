using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                LoadGame();
            }

        }

        if(Input.GetMouseButtonDown(0))
        {
            LoadGame();
        }
        
    }

    void LoadGame()
    {
        SceneManager.LoadScene(1);    
    }
}
