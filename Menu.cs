using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public Canvas MainCanvas;
    public Canvas HtPCanvas;
	
    void Awake()
    {
        HtPCanvas.enabled = false;
    }

    public void HtPOn()
    {
        HtPCanvas.enabled = true;
        MainCanvas.enabled = false;
    }

    public void ReturnOn()
    {
        HtPCanvas.enabled = false;
        MainCanvas.enabled = true;
    }

    public void LoadOn()
    {
        SceneManager.LoadScene("INSERT NAME HERE", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    void Start () {
		
	}
	
	
	void Update () {
		
	}
}
