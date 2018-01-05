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
        SceneManager.LoadScene("LevelSelect", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
