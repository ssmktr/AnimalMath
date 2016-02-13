using UnityEngine;
using System.Collections;

public class PanelMainScript : PanelBaseScript {

	Transform oBG;
	Transform oEffect;
	private bool bIsOptionOpen = false;

	// Use this for initialization
	public override void OnInit ()
	{
		oBG = this.transform.FindChild("BtnOption").FindChild("BG") as Transform;
		oEffect = this.transform.FindChild("BtnOption").FindChild("Effect") as Transform;
		GameData.SetBtn(this.transform, "BtnGameReady","Press", this);
		GameData.SetBtn(this.transform, "BtnOption", "Press", this);
	}
	void Start () {
		
	}

	public override void OnPress(GameObject oBtn){
		if (oBtn.name == "BtnGameReady") {
			m_sManager.SetScene(SceneState.GameReady);
		} else if (oBtn.name == "BtnOption") {
			onOption();
		}
	}
	void onOption()
	{
		StartCoroutine(openOption());
	}

	IEnumerator openOption()
	{
		bIsOptionOpen = !bIsOptionOpen;
		oBG.transform.position = new Vector3(oBG.transform.position.x - 50,
			oBG.transform.position.y,
			oBG.transform.position.z);
		oEffect.transform.position = new Vector3(oEffect.transform.position.x - 25,
			oEffect.transform.position.y,
			oEffect.transform.position.z);
		yield return new WaitForSeconds(0.5f);
	}

	// Update is called once per frame
	void Update () {
	}
}
