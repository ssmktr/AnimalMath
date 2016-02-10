using UnityEngine;
using System.Collections;

public class PanelMainScript : PanelBaseScript {

	// Use this for initialization
	public override void OnInit ()
	{
		GameData.SetBtn(this.transform, "BtnGameReady","Press", this);
	}
	void Start () {
		
	}

	public override void OnPress(GameObject oBtn){
		if (oBtn.name == "BtnGameReady") {
			m_sManager.SetScene(SceneState.GameReady);
		}
	}

	// Update is called once per frame
	void Update () {
	}
}
