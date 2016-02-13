using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class MainManagerScript : MonoBehaviour
{

	private Dictionary<SceneState, PanelBaseScript> DicScene = new Dictionary<SceneState, PanelBaseScript> ();
	private GameObject m_oCamera;

	public MainDataScript MainData;

	void Awake()
	{
//		DataManager.Instance.LoadData();
	}

	void Start ()
	{
		PanelInit ();

	}

	void Update ()
	{
	}

	void PanelInit ()
	{
		m_oCamera = this.transform.FindChild ("Camera").gameObject;
		MainData = new MainDataScript ();

		Dictionary<SceneState, string> dicTemp = new Dictionary<SceneState, string> ();
		dicTemp.Add (SceneState.Main, "PanelMain");
		dicTemp.Add (SceneState.GameReady, "PanelReady");

		for (SceneState eState = 0; eState < SceneState.Max; eState++) {
			DicScene.Add (eState, m_oCamera.transform.FindChild (dicTemp [eState]).GetComponent<PanelBaseScript> ());
			DicScene [eState].SetManager (this, MainData);
		}
		SetScene(SceneState.Main);
	}

	void AllPanelOff ()
	{
		for (SceneState eState = 0; eState < SceneState.Max; eState++) {
			DicScene [eState].gameObject.SetActive (false);
		}
	}

	public void SetScene (SceneState eState)
	{
		AllPanelOff();
		DicScene[eState].init();
	}
	public void CameraResume(bool bResume){
		m_oCamera.GetComponent<UICamera>().enabled = bResume;
	}
	public PopupBaseScript CreatePopup(PopupState eState){
		CameraResume(false);
		MainData.POPUP = eState;
		GameObject oPopup = (GameObject)Instantiate(Resources.Load("Main/Popup/" + eState.ToString()));
		PopupBaseScript sPopup =  oPopup.GetComponent<PopupBaseScript>();
		oPopup.name = eState.ToString();
		oPopup.transform.parent = this.transform;
		oPopup.transform.localPosition = Vector3.zero;
		oPopup.transform.localScale = Vector3.zero;
		sPopup.SetManager(this, MainData);
		sPopup.Init(); 
		return sPopup;
	}
		
}
