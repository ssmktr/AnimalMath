using UnityEngine;
using System;
using System.Collections;
using UnityEditor.SceneManagement;

public class PanelReadyScript : PanelBaseScript
{
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

	}
		
	public override void OnPress (GameObject oBtn)
	{
		if (oBtn.name == "BtnEasy") {
			Debug.Log ("easy");
		} else if (oBtn.name == "BtnNormal") {
			Debug.Log ("Normal");
		} else if (oBtn.name == "BtnHard") {
			Debug.Log ("Hard");
		} else if (oBtn.name == "BtnGameStart") {
			Debug.Log ("Start");
			EditorSceneManager.LoadScene("Game");
		} else if (oBtn.name == "BtnClose"){
			m_sManager.SetScene(SceneState.Main);
		} else if (oBtn.name == "SlotEffect"){
			Debug.Log("effect");
		} else if (oBtn.name == "SlotMath"){
			Debug.Log("math");
		} else if (oBtn.name == "SlotPassive"){
			Debug.Log("Passive");
		}
	}

	void OnEffectSelected(string name)
	{
		Debug.Log(name);
		this.transform.FindChild("SlotEffect").GetComponentInChildren<UILabel>().text = name;

	}
	void OnMathSelected(string name)
	{
		this.transform.FindChild("SlotMath").GetComponentInChildren<UILabel>().text = name;
	}
	void OnPassiveSelected(string name)
	{
		this.transform.FindChild("SlotPassive").GetComponentInChildren<UILabel>().text = name;
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
