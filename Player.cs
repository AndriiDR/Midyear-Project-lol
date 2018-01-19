using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D rb;
    public SpriteRenderer sr;

    public Animator anim;

    public GameManager gm;

    private float maxSpeed;

    private bool possible;
    private bool carry;

    public float minY; //You have to be higher than this or you lose

    private GameObject contact;


    // Use this for initialization
    void Start()
    {
        maxSpeed = 5f;
        possible = false;
        carry = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Ground physics
        if (Input.GetKey(KeyCode.D) && rb.velocity.y.Equals(0f))
        {
            rb.AddRelativeForce(Vector2.right * 30f);
            if (sr.flipX) {
                sr.flipX = false;
            }
        }
        if (Input.GetKey(KeyCode.A) && rb.velocity.y.Equals(0f))
        {
            rb.AddRelativeForce(Vector2.left * 30f);
            if (!(sr.flipX))
            {
                sr.flipX = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.W) && rb.velocity.y.Equals(0f))
        {
            //anim.SetBool("Jump", true);
            rb.AddRelativeForce(Vector2.up * 450f);
            if (Input.GetKeyDown(KeyCode.Space)) {
                rb.AddRelativeForce(Vector2.up * 450f);
            }
        }

        if (rb.velocity.x != 0f /*&& anim.GetBool("Jump").Equals(false)*/)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
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

        if (transform.position.y < minY)
        {
            gm.Death();
            this.gameObject.SetActive(false);
        }

        //Actions
        //Throws
        if (Input.GetKeyDown(KeyCode.S) && carry == true)
        {
            contact.GetComponent<Knuckles>().Thrown();
            if (sr.flipX == false)
            {
                contact.transform.position = new Vector2(this.transform.position.x + 5.0f, this.transform.position.y + 1.0f);
                contact.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * 100.0f);
            }
            else
            {
                contact.transform.position = new Vector2(this.transform.position.x - 5.0f, this.transform.position.y + 1.0f);
                contact.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.left * 100.0f);
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Safe")) { }
        else if (other.gameObject.CompareTag("Enemy") && carry == false)
        {
            print("Not ok");
            gm.Death();
            this.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("pigeon"))
        {
            other.gameObject.GetComponent<AudioSource>().Play();
            StartCoroutine(GiveHimASecond(other));
        }
        else if (other.gameObject.CompareTag("Spikes"))
        {
            gm.Death();
            this.gameObject.SetActive(false);
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

    IEnumerator GiveHimASecond(Collision2D other)
    {
        yield return new WaitForSeconds(3);
        other.gameObject.SetActive(false);
    }


}