using UnityEngine;
using System;
using System.Text;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class DataManager : Singleton<DataManager> {
	
	public List<EnemyData> AllEnemyData = new List<EnemyData>();
	public List<SkillData> AllSkillData = new List<SkillData>();
	public Dictionary<SkillState, SkillData> dicSkillData = new Dictionary<SkillState, SkillData>();

	public void LoadData()
	{
		LoadSkillData();
	}
	public void LoadOptionData(){
		string strOption = PlayerPrefs.GetString("OPTION");
		Debug.Log("LoadOptionData : " + strOption);
		if("" != strOption){
			JsonData GetData = JsonMapper.ToObject (strOption);
			GameManager.Instance.optionData.SoundBG = bool.Parse(GetData["SoundBG"].ToString());
			GameManager.Instance.optionData.SoundEffect = bool.Parse(GetData["SoundEffect"].ToString());
		}
	}
	public void LoadSkillData(){
		AllSkillData.Clear ();
		Debug.Log("LoadSkillData");
		TextAsset JsonData = (TextAsset)Resources.Load ("Tables/SkillData");
		JsonData GetData = JsonMapper.ToObject (JsonData.ToString ());
		for (int i = 0; i < GetData.Count; ++i) {
			SkillData eData = new SkillData ();
			eData.Name = (SkillState)Enum.Parse(typeof(SkillState), GetData[i]["name"].ToString());
			eData.Type = (SkillType)Enum.Parse(typeof(SkillType), GetData[i]["type"].ToString());
			eData.Price = int.Parse(GetData[i]["price"].ToString());
			eData.Guide = GetData[i]["guide"].ToString();
			AllSkillData.Add(eData);
			dicSkillData.Add(eData.Name, eData);
		}
	}

	#region LOAD_DATA_SAMPLE
//	public void LoadData(){
//		LoadEnemy ();
//		LoadMyAnimal ();
//		LoadShopData ();
//		LoadInventoryData();
//	}
//	public void LoadLoing(){
//		string strLogin = PlayerPrefs.GetString ("LOGIN");
//		if ("" != strLogin) {
//			JsonData GetData = JsonMapper.ToObject (strLogin);
//			GameManager.Instance.Level = int.Parse (GetData ["userlv"].ToString ());
//			GameManager.Instance.NickName = GetData ["nickname"].ToString();
//			GameManager.Instance.Gold = int.Parse (GetData ["gold"].ToString ());
//			GameManager.Instance.Dp = int.Parse (GetData ["dp"].ToString ());
//			GameManager.Instance.Heart = int.Parse (GetData ["heart"].ToString ());
//			GameManager.Instance.LoginTime = DateTime.Parse (GetData ["logintime"].ToString ());
//			GameManager.Instance.LogoutTime = DateTime.Parse (GetData ["logouttime"].ToString ());
//			GameManager.Instance.fHeartTime = float.Parse (GetData ["hearttime"].ToString ());
//			if (null != GameManager.Instance.CurAnimal) {
//				JsonData GetCurAnimal = GetData ["curanimal"];
//				GameManager.Instance.CurAnimal.iId = GetCurAnimal ["id"].ToString ();
//				GameManager.Instance.CurAnimal.Name = GetCurAnimal ["name"].ToString ();
//				GameManager.Instance.CurAnimal.Type = (AnimalType)Enum.Parse(typeof(AnimalType), GetCurAnimal ["type"].ToString ());
//				GameManager.Instance.CurAnimal.Hp = float.Parse(GetCurAnimal ["hp"].ToString ());
//				GameManager.Instance.CurAnimal.Atk = float.Parse(GetCurAnimal ["atk"].ToString ());
//				GameManager.Instance.CurAnimal.Asp = float.Parse(GetCurAnimal ["asp"].ToString ());
//				GameManager.Instance.CurAnimal.Life = int.Parse(GetCurAnimal ["life"].ToString ());
//			}
//		}
//	}
	#endregion

	public void LoadEnemyData(){
		AllEnemyData.Clear ();
		TextAsset JsonData = (TextAsset)Resources.Load ("Tables/EnemyData");
		JsonData GetData = JsonMapper.ToObject (JsonData.ToString ());
		for (int i = 0; i < GetData.Count; ++i) {
			EnemyData eData = new EnemyData ();
			eData.eType = (EnemyState)Enum.Parse (typeof(EnemyState), GetData [i] ["type"].ToString ());
			eData.MoveSpeed = float.Parse (GetData [i] ["movespeed"].ToString ());
			AllEnemyData.Add (eData);
		}
	}
}
