using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PanelItemSlotScript : PanelBaseScript {

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
		GameData.SetBtn(this.transform, "Effect1", "Press", this);
		GameData.SetBtn(this.transform, "Effect2", "Press", this);
		GameData.SetBtn(this.transform, "Effect3", "Press", this);
		GameData.SetBtn(this.transform, "MathEffect1", "Press", this);
		GameData.SetBtn(this.transform, "MathEffect2", "Press", this);
		GameData.SetBtn(this.transform, "MathEffect3", "Press", this);
		GameData.SetBtn(this.transform, "Passive1", "Press", this);
		GameData.SetBtn(this.transform, "Passive2", "Press", this);
		GameData.SetBtn(this.transform, "Passive3", "Press", this);

		dicEffect.Add("Effect1" , this.transform.FindChild("Effect1"));
		dicEffect.Add("Effect2" , this.transform.FindChild("Effect2"));
		dicEffect.Add("Effect3" ,this.transform.FindChild("Effect3"));
		dicMath.Add("MathEffect1", this.transform.FindChild("MathEffect1"));
		dicMath.Add("MathEffect2", this.transform.FindChild("MathEffect2"));
		dicMath.Add("MathEffect3", this.transform.FindChild("MathEffect3"));
		dicPassive.Add("Passive1", this.transform.FindChild("Passive1"));
		dicPassive.Add("Passive2", this.transform.FindChild("Passive2"));
		dicPassive.Add("Passive3", this.transform.FindChild("Passive3"));

	}

	public override void OnPress(GameObject oBtn)
	{
		if(oBtn.name == "Effect1"){
			Debug.Log("Effect1");
			SetButton(oBtn.name);
		} else if(oBtn.name == "Effect2"){
			Debug.Log("Effect2");
			SetButton(oBtn.name);
		} else if(oBtn.name == "Effect3"){
			Debug.Log("Effect3");
			SetButton(oBtn.name);
		} else if(oBtn.name == "MathEffect1"){
			Debug.Log("MathEffect1");
			SetButton(oBtn.name);
		} else if(oBtn.name == "MathEffect2"){
			Debug.Log("MathEffect2");
			SetButton(oBtn.name);
		} else if(oBtn.name == "MathEffect3"){
			Debug.Log("MathEffect3");
			SetButton(oBtn.name);
		} else if(oBtn.name == "Passive1"){
			Debug.Log("Passive1");
			SetButton(oBtn.name);
		} else if(oBtn.name == "Passive2"){
			Debug.Log("Passive2");
			SetButton(oBtn.name);
		} else if(oBtn.name == "Passive3"){
			Debug.Log("Passive3");
			SetButton(oBtn.name);
		}

	}

	void SetButton(string name)
	{
		if(dicEffect[name] != null){
			
			foreach (Transform item in dicEffect.Values) {
				item.GetComponent<UISprite>().spriteName = "BtnGreen";
			}
			this.transform.FindChild(name).GetComponent<UISprite>().spriteName = "BtnRed";

		}
//		if(dicMath[name] != null){
//			foreach (Transform item in dicMath.Values) {
//				item.GetComponent<UISprite>().spriteName = "BtnGreen";
//			}
//			this.transform.FindChild(name).GetComponent<UISprite>().spriteName = "BtnRed";
//			
//		}
//		if(dicPassive[name] != null){
//			foreach (Transform item in dicPassive.Values) {
//				item.GetComponent<UISprite>().spriteName = "BtnGreen";
//			}
//			this.transform.FindChild(name).GetComponent<UISprite>().spriteName = "BtnRed";
//		}

	}


	void Start () {
		


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
