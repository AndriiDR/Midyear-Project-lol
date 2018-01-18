using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour {

    public Canvas DeathCanvas;
    private Scene scene;


    void Awake()
    {
        //for the situation where we need more canvases
    }

    private void Start()
    {      
		scene = SceneManager.GetActiveScene(); //records current scene
    }

    public void RetryOn()
    {
        SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
    }

    public void ReturnOn()
    {
        SceneManager.LoadScene("LevelSelect", LoadSceneMode.Single);
    }

}
