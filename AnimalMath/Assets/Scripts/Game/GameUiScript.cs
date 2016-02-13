using UnityEngine;
using System.Collections;

public class GameUiScript : MonoBehaviour {
	private GameScript m_sGame = null;
	private GameObject m_oGameSkill;
	private GameObject m_oPassiveSkill;
	private PlayerData m_pData = null;
	private UILabel m_tLife;

	public void SetManager(GameScript manager){
		m_sGame = manager;
	}
	void Start () {
		SetGameData ();
		m_pData = GameManager.Instance.playerData;
		m_tLife = this.transform.FindChild ("tLife").GetComponent<UILabel> ();
		UILabel tDif = this.transform.FindChild ("tDif").GetComponent<UILabel> ();

		tDif.text = m_pData.eStageLevel.ToString();
		SetSkill ();
		ViewSkillIcon ();
		ViewGameLife ();
	}
	void Update () {
	}
	void Press(GameObject oBtn){
		if ("GameSkill" == oBtn.name) {
			UseGameSkill ();
		} else if ("BtnPause" == oBtn.name) {
			m_sGame.CreatePopupPause ();
		}
	}
	void SetGameData(){
		if (SkillState.Life == GameManager.Instance.playerData.Passive.Name) {
			GameManager.Instance.playerData.nLife++;
		}
	}
	public void ViewGameLife(){
		m_tLife.text = string.Format ("Life: {0}", GameManager.Instance.playerData.nLife);
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
		m_oGameSkill.transform.FindChild ("Skill").GetComponent<UISprite> ().spriteName = GameManager.Instance.playerData.Effect.Name.ToString ();
		m_oPassiveSkill.transform.FindChild ("Skill").GetComponent<UISprite> ().spriteName = GameManager.Instance.playerData.Passive.Name.ToString ();
		m_oGameSkill.transform.FindChild ("Skill").GetComponent<UISprite> ().MakePixelPerfect ();
		m_oPassiveSkill.transform.FindChild ("Skill").GetComponent<UISprite> ().MakePixelPerfect ();
	}
	void UseGameSkill(){
		m_sGame.m_sGameControl.UseGameSkill (GameManager.Instance.playerData.Effect.Name);
		GameManager.Instance.playerData.Effect.Name = SkillState.None;
		m_oGameSkill.transform.FindChild ("Skill").GetComponent<UISprite> ().spriteName = GameManager.Instance.playerData.Effect.Name.ToString();
	}
}
