using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour {

    public Canvas DeathCanvas;

    void Awake()
    {
        //for the situation where we need more canvases
    }

    public void RetryOn()
    {
        SceneManager.LoadScene("Some level", LoadSceneMode.Single); //need to change this
    }

    public void ReturnOn()
    {
        SceneManager.LoadScene("LevelSelect", LoadSceneMode.Single);
    }

}
