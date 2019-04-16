using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    [SerializeField] private string mainmenu;

    public GameObject pausemenu, resumemenu;
    // Start is called before the first frame update
    private void Start()
    {
        Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
           
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Resume();

        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();

        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            mainMenu();

        }

    }

   public void Pause()
    {
        pausemenu.SetActive(true);

        Time.timeScale = 0;
    }
   public void Resume()
    {
        pausemenu.SetActive(false);

        Time.timeScale = 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void mainMenu()
    {
        SceneManager.LoadScene(mainmenu);
        Time.timeScale = 1;

    }
}
