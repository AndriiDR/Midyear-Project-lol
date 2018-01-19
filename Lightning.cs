using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {
	
	public float speed = 5;
	public float xLimit = -13;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x <= xLimit){
			Destroy(this.gameObject);
		}
		else{
			transform.Translate(-Vector3.right * speed * Time.deltaTime);
		}
	}
}
