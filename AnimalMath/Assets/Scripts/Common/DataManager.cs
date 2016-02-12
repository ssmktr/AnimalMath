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
		for (EnemyState eState = 0; eState < EnemyState.Max; ++eState) {
			EnemyData eData = new EnemyData ();
			eData.eType = eState;
			eData.MoveSpeed = 1.0f;
			AllEnemyData.Add (eData);
		}
	}
}
