using UnityEngine;
using System.Collections;

public class PopupBaseScript : MonoBehaviour {
	public delegate void CallBackOk();
	public CallBackOk CallOk = null;
	protected MainManagerScript m_sManager = null;
	protected MainDataScript MainData = null;
	public void SetManager(MainManagerScript manager, MainDataScript data){
		m_sManager = manager;
		MainData = data;
	}
	public virtual void Init(){
		OnInit ();
	}
	public virtual void Press(GameObject oBtn){
//		SoundManager.Instance.PlaySound(SoundState.Button01);
		OnPress (oBtn);
	}
	public virtual void Exit(){
		OnExit ();
		Destroy (this.gameObject);
		m_sManager.CameraResume (true);
		MainData.POPUP = PopupState.None;
	}
	public virtual void OnInit(){
		
	}
	public virtual void OnPress(GameObject oBtn){
		
	}
	public virtual void OnExit(){
		
	}
}
