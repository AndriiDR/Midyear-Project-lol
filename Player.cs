using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D rb;

    //public Animator anim;


    private float maxSpeed;


    // Use this for initialization
    void Start()
    {
        maxSpeed = 5f;
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Ground physics
        if (Input.GetKey(KeyCode.D) && rb.velocity.y.Equals(0f))
        {
            rb.AddRelativeForce(Vector2.right * 30f);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (Input.GetKey(KeyCode.A) && rb.velocity.y.Equals(0f))
        {
            rb.AddRelativeForce(Vector2.left * 30f);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (Input.GetKey(KeyCode.W) && rb.velocity.y.Equals(0f))
        {
            //anim.SetBool("Jump", true);
            rb.AddRelativeForce(Vector2.up * 450f);
        }

        if (rb.velocity.y.Equals(0f))
        {
            //anim.SetBool("Jump", false);
        }
        else
        {
            //anim.SetBool("Jump", true);
        }

        if (rb.velocity.x != 0f /*&& anim.GetBool("Jump").Equals(false)*/)
        {
            //anim.SetBool("Run", true);
        }
        if (rb.velocity.x == 0f)
        {
            //anim.SetBool("Run", false);
        }


        //Air physics
        if (Input.GetKey(KeyCode.D) && !(rb.velocity.y.Equals(0f)))
        {
            rb.AddRelativeForce(Vector2.right * 7.5f);
        }
        if (Input.GetKey(KeyCode.A) && !(rb.velocity.y.Equals(0f)))
        {
            rb.AddRelativeForce(Vector2.left * 7.5f);
        }

        //Max Speed
        if (rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }
        if (rb.velocity.x < -maxSpeed)
        {
            rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Trigger death and restart level 
        if (other.gameObject.CompareTag("Enemy"))
        {

        }

        if (other.gameObject.CompareTag("Switch"))
        {

        }


    }
}
