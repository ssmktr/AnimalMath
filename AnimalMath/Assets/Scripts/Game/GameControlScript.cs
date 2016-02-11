using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameControlScript : MonoBehaviour {
	private GameScript m_sGame = null;
	private bool m_bQuestion = false;
	private GameObject QUEST;
	private GameObject m_oQuest;
	private float m_fMoveSpeed = 500.0f;
	public void SetManager(GameScript manager){
		m_sGame = manager;
	}
	void Awake(){
		QUEST = (GameObject)Resources.Load ("Game/Quest");
	}
	void Start () {
		m_bQuestion = false;
		m_oQuest = null;
		CreateQuestion ();
	}
	void Update () {
		if (!m_sGame.bPause) {
			if (!m_bQuestion) {
				CreateQuestion ();
			} else {
				MoveQuest ();
			}
		}
	}
	void CreateQuestion(){
		m_bQuestion = true;
		m_oQuest = Instantiate (QUEST);
		m_oQuest.transform.parent = this.transform;
		m_oQuest.transform.localPosition = new Vector3 (500.0f, 0.0f, 0.0f);
		m_oQuest.transform.localScale = Vector3.one;
	}
	void MoveQuest(){
		float fPosX = m_oQuest.transform.localPosition.x;
		m_oQuest.transform.localPosition = new Vector3 (fPosX - Time.deltaTime * m_fMoveSpeed, 0.0f, 0.0f);
	}
	public void OnQuestDestroy(){
		m_bQuestion = false;
	}
}
