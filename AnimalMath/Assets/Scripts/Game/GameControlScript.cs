using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameControlScript : MonoBehaviour {
	private GameScript m_sGame = null;
	private bool m_bQuestion = false;
	private GameObject QUEST;
	private GameObject ENEMY;
	private GameObject m_oQuest;
	private const float m_fMoveSpeed = 500.0f;
	private List<GameObject> ListEnemy = new List<GameObject>();

	public void SetManager(GameScript manager){
		m_sGame = manager;
	}
	void Awake(){
		QUEST = (GameObject)Resources.Load ("Game/Quest");
		ENEMY = (GameObject)Resources.Load ("Game/Enemy");
	}
	void Start () {
		DataManager.Instance.LoadEnemyData ();
		m_bQuestion = false;
		m_oQuest = null;
		CreateQuestion ();
		StartCoroutine (CreateEnemy ());
	}
	void Update () {
		if (!m_sGame.bPause) {
			if (!m_bQuestion) {
				CreateQuestion ();
			} else {
				MoveQuest ();
			}

			MoveEnemy ();
			PlayerCollision ();
		}
	}
	void CreateQuestion(){
		m_bQuestion = true;
		m_oQuest = Instantiate (QUEST);
		m_oQuest.name = "Quest";
		m_oQuest.transform.parent = this.transform;
		m_oQuest.transform.localPosition = new Vector3 (5000.0f, 0.0f, 0.0f);
		m_oQuest.transform.localScale = Vector3.one;
	}
	void MoveQuest(){
		float fPosX = m_oQuest.transform.localPosition.x;
		m_oQuest.transform.localPosition = new Vector3 (fPosX - Time.deltaTime * m_fMoveSpeed, 0.0f, 0.0f);
	}
	IEnumerator CreateEnemy(){
		while (true) {
			if (!m_sGame.bPause) {
				if (2 > ListEnemy.Count) {
					int idx = UnityEngine.Random.Range (0, DataManager.Instance.AllEnemyData.Count);
					EnemyData eData = DataManager.Instance.AllEnemyData [idx];
					GameObject oEnemy = Instantiate (ENEMY);
					oEnemy.name = "Enemy";
					oEnemy.transform.parent = this.transform;
					if (EnemyState.Crow == eData.eType) {
						oEnemy.transform.localPosition = new Vector3 (700.0f, 100.0f, 0.0f);
					} else {
						oEnemy.transform.localPosition = new Vector3 (700.0f, -160.0f, 0.0f);
					}
					if (EnemyState.Snail == eData.eType) {
						oEnemy.transform.localScale = new Vector3 (-100.0f, 100.0f, 1.0f);
					} else {
						oEnemy.transform.localScale = Vector3.one * 100.0f;
					}
					oEnemy.GetComponent<EnemyScript> ().SetData (eData);
					oEnemy.GetComponent<EnemyScript> ().Init ();
					ListEnemy.Add (oEnemy);
				}
			}
			yield return new WaitForSeconds (2.0f);
		}
	}
	void MoveEnemy(){
		if (0 < ListEnemy.Count) {
			for (int i = 0; i < ListEnemy.Count; ++i) {
				float fPosX = ListEnemy [i].transform.localPosition.x;
				float fPosY = ListEnemy [i].transform.localPosition.y;
				EnemyData eData = ListEnemy [i].GetComponent<EnemyScript> ().GetEnemyData;
				ListEnemy [i].transform.localPosition = new Vector3 (
					fPosX - Time.deltaTime * m_fMoveSpeed * eData.MoveSpeed, 
					fPosY, 
					0.0f);

				if (-800.0f > fPosX) {
					Destroy (ListEnemy [i]);
					ListEnemy.RemoveAt (i);
					break;
				}
			}
		}
	}

	void PlayerCollision(){
		for (int i = 0; i < ListEnemy.Count; ++i) {
			Vector3 PlayerPos = m_sGame.m_sPlayer.gameObject.transform.localPosition;
			Vector3 EnemyPos = ListEnemy [i].transform.localPosition;
			float Dist = Vector3.Distance (PlayerPos, EnemyPos);
			if (80.0f > Dist) {
				Destroy (ListEnemy [i].gameObject);
				ListEnemy.RemoveAt (i);
				Debug.Log ("Player Collision");
				break;
			}
		}
	}

	public void OnQuestDestroy(){
		m_bQuestion = false;
	}
	public void OnAllEnemyDestroy(){
		if (0 < ListEnemy.Count) {
			for (int i = 0; i < ListEnemy.Count; ++i) {
				Destroy (ListEnemy [i]);
			}
			ListEnemy.Clear ();
		}
	}
}
