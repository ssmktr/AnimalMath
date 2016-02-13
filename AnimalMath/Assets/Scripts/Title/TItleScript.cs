using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TItleScript : MonoBehaviour {

	void Start () {
		GameManager.Instance.bGameLogin = true;
		LoadData ();
		GameData.SetBtn (this.transform, "Back", "Press", this);
	}
	void Update () {
	}
	void Press(GameObject oBtn){
		if ("Back" == oBtn.name) {
			SceneManager.LoadScene ("Main");
		}
	}
	void LoadData(){
		DataManager.Instance.LoadData();
	}
}
