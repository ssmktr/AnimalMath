using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PopupPauseScript : MonoBehaviour {
	private GameScript m_sGame = null;

	public void SetManager(GameScript manager){
		m_sGame = manager;
	}
	public void Init(){
		GameData.SetBtn (this.transform, "BtnContinue", "Press", this);
		GameData.SetBtn (this.transform, "BtnExit", "Press", this);
	}
	void Press(GameObject oBtn){
		if ("BtnContinue" == oBtn.name) {
			m_sGame.CameraResume (true);
			m_sGame.SetPause (false);
			Destroy (this.gameObject);
		} else if ("BtnExit" == oBtn.name) {
			Destroy (this.gameObject);
			SceneManager.LoadScene ("Main");
		}
	}
	void Start () {
	}
	void Update () {
	}
}
