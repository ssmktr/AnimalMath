using UnityEngine;
using System.Collections;

public class GameUiScript : MonoBehaviour {
	private GameScript m_sGame = null;
	private GameObject m_oGameSkill;
	private GameObject m_oQuestSkill;
	private GameObject m_oPassiveSkill;

	public void SetManager(GameScript manager){
		m_sGame = manager;
	}
	void Start () {
		SetSkill ();
		ViewSkillIcon ();
	}
	void Update () {
	}
	void Press(GameObject oBtn){
		if ("GameSkill" == oBtn.name) {
			m_oGameSkill.transform.FindChild ("Skill").GetComponent<UISprite> ().spriteName = "None";
		} else if ("QuestSkill" == oBtn.name) {
			m_oQuestSkill.transform.FindChild ("Skill").GetComponent<UISprite> ().spriteName = "None";
		} else if ("PassiveSkill" == oBtn.name) {
			m_oPassiveSkill.transform.FindChild ("Skill").GetComponent<UISprite> ().spriteName = "None";
		} else if ("BtnPause" == oBtn.name) {
			m_sGame.CreatePopupPause ();
		}
	}
	void SetSkill(){
		GameObject m_oSkillControl = this.transform.FindChild ("SkillControl").gameObject;
		m_oGameSkill = m_oSkillControl.transform.FindChild ("GameSkill").gameObject;
		m_oQuestSkill = m_oSkillControl.transform.FindChild ("QuestSkill").gameObject;
		m_oPassiveSkill = m_oSkillControl.transform.FindChild ("PassiveSkill").gameObject;
		GameData.SetBtn (this.transform, "BtnPause", "Press", this);
		GameData.SetBtn (this.transform, "GameSkill", "Press", this);
		GameData.SetBtn (this.transform, "QuestSkill", "Press", this);
		GameData.SetBtn (this.transform, "PassiveSkill", "Press", this);
	}
	void ViewSkillIcon(){
		m_oGameSkill.transform.FindChild ("Skill").GetComponent<UISprite> ().spriteName = "ActiveItemAccuracy";
		m_oQuestSkill.transform.FindChild ("Skill").GetComponent<UISprite> ().spriteName = "MathItemClock";
		m_oPassiveSkill.transform.FindChild ("Skill").GetComponent<UISprite> ().spriteName = "PassiveItemChest";
		m_oGameSkill.transform.FindChild ("Skill").GetComponent<UISprite> ().MakePixelPerfect ();
		m_oQuestSkill.transform.FindChild ("Skill").GetComponent<UISprite> ().MakePixelPerfect ();
		m_oPassiveSkill.transform.FindChild ("Skill").GetComponent<UISprite> ().MakePixelPerfect ();
	}
}
