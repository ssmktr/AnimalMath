using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PanelItemSlotScript : PanelBaseScript
{

	public delegate void OnSelected (SkillState state);

	public static event OnSelected OnEffectSelected;
	public static event OnSelected OnMathSelected;
	public static event OnSelected OnPassiveSelected;

	private Dictionary<SkillState, Transform> dicSkill = new Dictionary<SkillState, Transform> ();

	void Awake ()
	{
//		Debug.Log ("Init");
		OnInit ();
	}

	public override void OnInit ()
	{
		Debug.Log ("PanelItemSlotScript : OnInit");

		for (SkillState i = SkillState.Accuracy; i < SkillState.MAX; i++) {
			GameData.SetBtn (this.transform, i.ToString (), "Press", this);
			dicSkill.Add (i, this.transform.FindChild (i.ToString()));
		}
		Transform item;

		for (SkillState i = SkillState.Accuracy; i < SkillState.MAX; i++) {
			item = dicSkill[i];
			item.transform.FindChild("Icon").GetComponent<UISprite>().spriteName = i.ToString();
//			Debug.Log("data price" + DataManager.Instance.dicSkillData[i].Price.ToString());
			if(DataManager.Instance.dicSkillData[i].Price.ToString() != "")
			{
				item.transform.FindChild("Sprite").GetComponentInChildren<UILabel>().text = DataManager.Instance.dicSkillData[i].Price.ToString();	
			}
		}
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
		dicSkill [SkillState.Accuracy].GetComponent<UISprite> ().spriteName = "CheckBoxRect";
		dicSkill [SkillState.Bomb].GetComponent<UISprite> ().spriteName = "CheckBoxRect";
		dicSkill [SkillState.RoseOfWinds].GetComponent<UISprite> ().spriteName = "CheckBoxRect";
	}

	public void ResetMathButton ()
	{
		dicSkill [SkillState.Clock].GetComponent<UISprite> ().spriteName = "CheckBoxRect";
		dicSkill [SkillState.Book].GetComponent<UISprite> ().spriteName = "CheckBoxRect";
		dicSkill [SkillState.Key].GetComponent<UISprite> ().spriteName = "CheckBoxRect";
	}

	public void ResetPassiveButton ()
	{
		dicSkill [SkillState.Life].GetComponent<UISprite> ().spriteName = "CheckBoxRect";
		dicSkill [SkillState.Chest].GetComponent<UISprite> ().spriteName = "CheckBoxRect";
		dicSkill [SkillState.MedalRibbon].GetComponent<UISprite> ().spriteName = "CheckBoxRect";
	}


	void Start ()
	{
		


	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
