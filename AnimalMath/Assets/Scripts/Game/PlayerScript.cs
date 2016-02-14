using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour {
	private GameScript m_sGame = null;
	private GameObject m_oPlayer;
	private List<int> ListNumber = new List<int>();
	private List<CalcMark> ListMark = new List<CalcMark>();
	private int m_iResult = 0;
	private int m_iResultCount = 2;

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
		if (StageLevel.Easy == GameManager.Instance.playerData.eStageLevel) {
			m_iResultCount = 2;
		} else if (StageLevel.Normal == GameManager.Instance.playerData.eStageLevel) {
			m_iResultCount = 3;
		} else if (StageLevel.Hard == GameManager.Instance.playerData.eStageLevel) {
			m_iResultCount = 4;
		}
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
			m_sGame.bPause = false;
		}
	}
	void KeyPress(){
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			Jump ();
		} else {
			if (0 < Input.touchCount) {
				Jump ();
			}
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
			m_sGame.m_sGameControl.OnAllEnemyDestroy ();
			CreatePopupQuest ();
		}
	}
	void CreatePopupQuest(){
		QuestResult ();
		m_sGame.bPause = true;
		m_sGame.CameraResume (false);
		GameObject oPopup = (GameObject)Instantiate (Resources.Load ("Game/Popup/PopupQuest"));
		PopupQuestScript sPopup = oPopup.GetComponent<PopupQuestScript> ();
		oPopup.name = "PopupQuest";
		oPopup.transform.parent = m_sGame.transform;
		oPopup.transform.localPosition = new Vector3 (0.0f, -50.0f, 0.0f);
		oPopup.transform.localScale = Vector3.one;
		sPopup.SetPlayer (this);
		sPopup.SetQuest (ListNumber, ListMark);
		sPopup.CallOk = PopupQuestCallOk;
	}
	void PopupQuestCallOk(){
		m_sGame.CameraResume (true);
		m_sGame.bPause = false;
	}
	void QuestResult(){
		ListNumber.Clear ();
		ListMark.Clear ();
		bool bRemain = false;
		m_iResult = 0;
		int iNum0 = UnityEngine.Random.Range(1, 10);
		int iNum1 = UnityEngine.Random.Range(1, 10);
		CalcMark eMark0 = (CalcMark)UnityEngine.Random.Range (0, 4);
		if (2 == m_iResultCount) {
			iNum0 = UnityEngine.Random.Range(1, 10);
			iNum1 = UnityEngine.Random.Range(1, 10);
		} else if (3 == m_iResultCount) {
			iNum0 = UnityEngine.Random.Range(1, 100);
			iNum1 = UnityEngine.Random.Range(1, 100);
		} else if (4 == m_iResultCount) {
			iNum0 = UnityEngine.Random.Range(1, 1000);
			iNum1 = UnityEngine.Random.Range(1, 1000);
		} 
		switch (eMark0) {
			case CalcMark.Sum:
				{
				m_iResult = iNum0 + iNum1;
				}
				break;
			case CalcMark.Sub:
				{
				m_iResult = iNum0 - iNum1;
				}
				break;
			case CalcMark.Mul:
				{
				m_iResult = iNum0 * iNum1;
				}
				break;
			case CalcMark.Div:
				{
				m_iResult = iNum0 / iNum1;
				if (0 != (iNum0 % iNum1)) {
						bRemain = true;
					}
				if (0 != (iNum1 % iNum0)) {
						bRemain = true;
					}
				}
				break;
			}

		if (bRemain) {
			QuestResult ();
		} else {
			ListNumber.Add (iNum0);
			ListNumber.Add (iNum1);
			ListMark.Add (eMark0);
		}
	}
	public void QuestFail(){
		GameManager.Instance.playerData.nLife--;
		m_sGame.m_sGameUi.ViewGameLife ();
	}
	public void SuccessResult(){
		m_sGame.m_sGameUi.SuccessResult ();
	}
}
