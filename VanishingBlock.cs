using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishingBlock : MonoBehaviour {

	public GameObject block;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.CompareTag("Player")){
			StartCoroutine(UtterDestruction());
		}
	}
	
	IEnumerator UtterDestruction(){
		yield return new WaitForSeconds(1);
		block.SetActive(false);
		yield return new WaitForSeconds(5);
		block.SetActive(true);
	}
}
