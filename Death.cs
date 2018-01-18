using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour {

    public Canvas DeathCanvas;
    private Vector3 DSPosition;
    //public Camera camera;

    void Awake()
    {
        //for the situation where we need more canvases
    }

    private void Start()
    {
        DeathCanvas.enabled = true;
        DSPosition = DeathCanvas.transform.position;
        GetComponent<Camera>().transform.position = DSPosition;
    }

    public void RetryOn()
    {
        DeathCanvas.enabled = false; //need to change this
    }

    public void ReturnOn()
    {
        SceneManager.LoadScene("LevelSelect", LoadSceneMode.Single);
    }

}
