using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hole : MonoBehaviour
{
    public GameObject holeL;
    public GameObject holeR;
    public Sprite hide;
    public Sprite show;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D col;
    public playerMove thePlayer;


    // Start is called before the first frame update
    void Start()
    {
        holeR.GetComponent<BoxCollider2D>().enabled = true;
        holeL.GetComponent<BoxCollider2D>().enabled = true;
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
            ChangeSpriteL();
            Invoke("RespawnL", 5);
           
           
        }
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {


            ChangeSpriteR();
            Invoke("RespawnR", 5);

        }
    }

    void ChangeSpriteR()
    {
        spriteRenderer = holeR.GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = hide;
        holeR.GetComponent<BoxCollider2D>().enabled = false;

    }
    void ChangeSpriteL()
    {
        spriteRenderer = holeL.GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = hide;
        holeL.GetComponent<BoxCollider2D>().enabled = false;

    }


    void RespawnL()
    {
        if (spriteRenderer.sprite == hide)
        {

            

            holeL.GetComponent<SpriteRenderer>().sprite = show;
            holeL.GetComponent<BoxCollider2D>().enabled = true;
        }


    }
    void RespawnR()
    {

        if (spriteRenderer.sprite == hide)
        {

            holeR.GetComponent<SpriteRenderer>().sprite = show;
            holeR.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
 
   
}
