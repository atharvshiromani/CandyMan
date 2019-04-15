using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newlevl : MonoBehaviour
{
    [SerializeField] private string newLevel;
    [SerializeField] private string scoreboard;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(scoreboard);
            Invoke("scoreBoard", 5);
        }
    }

    private void scoreBoard()
    {
        SceneManager.LoadScene(newLevel);
    }
}
