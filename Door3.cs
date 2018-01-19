using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door3 : MonoBehaviour {

	public Canvas VictoryCanvas;

	void Start () {	}
	void Update () {}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.CompareTag("Player")){
			VictoryCanvas.enabled = true;
		}
	}
}
