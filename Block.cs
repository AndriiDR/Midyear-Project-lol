using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    public Sprite[] sprites = new Sprite[6];
    private bool swit = false;
    private int basev;

	// Use this for initialization
	void Start () {
        if (this.gameObject.tag == "RedBloc")
        {
            basev = 0;
        }
        else if (this.gameObject.tag == "BlueBloc")
        {
            basev = 2;
        }
        else
        {
            basev = 4;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void switchPhase()
    {
        if (swit == false)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[basev-1];
            swit = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = sprites[basev + 1];
            swit = false;
        }
    }
}
