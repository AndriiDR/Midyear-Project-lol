using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour {

	public float[] yPositions = new float[3]{-4, -1, 2};
	public GameObject bolt;
	
	void Start () {		
		InvokeRepeating("BrainStuff", 0, 2); //calls method every two seconds
	}
	
	void Update () {
		
	}
	
	void BrainStuff(){
		int i = Random.Range(0, yPositions.Length); //randomly chooses y-position for brain
		transform.position = new Vector3(transform.position.x, yPositions[i], 0); //brain moves
		Instantiate(bolt, transform.position, transform.rotation);
	}
}
