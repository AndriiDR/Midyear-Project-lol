using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour {
	
	public float speed = 5;
	public float yLimit = -6;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y <= yLimit){
			Destroy(this.gameObject);
		}
		else{
			transform.Translate(-Vector3.up * speed * Time.deltaTime);
		}
	}
}
