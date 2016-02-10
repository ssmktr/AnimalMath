using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour {

	private GameObject m_oCamera;
	public PlayerScript m_sPlayer = null;
	public GameControlScript m_sGameControl = null;

	void Start () {
		SetObject ();
		m_sGameControl = m_oCamera.transform.FindChild ("GameControl").GetComponent<GameControlScript> ();
		m_sPlayer = m_oCamera.transform.FindChild ("Player").GetComponent<PlayerScript> ();
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
