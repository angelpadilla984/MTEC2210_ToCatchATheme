using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour

{
    public AudioClip coinClip;
    public AudioClip hazardClip;

    public GameManager gm;
    public float speed = 15;
    public float jumpSpeed = 1;
    private Rigidbody2D rb;

    bool jumping;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal");

        //Debug.Log("xMove:" + xMove);
        transform.Translate(xMove * speed * Time.deltaTime, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumping = true;
        }

    }

    // private void OnCollisionEnter2D(Collision2D collision)
    //{
    //  Debug.Log("Collided");

    //}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Coin")
        {
            gm.IncrementScore(1);

            gm.PlaySound(coinClip);
            Destroy(collider.gameObject);
        }

        if (collider.tag == "Hazard")
        {
            gm.PlaySound(hazardClip);
            Destroy(gameObject);
        }

        if (collider.tag == "Theme")
        {
            Destroy(collider.gameObject);
            Debug.Log("Theme Changed");
        }
    }
    private void FixedUpdate()
    {
            if (Input.GetKey(KeyCode.A))
            {
                rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
            }

            if (Input.GetKey(KeyCode.D))
            {
                rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
            }

            if (jumping == true)
            {
                rb.velocity = Vector2.up * jumpSpeed;
                jumping = false;
            }
    
    }
}


    