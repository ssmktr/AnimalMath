using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PanelItemSlotScript : PanelBaseScript
{

	public delegate void OnSelected (SkillState state);

	public static event OnSelected OnEffectSelected;
	public static event OnSelected OnMathSelected;
	public static event OnSelected OnPassiveSelected;


	private Dictionary<string, Transform> dicEffect = new Dictionary<string, Transform> ();
	private Dictionary<string, Transform> dicMath = new Dictionary<string, Transform> ();
	private Dictionary<string, Transform> dicPassive = new Dictionary<string, Transform> ();
	private Dictionary<SkillState, Transform> dicSkill = new Dictionary<SkillState, Transform> ();

	void Awake ()
	{
		Debug.Log ("Init");
		OnInit ();
	}

	public override void OnInit ()
	{
		Debug.Log ("PanelItemSlotScript : OnInit");

		string sEffect = "";
		string sMath = "";
		string sPassive = "";
		for (SkillState i = SkillState.Accuracy; i < SkillState.MAX; i++) {
			GameData.SetBtn (this.transform, i.ToString (), "Press", this);
			dicSkill.Add (i, this.transform.FindChild (i.ToString()));
		}
//		for (int i = 0; i < 3; i++) {
//			sEffect = string.Format("Effect{0}",i+1);
//			sMath = string.Format("MathEffect{0}",i+1);
//			sPassive = string.Format("Passive{0}",i+1);
//			Debug.Log(sEffect);
//			GameData.SetBtn(this.transform, sEffect, "Press", this);
//			GameData.SetBtn(this.transform, sMath, "Press", this);
//			GameData.SetBtn(this.transform, sPassive, "Press", this);
//			dicEffect.Add(sEffect , this.transform.FindChild(sEffect));
//			dicMath.Add(sMath, this.transform.FindChild(sMath));
//			dicPassive.Add(sPassive, this.transform.FindChild(sPassive));
//		}
	}

	public override void OnPress (GameObject oBtn)
	{
		if (oBtn.name == SkillState.Accuracy.ToString ()) {
			Debug.Log ("Effect1");
			SetEffectBtton (SkillState.Accuracy);
		} else if (oBtn.name == SkillState.Bomb.ToString ()) {
			Debug.Log ("Effect2");
			SetEffectBtton (SkillState.Bomb);
		} else if (oBtn.name == SkillState.RoseOfWinds.ToString ()) {
			Debug.Log ("Effect3");
			SetEffectBtton (SkillState.RoseOfWinds);
		} else if (oBtn.name == SkillState.Clock.ToString ()) {
			Debug.Log ("MathEffect1");
			SetMathBtton (SkillState.Clock);
		} else if (oBtn.name == SkillState.Book.ToString ()) {
			Debug.Log ("MathEffect2");
			SetMathBtton (SkillState.Book);
		} else if (oBtn.name == SkillState.Key.ToString ()) {
			Debug.Log ("MathEffect3");
			SetMathBtton (SkillState.Key);
		} else if (oBtn.name == SkillState.Life.ToString ()) {
			Debug.Log ("Passive1");
			SetPassiveButton (SkillState.Life);
		} else if (oBtn.name == SkillState.Chest.ToString ()) {
			Debug.Log ("Passive2");
			SetPassiveButton (SkillState.Chest);
		} else if (oBtn.name == SkillState.MedalRibbon.ToString ()) {
			Debug.Log ("Passive3");
			SetPassiveButton (SkillState.MedalRibbon);
		}

	}

	void SetEffectBtton (SkillState state)
	{
		ResetEffectButton();
		dicSkill [state].GetComponent<UISprite> ().spriteName = "BtnRed";

		OnEffectSelected (state);
	}

	void SetMathBtton (SkillState state)
	{
		ResetMathButton();
		dicSkill [state].GetComponent<UISprite> ().spriteName = "BtnRed";

		OnMathSelected (state);
	}

	void SetPassiveButton (SkillState state)
	{
		ResetPassiveButton();
		dicSkill [state].GetComponent<UISprite> ().spriteName = "BtnRed";

		OnPassiveSelected (state);
	}

	public void ResetEffectButton ()
	{
		dicSkill [SkillState.Accuracy].GetComponent<UISprite> ().spriteName = "BtnGreen";
		dicSkill [SkillState.Bomb].GetComponent<UISprite> ().spriteName = "BtnGreen";
		dicSkill [SkillState.RoseOfWinds].GetComponent<UISprite> ().spriteName = "BtnGreen";
	}

	public void ResetMathButton ()
	{
		dicSkill [SkillState.Clock].GetComponent<UISprite> ().spriteName = "BtnGreen";
		dicSkill [SkillState.Book].GetComponent<UISprite> ().spriteName = "BtnGreen";
		dicSkill [SkillState.Key].GetComponent<UISprite> ().spriteName = "BtnGreen";
	}

	public void ResetPassiveButton ()
	{
		dicSkill [SkillState.Life].GetComponent<UISprite> ().spriteName = "BtnGreen";
		dicSkill [SkillState.Chest].GetComponent<UISprite> ().spriteName = "BtnGreen";
		dicSkill [SkillState.MedalRibbon].GetComponent<UISprite> ().spriteName = "BtnGreen";
	}


	void Start ()
	{
		


	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
