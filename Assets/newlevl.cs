using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newlevl : MonoBehaviour
{
    [SerializeField] private string newLevel;
    public GameObject lvlcomplete;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            panelnxtlvl();
            Invoke("nextlvl", 5);
        }
    }
    public void panelnxtlvl()
    {
        lvlcomplete.SetActive(true);

       // Time.timeScale = 0;
    }
    private void nextlvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
