using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using LitJson;

public class PanelReadyScript : PanelBaseScript
{
	private StageLevel m_eStageLevel = StageLevel.Easy;
	private SkillState m_eEffect = SkillState.None;
	private SkillState m_eMath = SkillState.None;
	private SkillState m_ePassive = SkillState.None;
	private GameObject m_oSkillControl;

	public override void OnInit () {
		GameData.SetBtn (this.transform, "BtnBack", "Press", this);
		GameData.SetBtn (this.transform, "BtnEasy", "Press", this);
		GameData.SetBtn (this.transform, "BtnNormal", "Press", this);
		GameData.SetBtn (this.transform, "BtnHard", "Press", this);
		GameData.SetBtn (this.transform, "ViewEffect", "Press", this);
		GameData.SetBtn (this.transform, "ViewMath", "Press", this);
		GameData.SetBtn (this.transform, "ViewPassive", "Press", this);

		m_oSkillControl = this.transform.FindChild ("SkillControl").gameObject;
		SetAllSkill ();
		SetStageLevel ();
	}
	void SetAllSkill(){
		for (int i = 0; i < m_oSkillControl.transform.childCount; ++i) {
			GameObject oSkill = m_oSkillControl.transform.GetChild (i).gameObject;
			oSkill.GetComponent<UISprite> ().color = Color.white;
			oSkill.GetComponent<UIEventTrigger> ().onClick = GameData.SetOnClick (this, "Press", oSkill);
		}
		SetEffectSkill ();
		SetMathSkill ();
		SetPassiveSkill ();
		ViewSkill ();
	}

	void SetEffectSkill(){
		if (SkillState.None != m_eEffect) {
			int idx = (int)m_eEffect;
			GameObject oSkill = m_oSkillControl.transform.GetChild (idx).gameObject;
			oSkill.GetComponent<UISprite> ().color = Color.blue;
		}
	}
	void SetMathSkill(){
		if (SkillState.None != m_eMath) {
			int idx = (int)m_eMath;
			GameObject oSkill = m_oSkillControl.transform.GetChild (idx).gameObject;
			oSkill.GetComponent<UISprite> ().color = Color.green;
		}
	}
	void SetPassiveSkill(){
		if (SkillState.None != m_ePassive) {
			int idx = (int)m_ePassive;
			GameObject oSkill = m_oSkillControl.transform.GetChild (idx).gameObject;
			oSkill.GetComponent<UISprite> ().color = Color.red;
		}
	}
	void SetStageLevel(){
		GameObject oBtnEasy = this.transform.FindChild ("BtnEasy").gameObject;
		GameObject oBtnNormal = this.transform.FindChild ("BtnNormal").gameObject;
		GameObject oBtnHard = this.transform.FindChild ("BtnHard").gameObject;
		UILabel tBtnEasy = oBtnEasy.transform.FindChild ("Easy").GetComponent<UILabel> ();
		UILabel tBtnNormal = oBtnNormal.transform.FindChild ("Normal").GetComponent<UILabel> ();
		UILabel tBtnHard = oBtnHard.transform.FindChild ("Hard").GetComponent<UILabel> ();
		oBtnEasy.GetComponent<UISprite> ().color = Color.white;
		oBtnNormal.GetComponent<UISprite> ().color = Color.white;
		oBtnHard.GetComponent<UISprite> ().color = Color.white;
		tBtnEasy.text = GameData.LocalizeText ("Easy");
		tBtnNormal.text = GameData.LocalizeText ("Normal");
		tBtnHard.text = GameData.LocalizeText ("Hard");
		if (StageLevel.Easy == m_eStageLevel) {
			oBtnEasy.GetComponent<UISprite> ().color = Color.red;
		} else if (StageLevel.Normal == m_eStageLevel) {
			oBtnNormal.GetComponent<UISprite> ().color = Color.red;
		} else if (StageLevel.Hard == m_eStageLevel) {
			oBtnHard.GetComponent<UISprite> ().color = Color.red;
		} 
	}
	void ViewSkill(){
		GameObject oViewEffect = this.transform.FindChild ("ViewEffect").gameObject;
		GameObject oViewMath = this.transform.FindChild ("ViewMath").gameObject;
		GameObject oViewPassive = this.transform.FindChild ("ViewPassive").gameObject;
		oViewEffect.transform.FindChild ("Sprite").GetComponent<UISprite> ().spriteName = m_eEffect.ToString ();
		oViewMath.transform.FindChild ("Sprite").GetComponent<UISprite> ().spriteName = m_eMath.ToString ();
		oViewPassive.transform.FindChild ("Sprite").GetComponent<UISprite> ().spriteName = m_ePassive.ToString ();
	}
	public override void OnPress (GameObject oBtn)
	{
		if (oBtn.name == "BtnEasy") {
			m_eStageLevel = StageLevel.Easy;
		} else if (oBtn.name == "BtnNormal") {
			m_eStageLevel = StageLevel.Normal;
		} else if (oBtn.name == "BtnHard") {
			m_eStageLevel = StageLevel.Hard;
		} else if (oBtn.name == "BtnGameStart") {
			AdsData.PlayAds ();
		} else if (oBtn.name == "BtnBack") {
			m_sManager.SetScene (SceneState.Main);
		} else if (oBtn.name == "ViewEffect") {
			m_eEffect = SkillState.None;
		} else if (oBtn.name == "ViewMath") {
			m_eMath = SkillState.None;
		} else if (oBtn.name == "ViewPassive") {
			m_ePassive = SkillState.None;
		} else if (oBtn.name.Contains ("Skill")) {
			int idx = int.Parse (oBtn.name.Replace ("Skill", ""));
			if (3 > idx) {
				m_eEffect = (SkillState)idx;
			} else if (5 < idx) {
				m_ePassive = (SkillState)idx;
			} else {
				m_eMath = (SkillState)idx;
			}
		}
		SetStageLevel ();
		SetAllSkill ();
	}

	public override void OnExit (){
	}

	void Start () {
	}

	void Update (){
	}
}
