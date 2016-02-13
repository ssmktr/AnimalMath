using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour {
	private GameObject m_oCamera;
	public BackLoop m_sBackLoop = null;
	public PlayerScript m_sPlayer = null;
	public GameControlScript m_sGameControl = null;
	public GameUiScript m_sGameUi = null;
	private bool m_bPause = false;
	public bool bPause {
		get{ return m_bPause; }
		set{ m_bPause = value; }
	}
	void Start () {
		if (!GameManager.Instance.bGameLogin) {
			SceneManager.LoadScene ("Title");
			return;
		}
		SetObject ();
		m_sBackLoop = GameData.FindChild (this.transform, "Frest").GetComponent<BackLoop> ();
		m_sGameControl = m_oCamera.transform.FindChild ("GameControl").GetComponent<GameControlScript> ();
		m_sPlayer = m_oCamera.transform.FindChild ("Player").GetComponent<PlayerScript> ();
		m_sGameUi = m_oCamera.transform.FindChild ("PanelUi").GetComponent<GameUiScript> ();
		m_sBackLoop.SetManager (this);
		m_sGameControl.SetManager (this);
		m_sPlayer.SetManager (this);
		m_sGameUi.SetManager (this);
	}
	void Update () {
	}
	void SetObject(){
		m_oCamera = this.transform.FindChild ("Camera").gameObject;
	}
	public void CameraResume(bool bResume){
		m_oCamera.GetComponent<UICamera> ().enabled = bResume;
	}
	public void SetPause(bool bPause){
		m_bPause = bPause;
	}

	#region POPUP
	public void CreatePopupPause(){
		bPause = true;
		CameraResume (false);
		GameObject oPopup = (GameObject)Instantiate (Resources.Load ("Game/Popup/PopupPause"));
		PopupPauseScript sPopup = oPopup.GetComponent<PopupPauseScript> ();
		oPopup.name = "PopupPause";
		oPopup.transform.parent = this.transform;
		oPopup.transform.localPosition = Vector3.zero;
		oPopup.transform.localScale = Vector3.one;
		sPopup.SetManager (this);
		sPopup.Init ();
	}
	#endregion
}
