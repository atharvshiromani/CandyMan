using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Death"))
        {
            Invoke("die", 4.5f);
        }

    }

    

    void die()
    {
        gameObject.GetComponent<EnemyAI>().respawn();
    }
}
