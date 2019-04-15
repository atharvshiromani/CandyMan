using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    private hole hole1;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;
    private float speed = 3f;
    private float spd;
    public float distance;
    private float inputVertical;
    private float inputHorizontal;
    
    private bool isclimbing;
    public GameObject destroyedItem;
    public bool onLadder;
    public float climbSpeed;
    private float climbVelocity;
    private float gravityScore;
    public GameObject thingbeingdestroyed;
    public bool inbox;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gravityScore = rb.gravityScale;
    }
    void Awake()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
      
        Move();
      


    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.tag.Equals("Enemy"))
        {
            Destroy(gameObject);
           


        }
               
    }

  




    void Move()
    {
       
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        if (inputHorizontal < 0)
        {
            sr.flipX = true;
        }
        if (inputHorizontal > 0)
        {
            sr.flipX = false;
        }
        rb.velocity = new Vector2(inputHorizontal * speed, rb.velocity.y);
        if (onLadder)
        {
            rb.gravityScale = 0f;
            climbVelocity = climbSpeed * Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, climbVelocity);
        }
        if (!onLadder)
        {
            rb.gravityScale = gravityScore;
        }
    }
}
