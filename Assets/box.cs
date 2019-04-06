using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    public GameObject hole1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.Q))
        {
            hole1.GetComponent<BoxCollider2D>().enabled = false;
            Invoke("Respawn", 5);
        }
    }
    void Respawn()
    {


        hole1.GetComponent<BoxCollider2D>().enabled = true;

    }
}
