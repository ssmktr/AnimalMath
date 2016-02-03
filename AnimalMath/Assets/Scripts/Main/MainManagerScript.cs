using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class MainManagerScript : MonoBehaviour {

	private Dictionary<SceneState, PanelBaseScript> DicScene =  new Dictionary<SceneState, PanelBaseScript>();
	private GameObject m_oCamera;

	public MainDataScript MainData;

	void Start(){

	}

	void Update(){
	}

	void PanelInit(){
		m_oCamera = this.transform.FindChild("Camera").gameObject;
		MainData = new MainDataScript();
	}
}
