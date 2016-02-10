using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour {
	private GameScript m_sGame = null;
	private GameObject m_oPlayer;
	private List<int> ListNumber = new List<int>();
	private List<CalcMark> ListMark = new List<CalcMark>();
	private int m_iResult = 0;

	private enum PlayerState{
		Start,
		Jump,
		Run,
	};
	private PlayerState m_ePlayerState = PlayerState.Start;

	private const float BASE_POSX = -400.0f;
	private const float BASE_POSY = -160.0f;
	private const float BASE_JUMP_FORCE = 20.0f;
	private float m_fPosX = -800.0f;
	private float m_fPosY = BASE_POSY;
	private float m_fJump = 0.0f;

	public void SetManager(GameScript manager){
		m_sGame = manager;
	}
	public int GetResult{
		get{ return m_iResult; }
	}
	void Start () {
		SetPlayer ();
	}
	void Update () {
		if (PlayerState.Start == m_ePlayerState) {
			PlayerStart ();
		} else if (PlayerState.Jump == m_ePlayerState) {
			Jumpping ();
		} else if (PlayerState.Run == m_ePlayerState) {
			KeyPress ();
		}
		this.transform.localPosition = new Vector3 (m_fPosX, m_fPosY, 0.0f);
	}
	void SetPlayer(){
		this.transform.localPosition = new Vector3 (m_fPosX, m_fPosY, 0.0f);
		m_oPlayer = (GameObject)Instantiate (Resources.Load ("Prefabs/Player/" + GameManager.Instance.ePlayerState.ToString()));
		m_oPlayer.name = GameManager.Instance.ePlayerState.ToString ();
		m_oPlayer.transform.parent = this.transform;
		m_oPlayer.transform.localPosition = Vector3.zero;
		m_oPlayer.transform.localScale = Vector3.one;
	}
	void PlayerStart(){
		m_fPosX += 400.0f * Time.deltaTime;
		if (BASE_POSX < m_fPosX) {
			m_fPosX = BASE_POSX;
			m_ePlayerState = PlayerState.Run;
		}
	}
	void KeyPress(){
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			Jump ();
		}
	}
	void Jump(){
		m_ePlayerState = PlayerState.Jump;
		m_fJump = BASE_JUMP_FORCE;
	}
	void Jumpping(){
		m_fJump -= Time.deltaTime * BASE_JUMP_FORCE * 2;
		m_fPosY += m_fJump;
		if (BASE_POSY > m_fPosY) {
			m_fPosY = BASE_POSY;
			m_ePlayerState = PlayerState.Run;
		}
	}

	void OnTriggerEnter(Collider oCol){
		if ("Quest" == oCol.transform.tag) {
			m_sGame.m_sGameControl.OnQuestDestroy ();
			Destroy (oCol.gameObject);
			CreatePopupQuest ();
		}
	}
	void CreatePopupQuest(){
		MakeQuestNum (2);
		m_sGame.CameraResume (false);
		Time.timeScale = 0;
		GameObject oPopup = (GameObject)Instantiate (Resources.Load ("Game/Popup/PopupQuest"));
		PopupQuestScript sPopup = oPopup.GetComponent<PopupQuestScript> ();
		oPopup.name = "PopupQuest";
		oPopup.transform.parent = m_sGame.transform;
		oPopup.transform.localPosition = Vector3.zero;
		oPopup.transform.localScale = Vector3.one;
		sPopup.SetPlayer (this);
		sPopup.SetQuest (ListNumber, ListMark);
		sPopup.CallOk = PopupQuestCallOk;
	}
	void PopupQuestCallOk(){
		Time.timeScale = 1;
		m_sGame.CameraResume (true);
	}
	void MakeQuestNum(int iCount){
		ListNumber.Clear ();
		for (int i = 0; i < iCount; ++i) {
			ListNumber.Add (UnityEngine.Random.Range(1, 10));
		}
		MakeQuestCalcMark (iCount - 1);
	}
	void MakeQuestCalcMark(int iCount){
		ListMark.Clear ();
		for (int i = 0; i < iCount; ++i) {
			CalcMark eMark = (CalcMark)UnityEngine.Random.Range (0, 4);
			ListMark.Add (eMark);
		}
		QuestResult ();
	}
	void QuestResult(){
		List<int> listNumber = new List<int>();
		List<CalcMark> listMark = new List<CalcMark>();
		for (int i = 0; i < ListNumber.Count; ++i) {
			listNumber.Add (ListNumber[i]);
		}
		for (int i = 0; i < ListMark.Count; ++i) {
			listMark.Add (ListMark [i]);
		}
		m_iResult = 0;
		float fResult = 0.0f;
		bool bRemain = false;
		for (int i = 0; i < listMark.Count; ++i) {
			switch (listMark [i]) {
			case CalcMark.Sum:
				{
					fResult = listNumber [0] + listNumber [1];
				}
				break;
			case CalcMark.Sub:
				{
					fResult = listNumber [0] - listNumber [1];
				}
				break;
			case CalcMark.Mul:
				{
					fResult = listNumber [0] * listNumber [1];
				}
				break;
			case CalcMark.Div:
				{
					fResult = listNumber [0] / listNumber [1];
					if (0 != (listNumber [0] % listNumber [1])) {
						bRemain = true;
					}
					if (0 != (listNumber [1] % listNumber [0])) {
						bRemain = true;
					}
				}
				break;
			}
			if (bRemain) {
				break;
			} else {
				listMark.RemoveAt(0);
				listNumber.RemoveAt(1);
				listNumber [0] = (int)fResult;
			}
		}
		if (bRemain) {
			MakeQuestNum (2);
		} else {
			m_iResult = (int)fResult;
		}
	}
}
