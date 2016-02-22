using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using LitJson;

public class PanelReadyScript : PanelBaseScript
{
	private PanelItemSlotScript itemSlotScript;
	private UISprite spriteEffect;
	private UISprite spriteMath;
	private UISprite spritePassive;
	private UILabel lbGold;
	private int nTotalPrice = 0;
	private int nTempPrice = 0;
	private int nEffectPrice = 0;
	private int nMathPrice = 0;
	private int nPassivePrice = 0;
	private Dictionary<string, Transform> dicStage = new Dictionary<string, Transform> ();
	private Dictionary<string, Transform> dicSlot = new Dictionary<string, Transform> ();

	void Awake ()
	{
		

	}

	public override void OnInit ()
	{
		itemSlotScript = this.transform.GetComponentInChildren<PanelItemSlotScript> ();
		spriteEffect = this.transform.FindChild ("SlotEffect").transform.FindChild ("Sprite").GetComponent<UISprite> ();
		spriteMath = this.transform.FindChild ("SlotMath").transform.FindChild ("Sprite").GetComponent<UISprite> ();
		spritePassive = this.transform.FindChild ("SlotPassive").transform.FindChild ("Sprite").GetComponent<UISprite> ();
		lbGold = this.transform.FindChild ("Gold").GetComponentInChildren<UILabel> ();
		DontDestroyOnLoad (lbGold);

		PanelItemSlotScript.OnEffectSelected += OnEffectSelected;
		PanelItemSlotScript.OnMathSelected += OnMathSelected;
		PanelItemSlotScript.OnPassiveSelected += OnPassiveSelected;

		Debug.Log ("PanelReadyScript : OnInit");
		GameData.SetBtn (this.transform, "BtnEasy", "Press", this);
		GameData.SetBtn (this.transform, "BtnNormal", "Press", this);
		GameData.SetBtn (this.transform, "BtnHard", "Press", this);
		GameData.SetBtn (this.transform, "BtnGameStart", "Press", this);
		GameData.SetBtn (this.transform, "BtnClose", "Press", this);
		GameObject oBtnGameStart = this.transform.FindChild ("BtnGameStart").gameObject;
		oBtnGameStart.transform.FindChild ("Label").GetComponent<UILabel> ().text = GameData.LocalizeText ("GameStart");

		//for Skill
		GameData.SetBtn (this.transform, "SlotEffect", "Press", this);
		GameData.SetBtn (this.transform, "SlotMath", "Press", this);
		GameData.SetBtn (this.transform, "SlotPassive", "Press", this);

		InitGold ();
		if (dicStage.Count > 0) {
			InitLevel ();
			InitButtons ();
		}
//		Debug.Log("BeforeinitDic" + dicStage.Count);
		if (dicStage.Count > 0)
			return;
//		Debug.Log("initDic" + dicStage.Count);
		dicStage.Add ("BtnEasy", this.transform.FindChild ("BtnEasy"));
		dicStage.Add ("BtnNormal", this.transform.FindChild ("BtnNormal"));
		dicStage.Add ("BtnHard", this.transform.FindChild ("BtnHard"));

		dicSlot.Add ("SlotEffect", this.transform.FindChild ("SlotEffect"));
		dicSlot.Add ("SlotMath", this.transform.FindChild ("SlotMath"));
		dicSlot.Add ("SlotPassive", this.transform.FindChild ("SlotPassive"));
		InitLevel ();
		InitButtons ();
	}

	void Start ()
	{
	}

	void Update ()
	{
	}

	public override void OnPress (GameObject oBtn)
	{
		if (oBtn.name == "BtnEasy") {
//			Debug.Log ("easy");
			LevelSelected (oBtn.name);
		} else if (oBtn.name == "BtnNormal") {
//			Debug.Log ("Normal");
			LevelSelected (oBtn.name);
		} else if (oBtn.name == "BtnHard") {
//			Debug.Log ("Hard");
			LevelSelected (oBtn.name);
		} else if (oBtn.name == "BtnGameStart") {
//			Debug.Log ("Start");
			CheckData ();
			SaveGold ();
			SceneManager.LoadScene ("Game");
		} else if (oBtn.name == "BtnClose") {
			m_sManager.SetScene (SceneState.Main);
		} else if (oBtn.name == "SlotEffect") {
//			Debug.Log("effect");
			RemoveEffectItem ();
		} else if (oBtn.name == "SlotMath") {
//			Debug.Log("math");
			RemoveMathItem ();
		} else if (oBtn.name == "SlotPassive") {
//			Debug.Log("Passive");
			RemovePassiveItem ();
			LevelSelected(oBtn.name);
		} else if (oBtn.name == "BtnNormal") {
			LevelSelected(oBtn.name);
		} else if (oBtn.name == "BtnHard") {
			LevelSelected(oBtn.name);
		} else if (oBtn.name == "BtnGameStart") {
			CheckData();
			SaveGold();
			AdsData.PlayAds ();
		} else if (oBtn.name == "BtnClose"){
			m_sManager.SetScene(SceneState.Main);
		} else if (oBtn.name == "SlotEffect"){
			RemoveEffectItem();
		} else if (oBtn.name == "SlotMath"){
			RemoveMathItem();
		} else if (oBtn.name == "SlotPassive"){
			RemovePassiveItem();
		}
	}

	public override void OnExit ()
	{

	}

	#region INIT

	void InitGold ()
	{
		nTempPrice = GameManager.Instance.Gold;
		lbGold.text = "Gold : " + GameManager.Instance.Gold;
	}

	void InitButtons ()
	{
		RemoveEffectItem ();
		RemoveMathItem ();
		RemovePassiveItem ();
	}

	public void InitLevel ()
	{
		dicStage ["BtnEasy"].GetComponent<UISprite> ().spriteName = "BtnGreen";
		dicStage ["BtnNormal"].GetComponent<UISprite> ().spriteName = "BtnGreen";
		dicStage ["BtnHard"].GetComponent<UISprite> ().spriteName = "BtnGreen";
		switch (GameManager.Instance.playerData.eStageLevel) {
		case StageLevel.Easy:
			dicStage ["BtnEasy"].GetComponent<UISprite> ().spriteName = "BtnRed";
			break;
		case StageLevel.Normal:
			dicStage ["BtnNormal"].GetComponent<UISprite> ().spriteName = "BtnRed";
			break;
		case StageLevel.Hard:
			dicStage ["BtnHard"].GetComponent<UISprite> ().spriteName = "BtnRed";
			break;
		default:
			break;
		}

	}

	#endregion

	void ResetReadyData ()
	{
		GameManager.Instance.playerData = new PlayerData ();
	}

	void RemoveEffectItem ()
	{
		Debug.Log ("EffectSetNone");
		itemSlotScript.ResetEffectButton ();
		GameManager.Instance.playerData.Effect = new SkillData ();
//		this.transform.FindChild("SlotEffect").transform.FindChild("Sprite").gameObject.SetActive(false);
		spriteEffect.alpha = 0.0f;
		nEffectPrice = 0;
		SetGold ();
	}

	void RemoveMathItem ()
	{
		Debug.Log ("MathSetNone");	
		itemSlotScript.ResetMathButton ();
		GameManager.Instance.playerData.Math = new SkillData ();
		spriteMath.alpha = 0.0f;
		nMathPrice = 0;
		SetGold ();
//		this.transform.FindChild("SlotMath").transform.FindChild("Sprite").gameObject.SetActive(false);
	}

	void RemovePassiveItem ()
	{
		Debug.Log ("passiveSetNone");
		itemSlotScript.ResetPassiveButton ();
		GameManager.Instance.playerData.Passive = new SkillData ();
		spritePassive.alpha = 0.0f;
		nPassivePrice = 0;
		SetGold ();
//		this.transform.FindChild("SlotPassive").transform.FindChild("Sprite").gameObject.SetActive(false);
	}

	void CheckData ()
	{
		PlayerData data = GameManager.Instance.playerData;
		Debug.Log (data.Effect.Name.ToString () + "/" + data.Math.Name.ToString () + "/" + data.Passive.Name.ToString () + "/" +
		data.ePlayerType.ToString () + "/" + data.eStageLevel.ToString ());
	}

	void LevelSelected (string name)
	{
		if (dicStage [name] != null) {
			foreach (Transform item in dicStage.Values) {
				item.GetComponent<UISprite> ().spriteName = "BtnGreen";
			}
			this.transform.FindChild (name).GetComponent<UISprite> ().spriteName = "BtnRed";
			if (name == "BtnEasy") {
				GameManager.Instance.playerData.eStageLevel = StageLevel.Easy;	
			} else if (name == "BtnNormal") {
				GameManager.Instance.playerData.eStageLevel = StageLevel.Normal;
			} else if (name == "BtnHard") {
				GameManager.Instance.playerData.eStageLevel = StageLevel.Hard;
			}
		}
	}

	void OnEffectSelected (SkillState state)
	{
		int tempPrice = nEffectPrice;
		GameManager.Instance.playerData.Effect = DataManager.Instance.dicSkillData [state];
		nEffectPrice = GameManager.Instance.playerData.Effect.Price;
		if (nTempPrice + tempPrice < nEffectPrice) {
			nEffectPrice = 0;
			Debug.Log("TempPrice : " + nTempPrice);
			SetGold ();
			itemSlotScript.ResetButton(state);
			return;
		}
		SetSlot (state, spriteEffect);
		SetGold ();
	}

	void OnMathSelected (SkillState state)
	{
		int tempMathPrice = nMathPrice;
		GameManager.Instance.playerData.Math = DataManager.Instance.dicSkillData [state];
		nMathPrice = GameManager.Instance.playerData.Math.Price;
		if (nTempPrice + tempMathPrice < nMathPrice) {
			nMathPrice = 0;
			Debug.Log("TempPrice : " + nTempPrice);
			SetGold ();
			itemSlotScript.ResetButton(state);
			return;
		}
		SetSlot (state, spriteMath);
		SetGold ();
	}

	void OnPassiveSelected (SkillState state)
	{
		int tempPassivePrice = nPassivePrice;
		GameManager.Instance.playerData.Passive = DataManager.Instance.dicSkillData [state];
		nPassivePrice = GameManager.Instance.playerData.Passive.Price;
		Debug.Log ("passivePrice : " + nPassivePrice);
		if (nTempPrice + tempPassivePrice < nPassivePrice) {
			nPassivePrice = 0;
			Debug.Log("TempPrice : " + nTempPrice);
			SetGold();
//			RemovePassiveItem();
			itemSlotScript.ResetButton(state);
			return;
		}
		SetSlot (state, spritePassive);
		SetGold ();
	}

	void SetSlot (SkillState state, UISprite sprite)
	{
		sprite.spriteName = state.ToString ();
		sprite.color = Color.black;
//		sprite.gameObject.SetActive(true);
		sprite.alpha = 1.0f;
//		sprite.localSize = new Vector2(50,50);
		sprite.width = 50;
		sprite.height = 50;
	}

	#region GOLD

	void SetGold ()
	{
		nTotalPrice = GameManager.Instance.Gold; 
		nTempPrice = nTotalPrice;
		nTempPrice = nTotalPrice - (nEffectPrice + nMathPrice + nPassivePrice);
		if (nTempPrice < 0) {
			Debug.Log ("tempPriceIsLowerThan ZERO");
			nTempPrice = nTotalPrice;
			nEffectPrice = 0;
			nMathPrice = 0;
			nPassivePrice = 0;
			return;
		}
		lbGold.text = "Gold : " + nTempPrice.ToString ();	
		Debug.Log ("EffectPrice : " + nEffectPrice);
		Debug.Log ("MathPrice :" + nMathPrice);
		Debug.Log ("Passive :" + nPassivePrice);
		Debug.Log (lbGold.text);
//		nEffectPrice = 0;
//		nMathPrice = 0;
//		nPassivePrice = 0;
	}

	void SaveGold ()
	{
		GameManager.Instance.Gold = nTempPrice;//nTotalPrice - (nEffectPrice + nMathPrice + nPassivePrice);
		Debug.Log ("SaveGold : " + GameManager.Instance.Gold);
		GameManager.Instance.SaveGameDataToLocal ();
	}

	#endregion


}
