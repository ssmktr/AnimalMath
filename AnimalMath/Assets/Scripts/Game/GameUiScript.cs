using UnityEngine;
using System.Collections;

public class GameUiScript : MonoBehaviour {
	private GameScript m_sGame = null;
	private GameObject m_oGameSkill;
	private GameObject m_oPassiveSkill;
	private PlayerData m_pData = null;

	public void SetManager(GameScript manager){
		m_sGame = manager;
	}
	void Start () {
		m_pData = GameManager.Instance.playerData;
		UILabel tDif = this.transform.FindChild ("tDif").GetComponent<UILabel> ();
		tDif.text = m_pData.eStageLevel.ToString();
		SetSkill ();
		ViewSkillIcon ();
	}
	void Update () {
	}
	void Press(GameObject oBtn){
		if ("GameSkill" == oBtn.name) {
			m_oGameSkill.transform.FindChild ("Skill").GetComponent<UISprite> ().spriteName = "None";
		} else if ("PassiveSkill" == oBtn.name) {
			m_oPassiveSkill.transform.FindChild ("Skill").GetComponent<UISprite> ().spriteName = "None";
		} else if ("BtnPause" == oBtn.name) {
			m_sGame.CreatePopupPause ();
		}
	}
	void SetSkill(){
		GameObject m_oSkillControl = this.transform.FindChild ("SkillControl").gameObject;
		m_oGameSkill = m_oSkillControl.transform.FindChild ("GameSkill").gameObject;
		m_oPassiveSkill = m_oSkillControl.transform.FindChild ("PassiveSkill").gameObject;
		GameData.SetBtn (this.transform, "BtnPause", "Press", this);
		GameData.SetBtn (this.transform, "GameSkill", "Press", this);
		GameData.SetBtn (this.transform, "PassiveSkill", "Press", this);
	}
	void ViewSkillIcon(){
		m_oGameSkill.transform.FindChild ("Skill").GetComponent<UISprite> ().spriteName = GameManager.Instance.playerData.eEffect.ToString ();
		m_oPassiveSkill.transform.FindChild ("Skill").GetComponent<UISprite> ().spriteName = GameManager.Instance.playerData.ePassive.ToString ();
		m_oGameSkill.transform.FindChild ("Skill").GetComponent<UISprite> ().MakePixelPerfect ();
		m_oPassiveSkill.transform.FindChild ("Skill").GetComponent<UISprite> ().MakePixelPerfect ();
	}
}
