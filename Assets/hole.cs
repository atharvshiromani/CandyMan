using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hole : MonoBehaviour
{
    public GameObject hole1;
    //public GameObject cM;
    public Sprite hide;
    public Sprite show;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D col;

    // Start is called before the first frame update
    void Start()
    {
        hole1.GetComponent<BoxCollider2D>().enabled = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = show;
        }
    }

    // Update is called once per frame
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("J key was pressed");
            ChangeSprite();
            Invoke("Respawn", 5);
           
           
        }
    }




    void ChangeSprite()
    {
        if (spriteRenderer.sprite == show)
        {
            spriteRenderer.sprite = hide;
            hole1.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    void Respawn()
    {
        if (spriteRenderer.sprite == hide)
        {
            spriteRenderer.sprite = show;
            hole1.GetComponent<BoxCollider2D>().enabled = true;
            
        }
        //  Debug.Log("Now feeding Dog");

    }
 
   
}
