using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject pauseGame1;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GamePaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        pauseGame1.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }
    void Pause()
    {
        pauseGame1.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }
}
