using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {
	public Canvas LevelSelectCanvas;

	void Awake() {
	//for the situation where we need more canvases
	}

	public void LevelOneOn() {
		SceneManager.LoadScene("Level1", LoadSceneMode.Single);
	}
	public void LevelTwoOn() {
		//SceneManager.LoadScene("Level2", LoadSceneMode.Single);
	}
	public void LevelThreeOn() {
		//SceneManager.LoadScene("Level3", LoadSceneMode.Single);
	}
	public void BackOn() {
		SceneManager.LoadScene("TitleScreen", LoadSceneMode.Single);
	}


}
