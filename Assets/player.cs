using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sr;
    private float speed = 3f;
    // Start is called before the first frame update
   
    private void Awake()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    private void move()
    {
        float h = Input.GetAxis("Horizontal");
        Vector3 temp = transform.position;
        if(h > 0)
        {
            temp.x += speed * Time.deltaTime;
            sr.flipX = false;
        } else if (h < 0)
        {
            temp.x -= speed * Time.deltaTime;
            sr.flipX = true;

        } else if (h == 0)
        {

        }
        transform.position = temp;
    }
}
