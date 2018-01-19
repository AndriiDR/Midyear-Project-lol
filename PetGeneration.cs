using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetGeneration : MonoBehaviour {
	
	public float[] xPositions = new float[3]{-12, -9, -6};
	public GameObject[] pets = new GameObject[5];
	public float top = 5; //Height at which pets are generated
	
	void Start () {
		InvokeRepeating("GenPet", 0, 2);
	}

	void Update () {
		
	}
	
	void GenPet(){
		int petIndex = Random.Range(0, pets.Length);
		int posIndex = Random.Range(0, xPositions.Length);
		Instantiate(pets[petIndex], new Vector3(xPositions[posIndex], top, 0), transform.rotation);
	}
}
