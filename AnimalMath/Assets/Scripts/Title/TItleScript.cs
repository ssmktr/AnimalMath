﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TItleScript : MonoBehaviour {

	void Start () {
		GameData.SetBtn (this.transform, "Back", "Press", this);
	}
	void Update () {
	}
	void Press(GameObject oBtn){
		if ("Back" == oBtn.name) {
			SceneManager.LoadScene ("Main");
		}
	}
}
