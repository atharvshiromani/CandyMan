using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hole : MonoBehaviour
{
    private GameObject hole1;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
    /*    if (Input.GetKeyDown(KeyCode.Q))
        {

            Destroy(gameObject);
        }*/

    }

  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
        }*/
    }
}
