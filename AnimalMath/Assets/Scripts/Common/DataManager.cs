using UnityEngine;
using System;
using System.Text;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class DataManager : Singleton<DataManager> {
	public List<EnemyData> AllEnemyData = new List<EnemyData>();

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
