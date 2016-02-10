using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour {
	private GameObject m_oCamera;
	public BackLoop m_sBackLoop = null;
	public PlayerScript m_sPlayer = null;
	public GameControlScript m_sGameControl = null;
	private bool m_bPause = false;
	public bool bPause {
		get{ return m_bPause; }
		set{ m_bPause = value; }
	}
	void Start () {
		SetObject ();
		m_sBackLoop = GameData.FindChild (this.transform, "Frest").GetComponent<BackLoop> ();
		m_sGameControl = m_oCamera.transform.FindChild ("GameControl").GetComponent<GameControlScript> ();
		m_sPlayer = m_oCamera.transform.FindChild ("Player").GetComponent<PlayerScript> ();
		m_sBackLoop.SetManager (this);
		m_sGameControl.SetManager (this);
		m_sPlayer.SetManager (this);
	}
	void Update () {
	}
	void SetObject(){
		m_oCamera = this.transform.FindChild ("Camera").gameObject;
	}
	public void CameraResume(bool bResume){
		m_oCamera.GetComponent<UICamera> ().enabled = bResume;
	}
}
