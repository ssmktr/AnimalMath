using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using LitJson;

public class PanelReadyScript : PanelBaseScript
{

	private Dictionary<string, Transform> dicStage = new Dictionary<string, Transform>();

	void Awake()
	{
		PanelItemSlotScript.OnEffectSelected += OnEffectSelected;
		PanelItemSlotScript.OnMathSelected += OnMathSelected;
		PanelItemSlotScript.OnPassiveSelected += OnPassiveSelected;

	}
	public override void OnInit ()
	{
		GameData.SetBtn (this.transform, "BtnEasy", "Press", this);
		GameData.SetBtn (this.transform, "BtnNormal", "Press", this);
		GameData.SetBtn (this.transform, "BtnHard", "Press", this);
		GameData.SetBtn (this.transform, "BtnGameStart", "Press", this);
		GameData.SetBtn (this.transform, "BtnClose", "Press", this);
		//for Skill
		GameData.SetBtn (this.transform, "SlotEffect", "Press", this);
		GameData.SetBtn (this.transform, "SlotMath", "Press", this);
		GameData.SetBtn (this.transform, "SlotPassive", "Press", this);

		dicStage.Add("BtnEasy", this.transform.FindChild("BtnEasy"));
		dicStage.Add("BtnNormal", this.transform.FindChild("BtnNormal"));
		dicStage.Add("BtnHard", this.transform.FindChild("BtnHard"));
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
			EditorSceneManager.LoadScene("Game");
		} else if (oBtn.name == "BtnClose"){
			m_sManager.SetScene(SceneState.Main);
		} else if (oBtn.name == "SlotEffect"){
//			Debug.Log("effect");
		} else if (oBtn.name == "SlotMath"){
//			Debug.Log("math");
		} else if (oBtn.name == "SlotPassive"){
//			Debug.Log("Passive");
		}
	}

	void CheckData()
	{
		PlayerData data = GameManager.Instance.playerData;

//		Debug.Log("{0}{1}{2}{3}",data.eEffect.ToString(), data.eMath.ToString(), data.ePassive.ToString(),data.eStageLevel.ToString());

		Debug.Log(data.eEffect.ToString() + data.eMath.ToString() + data.ePassive.ToString() + data.ePlayerType.ToString() + data.eStageLevel.ToString());

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

	void OnEffectSelected(string name)
	{
		Debug.Log(name);
		this.transform.FindChild("SlotEffect").GetComponentInChildren<UILabel>().text = name;

		if (name == "Effect1") {
			GameManager.Instance.playerData.eEffect = EffectSkillState.Accuracy;	
		} else if(name == "Effect2"){
			GameManager.Instance.playerData.eEffect = EffectSkillState.Bomb;
		} else if(name == "Effect3"){
			GameManager.Instance.playerData.eEffect = EffectSkillState.RoseOfWinds;
		}
	}
	void OnMathSelected(string name)
	{
		this.transform.FindChild("SlotMath").GetComponentInChildren<UILabel>().text = name;
		if (name == "MathEffect1") {
			GameManager.Instance.playerData.eMath = MathSkillState.Clock;	
		} else if(name == "MathEffect2"){
			GameManager.Instance.playerData.eMath = MathSkillState.Book;
		} else if(name == "MathEffect3"){
			GameManager.Instance.playerData.eMath = MathSkillState.Key;
		}
	}
	void OnPassiveSelected(string name)
	{
		this.transform.FindChild("SlotPassive").GetComponentInChildren<UILabel>().text = name;
		if (name == "Passive1") {
			GameManager.Instance.playerData.ePassive = PassiveSkillState.Heart;	
		} else if(name == "Passive2"){
			GameManager.Instance.playerData.ePassive = PassiveSkillState.Chect;
		} else if(name == "Passive3"){
			GameManager.Instance.playerData.ePassive = PassiveSkillState.MedalRibon;
		}
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
