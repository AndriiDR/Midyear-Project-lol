using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLv3 : MonoBehaviour {
	
	public GameManager gm;
	public GameObject brain;
	public GameObject goldPigeon;
	public float maxY; //I put 2
	public float maxX; //I put -6
	private float minY;
	private float minX;
	private int pigeonCount = 0;
	
	
	// Use this for initialization
	void Start () {
		minY = maxY-6;
		minX = maxX-6;
	}
	
	// Update is called once per frame
	void Update () {
		if(pigeonCount>=7){
			float brainX = brain.transform.position.x;
			brain.GetComponent<Brain>().enabled = false;
			brain.transform.position = new Vector3(brainX, maxY-3, 0);
			for(int i=0; i<20; i++){
				Instantiate(goldPigeon, new Vector3(brainX, 4, 0), transform.rotation);
			}
			this.gameObject.SetActive(false);
			/****** INSERT WINNING *******/
		}
		
		if(Input.GetKeyDown(KeyCode.D)&&transform.position.x<maxX){
			transform.position += new Vector3(3, 0, 0);
		}
		if(Input.GetKeyDown(KeyCode.A)&&transform.position.x>minX){
			transform.position += new Vector3(-3, 0, 0);
		}
		if(Input.GetKeyDown(KeyCode.W)&&transform.position.y<maxY){
			transform.position += new Vector3(0, 3, 0);
		}
		if(Input.GetKeyDown(KeyCode.S)&&transform.position.y>minY){
			transform.position += new Vector3(0, -3, 0);
		}
	}
	
	private void OnCollisionEnter2D(Collision2D other){
		print("collision");
		if(other.gameObject.CompareTag("Enemy")){
			gm.Death();
			this.gameObject.SetActive(false);
		}
		else if(other.gameObject.CompareTag("Pet")){
			Destroy(other.gameObject);
		}
		else if(other.gameObject.CompareTag("Magic")){
			Destroy(other.gameObject);
			pigeonCount++;
			print(pigeonCount);
		}
	}
}
