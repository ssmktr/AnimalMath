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
		GameObject oBtnGameReady = this.transform.FindChild ("BtnGameReady").gameObject;
		oBtnGameReady.transform.FindChild ("Label").GetComponent<UILabel> ().text = GameData.LocalizeText ("GameReady");
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
		TweenPosition tp = new TweenPosition();
		tp.from = oBG.transform.position;
		tp.to = new Vector3(oBG.transform.position.x -50,oBG.transform.position.y,oBG.transform.position.z);
		tp.style = UITweener.Style.Once;        // there's also PingPong (back and forth) and Loop (when reaches end, goes back to start)
		tp.method = UITweener.Method.EaseIn;    // there's also BounceIn, BounceOut, EaseOut, etc
//		tp.onFinished += myHandler;
		tp.duration = 0.5f;
//		StartCoroutine(openOption());
	}

	IEnumerator openOption()
	{
		bIsOptionOpen = !bIsOptionOpen;
		oBG.transform.Translate(new Vector3(oBG.transform.position.x - 50,
			oBG.transform.position.y,
			oBG.transform.position.z));
		oEffect.transform.Translate(new Vector3(oEffect.transform.position.x - 25,
			oEffect.transform.position.y,
			oEffect.transform.position.z));
		Debug.Log("coroution IN");
		yield return new WaitForSeconds(1.0f);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
