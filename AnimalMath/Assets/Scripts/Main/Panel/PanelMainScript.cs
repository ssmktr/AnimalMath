using UnityEngine;
using System.Collections;

public class PanelMainScript : PanelBaseScript {

	// Use this for initialization
	public override void OnInit ()
	{
		GameData.SetBtn(this.transform, "BtnGameReady","Press", this);
		GameData.SetBtn(this.transform, "BtnOption", "Press", this);
	}
	void Start () {
		
	}

	public override void OnPress(GameObject oBtn){
		if (oBtn.name == "BtnGameReady") {
			m_sManager.SetScene(SceneState.GameReady);
		} else if (oBtn.name == "BtnOption") {
			
		}
	}
	void onOption()
	{
		
	}
	// Update is called once per frame
	void Update () {
	}
}
