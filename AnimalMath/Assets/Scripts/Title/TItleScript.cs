using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TItleScript : MonoBehaviour {

	void Start () {
		GameManager.Instance.bGameLogin = true;
<<<<<<< HEAD
		DataManager.Instance.LoadData();
=======
		LoadData ();
>>>>>>> a701e24c5d110c157f9f67c71c519c376543c117
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
