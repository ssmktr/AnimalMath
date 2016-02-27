using UnityEngine;
using System.Collections;
using LitJson;

public class PanelReadyScript : PanelBaseScript
{
	private StageLevel m_eStageLevel = StageLevel.Easy;
	private SkillState m_eEffect = SkillState.None;
	private SkillState m_eMath = SkillState.None;
	private SkillState m_ePassive = SkillState.None;
	private GameObject m_oSkillControl;
	private GameObject POPUP;
	private UILabel m_lbGold;
	private int m_nTempPrice = 0;
	private int m_nEffectPrice = 0;
	private int m_nMathPrice = 0;
	private int m_nPassivePrice = 0;

	public override void OnInit () {
		GameData.SetBtn (this.transform, "BtnBack", "Press", this);
		GameData.SetBtn (this.transform, "BtnGameStart", "Press", this);
		GameData.SetBtn (this.transform, "BtnEasy", "Press", this);
		GameData.SetBtn (this.transform, "BtnNormal", "Press", this);
		GameData.SetBtn (this.transform, "BtnHard", "Press", this);
		GameData.SetBtn (this.transform, "ViewEffect", "Press", this);
		GameData.SetBtn (this.transform, "ViewMath", "Press", this);
		GameData.SetBtn (this.transform, "ViewPassive", "Press", this);

		POPUP = (GameObject)Resources.Load ("Prefabs/Popup/Goldwaring");
		m_lbGold = this.transform.FindChild ("Gold").FindChild ("Label").GetComponent<UILabel> ();
		InitGold ();
		SetGoldText();

		m_oSkillControl = this.transform.FindChild ("SkillControl").gameObject;
		SetAllSkill ();
		SetStageLevel ();
	}
	void SetAllSkill(){
		for (int i = 0; i < m_oSkillControl.transform.childCount; ++i) {
			GameObject oSkill = m_oSkillControl.transform.GetChild (i).gameObject;
			oSkill.GetComponent<UISprite> ().color = Color.white;
			oSkill.GetComponent<UIEventTrigger> ().onClick = GameData.SetOnClick (this, "Press", oSkill);
			oSkill.transform.FindChild ("Sprite").FindChild ("Price").GetComponent<UILabel> ().text = DataManager.Instance.AllSkillData [i].Price.ToString();
		}
		SetEffectSkill ();
		SetMathSkill ();
		SetPassiveSkill ();
		ViewSkill ();
	}
	void InitGold()
	{
		m_nTempPrice = GameManager.Instance.Gold;
	}
	void SetTotalGold()
	{
		GameManager.Instance.Gold = m_nTempPrice + m_nEffectPrice + m_nMathPrice + m_nPassivePrice;
	}

	bool HasEnoughGold(SkillState ef, SkillState ma, SkillState pa)
	{
		int effectPrice=0;
		int mathPrice=0;
		int passivePrice=0;

		if (SkillState.None != ef) {
			effectPrice = DataManager.Instance.AllSkillData [(int)ef].Price;
		}
		if (SkillState.None != ma) {
			mathPrice = DataManager.Instance.AllSkillData [(int)ma].Price;
		}
		if (SkillState.None != pa) {
			passivePrice = DataManager.Instance.AllSkillData [(int)pa].Price;	
		}
		int totalValue = m_nTempPrice - (effectPrice + mathPrice + passivePrice); 			
		if (0 > totalValue) {
			//사려는 금액보다 가지고 있는 돈의 액수가 적을경우 
			Debug.Log("Not Enough Momey");
			SetPopup ();
			return false;
		}
		return true;
	}
	void SetPopup()
	{
		GameObject popup = Instantiate (POPUP);
		popup.name = "goldwaring";
		popup.transform.parent = this.transform;
		popup.transform.localPosition = new Vector3 (0.0f, 0.0f, 0.0f);
		popup.transform.localScale = Vector3.one;
//		popup.transform.FindChild ("ok").GetComponent<UIEventTrigger> ().onClick = GameData.SetOnClick (this, "Press", this);
	}
	void SetGoldText()
	{
		m_lbGold.text = "Gold : " + GameManager.Instance.Gold.ToString ();
		if (GameManager.Instance.Gold > 9999) {
			m_lbGold.text = "Gold : 9999+";
		}
	}

	void ResetGold()
	{
		m_nEffectPrice 	= 0;
		m_nMathPrice 	= 0;
		m_nPassivePrice = 0;
		GameManager.Instance.Gold = m_nTempPrice;
		SetGoldText ();
	}
	void ResetItem()
	{
		m_eEffect 	= SkillState.None;
		m_eMath 	= SkillState.None;
		m_ePassive 	= SkillState.None;
	}
	void SetEffectSkill(){
		if (SkillState.None != m_eEffect) {
			int idx = (int)m_eEffect;
			GameObject oSkill = m_oSkillControl.transform.GetChild (idx).gameObject;
			oSkill.GetComponent<UISprite> ().color = Color.blue;
			m_nEffectPrice = - DataManager.Instance.AllSkillData[idx].Price;
			SetTotalGold ();
			SetGoldText ();
		} else if (SkillState.None == m_eEffect) {
			m_nEffectPrice = 0;
			SetTotalGold ();
			SetGoldText ();
		}
	}
	void SetMathSkill(){
		if (SkillState.None != m_eMath) {
			int idx = (int)m_eMath;
			GameObject oSkill = m_oSkillControl.transform.GetChild (idx).gameObject;
			oSkill.GetComponent<UISprite> ().color = Color.green;
			m_nMathPrice = - DataManager.Instance.AllSkillData [idx].Price;
			SetTotalGold ();
			SetGoldText ();
		} else if (SkillState.None == m_eMath) {
			m_nMathPrice = 0;
			SetTotalGold ();
			SetGoldText ();
		}
	}
	void SetPassiveSkill(){
		if (SkillState.None != m_ePassive) {
			int idx = (int)m_ePassive;
			GameObject oSkill = m_oSkillControl.transform.GetChild (idx).gameObject;
			oSkill.GetComponent<UISprite> ().color = Color.red;
			m_nPassivePrice = - DataManager.Instance.AllSkillData [idx].Price;
			SetTotalGold ();
			SetGoldText ();
		} else if (SkillState.None == m_ePassive) {
			m_nPassivePrice = 0;
			SetTotalGold ();
			SetGoldText ();
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
	void InGameData(){
		GameManager.Instance.playerData.eStageLevel = m_eStageLevel;
		GameManager.Instance.playerData.Effect.Name = m_eEffect;
		GameManager.Instance.playerData.Math.Name = m_eMath;
		GameManager.Instance.playerData.Passive.Name = m_ePassive;
		int value = GameManager.Instance.Gold;
		Debug.Log ("Will Save Gold" + value);
		GameManager.Instance.SaveGameDataToLocal ();
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
			InGameData ();
			AdsData.PlayAds ();
		} else if (oBtn.name == "BtnBack") {
			ResetGold ();
			ResetItem ();
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
				if (HasEnoughGold((SkillState)idx, m_eMath, m_ePassive)) {
					m_eEffect = (SkillState)idx;	
				}
			} else if (5 < idx) {
				if (HasEnoughGold(m_eEffect, m_eMath, (SkillState)idx)) {
					m_ePassive = (SkillState)idx;	
				}
			} else {
				if (HasEnoughGold(m_eEffect, (SkillState)idx, m_ePassive)) {
					m_eMath = (SkillState)idx;
				}
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
