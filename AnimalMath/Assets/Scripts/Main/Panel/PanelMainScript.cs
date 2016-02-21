using UnityEngine;
using System.Collections;

public class PanelMainScript : PanelBaseScript {

	Transform oBG;
	Transform oEffect;
	private bool bIsOptionOpen = false;

	// Use this for initialization
	public override void OnInit ()
	{
		oBG = this.transform.FindChild("BG");
		oEffect = this.transform.FindChild("Effect");
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
		if(!bIsOptionOpen)
		{
			moveBtn(oBG, -110);
			moveBtn(oEffect, -220);
		} else {
			moveBtn(oBG, 110);
			moveBtn(oEffect, 220);
		}
			
		bIsOptionOpen = !bIsOptionOpen;
	}

	void moveBtn(Transform obj , float move)
	{
		TweenPosition tp = obj.GetComponent<TweenPosition>();
		tp.from = oBG.transform.position;
		tp.to = new Vector3(oBG.transform.position.x + move,oBG.transform.position.y,oBG.transform.position.z);
		tp.style = UITweener.Style.Once;        // there's also PingPong (back and forth) and Loop (when reaches end, goes back to start)
		tp.method = UITweener.Method.EaseIn;    // there's also BounceIn, BounceOut, EaseOut, etc
		//		tp.onFinished += myHandler;
		tp.duration = 1.0f;
		tp.Play();

	}

	// Update is called once per frame
	void Update () {
		
	}
}
