using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder_appear : MonoBehaviour
{
    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    public GameObject c4;
    public GameObject c5;
   public GameObject ladder;
    public GameObject nextlevel;
    public Sprite hide;
    public Sprite show;
    private SpriteRenderer spriteRenderer;
  
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ladder.GetComponent<BoxCollider2D>().enabled = false;
        nextlevel.GetComponent<BoxCollider2D>().enabled = false;


        spriteRenderer.sprite = hide;
        
    }
    private void Update()
    {
       
        if(c1== null && c2==null && c3==null && c4==null && c5==null)
        {
            spriteRenderer.sprite = show;
            ladder.GetComponent<BoxCollider2D>().enabled = true;
            nextlevel.GetComponent<BoxCollider2D>().enabled = true;


        }
    }
}
