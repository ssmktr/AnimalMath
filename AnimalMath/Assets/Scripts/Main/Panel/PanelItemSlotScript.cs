using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PanelItemSlotScript : PanelBaseScript {

	public delegate void OnSelected (string name);
	public static event OnSelected OnEffectSelected;
	public static event OnSelected OnMathSelected;
	public static event OnSelected OnPassiveSelected;


	private Dictionary<string, Transform> dicEffect = new Dictionary<string, Transform>();
	private Dictionary<string, Transform> dicMath = new Dictionary<string, Transform>();
	private Dictionary<string, Transform> dicPassive = new Dictionary<string, Transform>();

	void Awake()
	{
		Debug.Log("Init");
		OnInit();
	}
	public override void OnInit ()
	{
		Debug.Log("OnInit");

		string sEffect = "";
		string sMath = "";
		string sPassive = "";

		for (int i = 0; i < 3; i++) {
			sEffect = string.Format("Effect{0}",i+1);
			sMath = string.Format("MathEffect{0}",i+1);
			sPassive = string.Format("Passive{0}",i+1);
			Debug.Log(sEffect);
			GameData.SetBtn(this.transform, sEffect, "Press", this);
			GameData.SetBtn(this.transform, sMath, "Press", this);
			GameData.SetBtn(this.transform, sPassive, "Press", this);
			dicEffect.Add(sEffect , this.transform.FindChild(sEffect));
			dicMath.Add(sMath, this.transform.FindChild(sMath));
			dicPassive.Add(sPassive, this.transform.FindChild(sPassive));
		}
	}

	public override void OnPress(GameObject oBtn)
	{
		if(oBtn.name == "Effect1"){
			Debug.Log("Effect1");
			SetEffectBtton(oBtn.name);
		} else if(oBtn.name == "Effect2"){
			Debug.Log("Effect2");
			SetEffectBtton(oBtn.name);
		} else if(oBtn.name == "Effect3"){
			Debug.Log("Effect3");
			SetEffectBtton(oBtn.name);
		} else if(oBtn.name == "MathEffect1"){
			Debug.Log("MathEffect1");
			SetMathBtton(oBtn.name);
		} else if(oBtn.name == "MathEffect2"){
			Debug.Log("MathEffect2");
			SetMathBtton(oBtn.name);
		} else if(oBtn.name == "MathEffect3"){
			Debug.Log("MathEffect3");
			SetMathBtton(oBtn.name);
		} else if(oBtn.name == "Passive1"){
			Debug.Log("Passive1");
			SetPassiveButton(oBtn.name);
		} else if(oBtn.name == "Passive2"){
			Debug.Log("Passive2");
			SetPassiveButton(oBtn.name);
		} else if(oBtn.name == "Passive3"){
			Debug.Log("Passive3");
			SetPassiveButton(oBtn.name);
		}

	}

	void SetEffectBtton(string name)
	{
		if(dicEffect[name] != null){
			foreach (Transform item in dicEffect.Values) {
				item.GetComponent<UISprite>().spriteName = "BtnGreen";
			}
			this.transform.FindChild(name).GetComponent<UISprite>().spriteName = "BtnRed";
			OnEffectSelected(name);
		}
	}

	void SetMathBtton(string name)
	{
		if(dicMath[name] != null){

			foreach (Transform item in dicMath.Values) {
				item.GetComponent<UISprite>().spriteName = "BtnGreen";
			}
			this.transform.FindChild(name).GetComponent<UISprite>().spriteName = "BtnRed";
			OnMathSelected(name);
		}
	}

	void SetPassiveButton(string name)
	{
		if(dicPassive[name] != null){

			foreach (Transform item in dicPassive.Values) {
				item.GetComponent<UISprite>().spriteName = "BtnGreen";
			}
			this.transform.FindChild(name).GetComponent<UISprite>().spriteName = "BtnRed";
			OnPassiveSelected(name);
		}
	}
		

	void Start () {
		


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
