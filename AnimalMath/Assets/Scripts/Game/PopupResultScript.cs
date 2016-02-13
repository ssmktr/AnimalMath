using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PopupResultScript : MonoBehaviour {
	private GameScript m_sGame = null;

	public void SetManager(GameScript manager){
		m_sGame = manager;
	}
	public void Init(){
		GameData.SetBtn (this.transform, "BtnExit", "Press", this);
	}
	void Press(GameObject oBtn){
		if ("BtnExit" == oBtn.name) {
			Destroy (this.gameObject);
			SceneManager.LoadScene ("Main");
		}
	}
	void Start () {
	}
	void Update () {
	}
}
