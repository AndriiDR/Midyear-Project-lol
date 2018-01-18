using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour {
	private Player player;

	public GameManager gm;

	private GameObject spring;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		JumpSpring(
	}

	private void JumpSpring(Collider2D other){
		if (other.gameObject.CompareTag("Player"){
			player.rb.AddRelativeForce(Vector2.up * 1100f);
		}
	}
}
