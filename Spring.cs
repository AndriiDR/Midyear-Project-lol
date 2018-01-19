using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour {
	//public Player player;

	//public GameManager gm;

	private GameObject spring;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //JumpSpring(player.GetComponent<Collider2D>());
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag("Player")){
			//print ("pls");
			other.rigidbody.AddForce(transform.up * 1100f);
		}
	}
}
