using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyScript : MonoBehaviour {
	private EnemyData m_eData = null;
	private const float m_fMoveSpeed = 500.0f;
	void Start () {
	}
	void Update () {
	}
	public EnemyData GetEnemyData {
		get{ return m_eData; }
	}
	public void SetData(EnemyData eData){
		m_eData = eData;
	}
	public void Init(){
		GameObject oEnemy = (GameObject)Instantiate (Resources.Load ("Prefabs/Enemy/" + m_eData.eType.ToString()));
		oEnemy.name = m_eData.eType.ToString ();
		oEnemy.transform.parent = this.transform;
		oEnemy.transform.localPosition = Vector3.zero;
		oEnemy.transform.localScale = Vector3.one;
	}
}
