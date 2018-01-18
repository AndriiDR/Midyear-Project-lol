using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {

	public GameObject target;
	public float xPos; //If the player passes this then she will be followed
	private bool isFollow;
	
	void Start () {
		isFollow = false;
	}
	
	void Update () {
		if(isFollow){
			transform.position = Vector2.MoveTowards(transform.position, target.transform.position, Time.deltaTime * 2);
		}
		else if(target.transform.position.x>=xPos){
			isFollow = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.CompareTag("Player")){
			print("ghostCollision");
			// Insert player death
		}
	}
}
