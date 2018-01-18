using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject[] red = new GameObject[10];
    public GameObject[] blue = new GameObject[10];
    public GameObject[] green = new GameObject[10];
    public bool redon;
    public bool blueon;
    public bool greenon;
    public Canvas deathm;

    // Use this for initialization
    void Start () {
        red = GameObject.FindGameObjectsWithTag("RedBloc");
        blue = GameObject.FindGameObjectsWithTag("BlueBloc");
        green = GameObject.FindGameObjectsWithTag("GreenBloc");
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    //Death Menu
    public void Death()
    {
        //Play death sound ROBLOX DEATH SOUND
        //Wait for seconds time of death sound
        //mute all sounds
        deathm.GetComponent<Death>();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene("LevelMenu");
    }
    //End Death Menu

    //Block interactions
    public void redBlock()
    {
        if (redon == false) {
            foreach (GameObject go in red)
            {
                go.GetComponent<Block>().switchPhase();
            }
            redon = true;
        }
        if (blueon == true)
        {
            foreach (GameObject go in blue)
            {
                go.GetComponent<Block>().switchPhase();
            }
            redon = false;
        }
        else if (greenon == true)
        {
            foreach (GameObject go in green)
            {
                go.GetComponent<Block>().switchPhase();
            }
            redon = false;
        }
    }

    public void blueBlock()
    {
        if (redon == true)
        {
            foreach (GameObject go in red)
            {
                go.GetComponent<Block>().switchPhase();
            }
            redon = false;
        }
        if (blueon == false)
        {
            foreach (GameObject go in blue)
            {
                go.GetComponent<Block>().switchPhase();
            }
            redon = true;
        }
        else if (greenon == true)
        {
            foreach (GameObject go in green)
            {
                go.GetComponent<Block>().switchPhase();
            }
            redon = false;
        }
    }

    public void greenBlock()
    {
        if (redon == true)
        {
            foreach (GameObject go in red)
            {
                go.GetComponent<Block>().switchPhase();
            }
            redon = true;
        }
        if (blueon == true)
        {
            foreach (GameObject go in blue)
            {
                go.GetComponent<Block>().switchPhase();
            }
            redon = false;
        }
        else if (greenon == false)
        {
            foreach (GameObject go in green)
            {
                go.GetComponent<Block>().switchPhase();
            }
            redon = true;
        }
    }
    //End block interactions

}
