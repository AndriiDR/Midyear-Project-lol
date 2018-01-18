using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door1 : MonoBehaviour {

	void Start () {	}
	void Update () {}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.CompareTag("Player")){
			SceneManager.LoadScene("Level2", LoadSceneMode.Single);
		}
	}
}
