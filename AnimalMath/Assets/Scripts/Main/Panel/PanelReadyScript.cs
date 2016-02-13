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
	private Dictionary<string, Transform> dicStage = new Dictionary<string, Transform>();
	private Dictionary<string, Transform> dicSlot = new Dictionary<string, Transform>();

	void Awake()
	{
		

	}
	public override void OnInit ()
	{
		itemSlotScript = this.transform.GetComponentInChildren<PanelItemSlotScript>();
		spriteEffect = this.transform.FindChild("SlotEffect").transform.FindChild("Sprite").GetComponent<UISprite>();
		spriteMath = this.transform.FindChild("SlotMath").transform.FindChild("Sprite").GetComponent<UISprite>();
		spritePassive = this.transform.FindChild("SlotPassive").transform.FindChild("Sprite").GetComponent<UISprite>();

		PanelItemSlotScript.OnEffectSelected += OnEffectSelected;
		PanelItemSlotScript.OnMathSelected += OnMathSelected;
		PanelItemSlotScript.OnPassiveSelected += OnPassiveSelected;

		Debug.Log("PanelReadyScript : OnInit");
		GameData.SetBtn (this.transform, "BtnEasy", "Press", this);
		GameData.SetBtn (this.transform, "BtnNormal", "Press", this);
		GameData.SetBtn (this.transform, "BtnHard", "Press", this);
		GameData.SetBtn (this.transform, "BtnGameStart", "Press", this);
		GameData.SetBtn (this.transform, "BtnClose", "Press", this);
		//for Skill
		GameData.SetBtn (this.transform, "SlotEffect", "Press", this);
		GameData.SetBtn (this.transform, "SlotMath", "Press", this);
		GameData.SetBtn (this.transform, "SlotPassive", "Press", this);


		if(dicStage.Count > 0)
		{
			InitLevel();
			InitButtons();
		}
//		Debug.Log("BeforeinitDic" + dicStage.Count);
		if(dicStage.Count > 0) return;
//		Debug.Log("initDic" + dicStage.Count);
		dicStage.Add("BtnEasy", this.transform.FindChild("BtnEasy"));
		dicStage.Add("BtnNormal", this.transform.FindChild("BtnNormal"));
		dicStage.Add("BtnHard", this.transform.FindChild("BtnHard"));

		dicSlot.Add("SlotEffect", this.transform.FindChild("SlotEffect"));
		dicSlot.Add("SlotMath", this.transform.FindChild("SlotMath"));
		dicSlot.Add("SlotPassive", this.transform.FindChild("SlotPassive"));
		InitLevel();
		InitButtons();
	}
		
	public override void OnPress (GameObject oBtn)
	{
		if (oBtn.name == "BtnEasy") {
//			Debug.Log ("easy");
			LevelSelected(oBtn.name);
		} else if (oBtn.name == "BtnNormal") {
//			Debug.Log ("Normal");
			LevelSelected(oBtn.name);
		} else if (oBtn.name == "BtnHard") {
//			Debug.Log ("Hard");
			LevelSelected(oBtn.name);
		} else if (oBtn.name == "BtnGameStart") {
//			Debug.Log ("Start");
			CheckData();
			SceneManager.LoadScene("Game");
		} else if (oBtn.name == "BtnClose"){
			m_sManager.SetScene(SceneState.Main);
		} else if (oBtn.name == "SlotEffect"){
//			Debug.Log("effect");
			RemoveEffectItem();
		} else if (oBtn.name == "SlotMath"){
//			Debug.Log("math");
			RemoveMathItem();
		} else if (oBtn.name == "SlotPassive"){
//			Debug.Log("Passive");
			RemovePassiveItem();
		}
	}

	void InitButtons()
	{
		RemoveEffectItem();
		RemoveMathItem();
		RemovePassiveItem();
	}
	public void InitLevel()
	{
		dicStage["BtnEasy"].GetComponent<UISprite>().spriteName = "BtnGreen";
		dicStage["BtnNormal"].GetComponent<UISprite>().spriteName = "BtnGreen";
		dicStage["BtnHard"].GetComponent<UISprite>().spriteName = "BtnGreen";
		switch (GameManager.Instance.playerData.eStageLevel) {
		case StageLevel.Easy :
			dicStage["BtnEasy"].GetComponent<UISprite>().spriteName = "BtnRed";
			break;
		case StageLevel.Normal :
			dicStage["BtnNormal"].GetComponent<UISprite>().spriteName = "BtnRed";
			break;
		case StageLevel.Hard :
			dicStage["BtnHard"].GetComponent<UISprite>().spriteName = "BtnRed";
			break;
		default:
			break;
		}

	}
	void ResetReadyData()
	{
		GameManager.Instance.playerData = new PlayerData();
	}


	void RemoveEffectItem()
	{
		Debug.Log("EffectSetNone");
		itemSlotScript.ResetEffectButton();
		GameManager.Instance.playerData.Effect = new SkillData();
//		this.transform.FindChild("SlotEffect").transform.FindChild("Sprite").gameObject.SetActive(false);
		spriteEffect.alpha = 0.0f;
	}
	void RemoveMathItem()
	{
		Debug.Log("MathSetNone");	
		itemSlotScript.ResetMathButton();
		GameManager.Instance.playerData.Math = new SkillData();
		spriteMath.alpha = 0.0f;
//		this.transform.FindChild("SlotMath").transform.FindChild("Sprite").gameObject.SetActive(false);
	}
	void RemovePassiveItem()
	{
		Debug.Log("passiveSetNone");
		itemSlotScript.ResetPassiveButton();
		GameManager.Instance.playerData.Passive = new SkillData();
		spritePassive.alpha = 0.0f;
//		this.transform.FindChild("SlotPassive").transform.FindChild("Sprite").gameObject.SetActive(false);
	}
	void CheckData()
	{
		PlayerData data = GameManager.Instance.playerData;

		Debug.Log(data.Effect.Name.ToString() + "/"+ data.Math.Name.ToString() + "/"+ data.Passive.Name.ToString() + "/"+ 
			data.ePlayerType.ToString() + "/"+ data.eStageLevel.ToString());
	}

	void LevelSelected(string name)
	{
		if(dicStage[name] != null){
			foreach (Transform item in dicStage.Values) {
				item.GetComponent<UISprite>().spriteName = "BtnGreen";
			}
			this.transform.FindChild(name).GetComponent<UISprite>().spriteName = "BtnRed";
			if(name == "BtnEasy"){
				GameManager.Instance.playerData.eStageLevel = StageLevel.Easy;	
			}else if (name == "BtnNormal") {
				GameManager.Instance.playerData.eStageLevel = StageLevel.Normal;
			} else if (name == "BtnHard") {
				GameManager.Instance.playerData.eStageLevel = StageLevel.Hard;
			}
		}
	}

	void OnEffectSelected(SkillState state)
	{
		SetSlot(state, spriteEffect);
	}
	void OnMathSelected(SkillState state)
	{
		SetSlot(state, spriteMath);
	}
	void OnPassiveSelected(SkillState state)
	{
		SetSlot(state, spritePassive);
	}
	void SetSlot(SkillState state, UISprite sprite)
	{
		sprite.spriteName = state.ToString();
		sprite.color = Color.black;
//		sprite.gameObject.SetActive(true);
		sprite.alpha = 1.0f;
//		sprite.localSize = new Vector2(50,50);
		sprite.width = 50;
		sprite.height = 50;
		GameManager.Instance.playerData.Passive = DataManager.Instance.dicSkillData[state];
	}
	public override void OnExit ()
	{
		
	}



	void Start ()
	{
	}

	void Update ()
	{
	}
}
