﻿using UnityEngine;
using System.Collections;

public class PanelBaseScript : MonoBehaviour {

	protected MainManagerScript m_sManager = null;
	protected MainDataScript MainData = null;
	protected AdsScript AdsData = null;

	public void SetManager(MainManagerScript manager, MainDataScript data){
		m_sManager = manager;
		MainData = data;
		AdsData = m_sManager.AdsData;
	}

	public virtual void init(){
		this.gameObject.SetActive(true);
		OnInit();
	}
	public virtual void Press(GameObject oBtn){
		SoundManager.Instance.PlaySound(SoundState.Button01);
		OnPress(oBtn);
	}
	public virtual void Exit(){
		OnExit();
	}
	public virtual void OnInit(){
		
	}
	public virtual void OnPress(GameObject oBtn){

	}
	public virtual void OnExit(){
		
	}
	void Start () {
	
	}

	void Update () {
	
	}
}
