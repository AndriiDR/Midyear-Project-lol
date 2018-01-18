using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour {

	public GameObject player;
	public GameObject bg; //background
	private Vector3 offset;
	private Vector3 bgoffset;

	void Start () {
		offset = transform.position - player.transform.position;
		bgoffset = bg.transform.position - transform.position;
	}
	
	void Update () {
		
	}
	
	void LateUpdate(){
		transform.position = player.transform.position + offset;
		bg.transform.position = transform.position + bgoffset;
	}
}
