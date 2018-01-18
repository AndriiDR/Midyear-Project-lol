using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D rb;

    //public Animator anim;

    public GameManager gm;

    private float maxSpeed;

    private bool possible;
    private bool carry;

    private GameObject contact;


    // Use this for initialization
    void Start()
    {
        maxSpeed = 5f;
        possible = false;
        carry = false;
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
        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y.Equals(0f))
        {
            //anim.SetBool("Jump", true);
            rb.AddRelativeForce(Vector2.up * 450f);
			if(Input.GetKeyDown(KeyCode.Space){
				rb.AddRelativeForce(Vector2.up * 450f);
			}
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

        //Actions
        //Throws
        if (Input.GetKeyDown(KeyCode.S) && carry == true)
        {
            contact.GetComponent<Knuckles>().Thrown();
            if (transform.localScale.x == 1)
            {
                contact.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * 1000f);
            }
            else
            {
                contact.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.left * 1000f);
            }
            contact = null;
            carry = false;
        }
        else if (Input.GetKeyDown(KeyCode.S) && Input.GetKey(KeyCode.A) && carry == true)
        {
            contact.GetComponent<Knuckles>().Thrown();
            contact.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * 1000f);
            contact = null;
            carry = false;
        }

        //Pick Up
        if (Input.GetKeyDown(KeyCode.S) && possible == true && contact != null)
        {
            print("ok");
            contact.GetComponent<Knuckles>().Lifted(this.gameObject);
            possible = false;
            carry = true;
        }


        



    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            print("Not ok");
            gm.Death();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Safe") && carry == false)
        {
            possible = true;
            contact = other.transform.parent.gameObject;
        }
        
    }

    
}