using UnityEngine;
using System.Collections;
using SmartLocalization;

public class PanelMainScript : PanelBaseScript
{

	Transform tBG;
	Transform tEffect;
	Transform tLanguage;
	UILabel gold;
	OptionData optionData;
	private bool bIsOptionOpen = false;

	// Use this for initialization
	public override void OnInit ()
	{
		tBG = this.transform.FindChild ("BtnBG");
		tEffect = this.transform.FindChild ("BtnEffect");
		tLanguage = this.transform.FindChild("BtnLanguage");
		optionData = GameManager.Instance.optionData;
		GameData.SetBtn (this.transform, "BtnBG", "Press", this);
		GameData.SetBtn (this.transform, "BtnEffect", "Press", this);
		GameData.SetBtn (this.transform, "BtnLanguage", "Press", this);
		GameData.SetBtn (this.transform, "BtnGameReady", "Press", this);
		GameData.SetBtn (this.transform, "BtnOption", "Press", this);
		GameObject oBtnGameReady = this.transform.FindChild ("BtnGameReady").gameObject;
		gold = this.transform.FindChild("Gold").GetComponentInChildren<UILabel>();
		GameData.SetLanguage(GameManager.Instance.optionData.Language);
//		oBtnGameReady.transform.FindChild ("Label").GetComponent<UILabel> ().text = GameData.LocalizeText ("GameReady");
		InitMainUI();
//		SetLanguage();
	}

	void Start ()
	{
		
	}

	// Update is called once per frame
	void Update ()
	{

	}

	public override void OnPress (GameObject oBtn)
	{
		if (oBtn.name == "BtnGameReady") {
			m_sManager.SetScene (SceneState.GameReady);
		} else if (oBtn.name == "BtnOption") {
			Debug.Log("BtnOptionClick");
			OnOption();
		} else if (oBtn.name == "BtnBG") {
			Debug.Log("BtnBGClick");
			SetSoundBG();
		} else if (oBtn.name == "BtnEffect") {
			Debug.Log("BtnEffectClick");
			SetSoundEffect();
		} else if (oBtn.name == "BtnLanguage") {
			Debug.Log("BtnLanguageClick");
			SetLanguage();
		}
	}

	void InitMainUI ()
	{
		gold.text = "Gold : " + GameManager.Instance.optionData.Gold.ToString();
		InitOptionIcon();
	}
	void InitOptionIcon()
	{
		tBG.transform.FindChild("Icon").GetComponent<UISprite>().spriteName = optionData.SoundBG ? "BtnIconBGOn" : "BtnIconBGOff";
		tEffect.transform.FindChild("Icon").GetComponent<UISprite>().spriteName = optionData.SoundEffect ? "BtnIconEffectOn" : "BtnIconEffectOff";
	}
	void SetLanguage()
	{
		if("ko" == optionData.Language){
			optionData.Language = "en";
			GameData.SetLanguage("en");
			Debug.Log("language to english");
		} else{
			optionData.Language = "ko";
			GameData.SetLanguage("ko");
			Debug.Log("language to korea");
		}
	}

	void SetSoundBG()
	{
		tBG.transform.FindChild("Icon").GetComponent<UISprite>().spriteName = optionData.SoundBG ? "BtnIconBGOff" : "BtnIconBGOn";
		optionData.SoundBG = !optionData.SoundBG;
	}
	void SetSoundEffect()
	{
		tEffect.transform.FindChild("Icon").GetComponent<UISprite>().spriteName = optionData.SoundEffect ? "BtnIconEffectOff" : "BtnIconEffectOn";
		optionData.SoundEffect = !optionData.SoundEffect;
	}

	void OnOption ()
	{
		if (!bIsOptionOpen) {
			MoveBtn (tBG, -130);
			MoveBtn (tEffect, -260);
			MoveBtn (tLanguage, -390);
			Debug.Log("open option");
		} else {
			MoveBtn (tBG, 130);
			MoveBtn (tEffect, 260);
			MoveBtn (tLanguage, 390);
			Debug.Log("close option");
			GameManager.Instance.optionData = optionData;
			GameManager.Instance.SaveOptionData();
		}

		bIsOptionOpen = !bIsOptionOpen;
	}

	void MoveBtn (Transform obj, int move)
	{
		obj.transform.localPosition = new Vector3(obj.transform.localPosition.x + move, obj.transform.localPosition.y, obj.transform.localPosition.y);
//		TweenPosition tp = obj.GetComponent<TweenPosition> ();
//		tp.from = oBG.transform.position;
//		tp.to = new Vector3 (oBG.transform.position.x + move, oBG.transform.position.y, oBG.transform.position.z);
//		tp.style = UITweener.Style.Once;        // there's also PingPong (back and forth) and Loop (when reaches end, goes back to start)
//		tp.method = UITweener.Method.EaseIn;    // there's also BounceIn, BounceOut, EaseOut, etc
//		//		tp.onFinished += myHandler;
//		tp.duration = 1.0f;
//		tp.Play ();

	}


}
