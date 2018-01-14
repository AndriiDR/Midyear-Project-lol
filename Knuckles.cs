using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knuckles : MonoBehaviour {

    private bool grounded;
    public int maxSpeed = 2;
    public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        grounded = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (grounded)
        {
            rb.AddRelativeForce(Vector2.right * 30f);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ENDPLATFORMTAG")) {
            rb.velocity = -rb.velocity;
            transform.localScale.x.Equals(-transform.localScale.x);
        }

        if (!grounded && other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
