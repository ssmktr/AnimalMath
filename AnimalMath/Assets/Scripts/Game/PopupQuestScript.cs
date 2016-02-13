using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PopupQuestScript : MonoBehaviour {
	public delegate void CallBackOk();
	public CallBackOk CallOk = null;
	private PlayerScript m_sPlayer = null;
	private List<int> ListNumber = new List<int>();
	private List<CalcMark> ListMark = new List<CalcMark>();
	private List<int> ListResult = new List<int>();
	private UILabel m_tResult;
	private bool m_bMinus = false;
	private float m_fLimitTime = 10.0f;

	public void SetPlayer(PlayerScript player){
		m_sPlayer = player;
	}
	public void SetQuest(List<int> listNumber, List<CalcMark> listMark){
		ListNumber = listNumber;
		ListMark = listMark;
	}
	void Start () {
		GameObject oNumberControl = this.transform.FindChild ("NumberControl").gameObject;
		GameData.SetBtn (oNumberControl.transform, "BtnClear", "Press", this);
		GameData.SetBtn (oNumberControl.transform, "BtnMinus", "Press", this);
		GameData.SetBtn (oNumberControl.transform, "BtnOk", "Press", this);
		GameData.SetBtn (this.transform, "QuestSkill", "Press", this);


		for (int i = 0; i < 10; ++i) {
			GameObject oNumber = oNumberControl.transform.FindChild ("BtnNumber" + i).gameObject;
			oNumber.transform.FindChild ("Number").GetComponent<UISprite> ().spriteName = "Num" + i;
			GameData.SetBtn (oNumberControl.transform, oNumber.name, "Press", this);
		}
		m_tResult = this.transform.FindChild ("tResult").GetComponent<UILabel> ();
		SetQuest ();
		InitLimitTime ();
		ViewSkill ();
	}
	void ViewSkill(){
		GameObject oSkill = this.transform.FindChild ("QuestSkill").gameObject;
		oSkill.transform.FindChild ("Skill").GetComponent<UISprite> ().spriteName = GameManager.Instance.playerData.Math.Name.ToString ();
	}
	void Update () {
	}
	void Exit(){
		if (QuestSuccess ()) {
			Debug.Log ("Win");
		} else {
			Debug.Log ("Lose");
		}
		if (null != CallOk) {
			CallOk ();
		}
		Destroy (this.gameObject);
	}
	void Press(GameObject oBtn){
		if ("BtnOk" == oBtn.name) {
			Exit ();
		} else if ("BtnClear" == oBtn.name) {
			ListResult.Clear ();
			ViewResult ();
		} else if ("BtnMinus" == oBtn.name) {
			m_bMinus = !m_bMinus;
			ViewResult ();
		} else if(oBtn.name.Contains("BtnNumber")) {
			int iNum = int.Parse(oBtn.name.Replace ("BtnNumber", ""));
			InputResult (iNum);
		} else if(oBtn.name.Contains("QuestSkill")) {
			GameManager.Instance.playerData.Math.Name = SkillState.None;
			ViewSkill ();
		}
	}
	void SetQuest(){
		UILabel tQuest = this.transform.FindChild ("tQuest").GetComponent<UILabel> ();
		tQuest.text = "";
		for (int i = 0; i < ListNumber.Count; ++i) {
			tQuest.text += ListNumber [i].ToString ();
			tQuest.text += " ";
			if (ListNumber.Count - 1 == i) {
				tQuest.text += "=";
			} else {
				switch (ListMark [i]) {
				case CalcMark.Sum:
					{
						tQuest.text += "+";
					}
					break;
				case CalcMark.Sub:
					{
						tQuest.text += "-";
					}
					break;
				case CalcMark.Mul:
					{
						tQuest.text += "x";
					}
					break;
				case CalcMark.Div:
					{
						tQuest.text += "/";
					}
					break;
				}
			}
			tQuest.text += " ";
		}
	}
	void InputResult(int num){
		if (0 == ListResult.Count) {
			if (0 != num) {
				ListResult.Add (num);
			}
		} else {
			ListResult.Add (num);
		}
		ViewResult ();
	}
	void ViewResult(){
		m_tResult.text = "";
		if (0 == ListResult.Count) {
			m_tResult.text = "0";
		} else {
			if (m_bMinus) {
				m_tResult.text = "-";
			}
			for (int i = 0; i < ListResult.Count; ++i) {
				m_tResult.text += ListResult [i].ToString ();
			}
		}
	}
	bool QuestSuccess(){
		int iResult = int.Parse (m_tResult.text);
		if (m_sPlayer.GetResult != iResult) {
			return false;
		}
		return true;
	}
	void InitLimitTime(){
		m_fLimitTime = 10.0f;
		StartCoroutine (ViewTime ());
	}
	IEnumerator ViewTime(){
		UILabel tLimitTime = this.transform.FindChild ("tLimitTime").GetComponent<UILabel> ();
		while (0 < m_fLimitTime) {
			m_fLimitTime -= 1;
			if (0 >= m_fLimitTime) {
				m_fLimitTime = 0;
				Exit ();
			}
			tLimitTime.text = string.Format ("{0}", (int)m_fLimitTime);
			yield return new WaitForSeconds (1.0f);
		}
	}
}
