using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class change : MonoBehaviour
{
    [SerializeField] private string newLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("scoreBoard", 3);
    }

    void scoreBoard()
    {
        SceneManager.LoadScene(newLevel);

    }
}
