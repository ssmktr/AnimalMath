using UnityEngine;
using System.Collections;

public class PopupGoldWaringScript : MonoBehaviour {


	void Awake(){
		GameData.SetBtn (this.transform, "BtnOk", "Press", this);
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Press(GameObject obj)
	{
		if (obj.name == "BtnOk") {
			Debug.Log ("name");
			Destroy (this.gameObject);
		}

	}

}
