using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
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

    // Update is called once per frame
    void Update()
    {
        //Move();
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
        if(onLadder)
        {
            rb.gravityScale = 0f;
            climbVelocity = climbSpeed * Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, climbVelocity);
        }
        if(!onLadder)
        {
            rb.gravityScale = gravityScore;
        }
       // RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);

//        if (hitInfo.collider != null)
  //      {
    //        if (Input.GetKeyDown(KeyCode.UpArrow))
      //      {
        //        isclimbing = true;
          //  }
//        }
  //      if (isclimbing == true)
    //    {
      //      inputVertical = Input.GetAxisRaw("Vertical");
        //    rb.velocity = new Vector2(rb.position.x, inputVertical*spd);
          //  rb.gravityScale = 0;
    //    }
      //  else
     //   {
       //     rb.gravityScale = 5;
     //   }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag.Equals("Ladder"))
        {
            Move();
        }
        if (collision.gameObject.tag.Equals("Rope"))
        {
            }

    }
    


    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(h, v);
        rb.AddForce(movement * speed);
        rb.gravityScale = 0;
        //Vector3 temp = transform.position;
        //if (h > 0)
       // {
         //   temp.y += speed * Time.deltaTime;
            //sr.flipX = false;
       // }
  //      if (h < 0)
    //    {
      //      temp.y -= speed * Time.deltaTime;
            //sr.flipX = true;

      //  }
  //      if (h == 0)
    //    {
    //
      //  }
     //   transform.position = temp;
        
    }
}
