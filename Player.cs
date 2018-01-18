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
    private GameObject contact;
	private Animator anim;
	private bool limitjump = true;


    // Use this for initialization
    void Start()
    {
        maxSpeed = 5f;
        possible = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Ground physics
        if (Input.GetKey(KeyCode.D) && rb.velocity.y.Equals(0f))
        {
            rb.AddRelativeForce(Vector2.right * 30f);
        }
        if (Input.GetKey(KeyCode.A) && rb.velocity.y.Equals(0f))
        {
            rb.AddRelativeForce(Vector2.left * 30f);
        }
        if (Input.GetKeyDown(KeyCode.W) && (rb.velocity.y.Equals(0f)||limitjump==false))
        {
            //anim.SetBool("Jump", true);
            rb.AddForce(Vector2.up * 450f);
        }

        if (rb.velocity.y.Equals(0f))
        {
            //anim.SetBool("Jump", false);
        }
        else
        {
            //anim.SetBool("Jump", true);
        }

        if (rb.velocity.x > 0f /*&& anim.GetBool("Jump").Equals(false)*/)
        {
            anim.SetBool("Run", true);
        }
        if (rb.velocity.x == 0f)
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

        //Actions
        
		/*
		if (Input.GetKey(KeyCode.S) && possible == true && contact == null)
        {
            print("ok");
            contact.GetComponent<Knuckles>().Lifted(this.gameObject);
        }
        else if (Input.GetKey(KeyCode.S) && contact != null)
        {
            contact.GetComponent<Knuckles>().Thrown();
            contact = null;
        }
		*/


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            print("Not ok");
            gm.Death();
        }
		else if(other.gameObject.CompareTag("pigeon")){
			limitjump = false;
			other.gameObject.GetComponent<AudioSource>().Play();
			StartCoroutine(GiveHimASecond(other));
		}
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Safe"))
        {
            print("ok");
            possible = true;
            contact = other.transform.parent.gameObject;
        }
        else
        {
            possible = false;
            contact = null;
        }
    }
	
	IEnumerator GiveHimASecond(Collider2D other){
		yield return new WaitForSeconds(3);
		other.gameObject.SetActive(false);
	}

    
}
