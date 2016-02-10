using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager> {
	public PlayerState ePlayerState = PlayerState.Rhino;
	#region SAVE_DATA


	#endregion

//	#region SAVE_DATA
//	public void SaveData(){
//		StringBuilder sb = new StringBuilder ();
//		JsonWriter save = new JsonWriter (sb);
//		save.WriteObjectStart ();
//		save.WritePropertyName ("userlv");
//		save.Write (Level);
//		save.WritePropertyName ("nickname");
//		save.Write (NickName);
//		save.WritePropertyName ("gold");
//		save.Write (Gold);
//		save.WritePropertyName ("dp");
//		save.Write (Dp);
//		save.WritePropertyName ("heart");
//		save.Write (Heart);
//		save.WritePropertyName ("logintime");
//		save.Write (LoginTime.ToString());
//		save.WritePropertyName ("logouttime");
//		save.Write (LogoutTime.ToString());
//		save.WritePropertyName ("hearttime");
//		save.Write (fHeartTime);
//		if (null != GameManager.Instance.CurAnimal) {
//			save.WritePropertyName ("curanimal");
//			save.WriteObjectStart ();
//			save.WritePropertyName ("id");
//			save.Write (CurAnimal.iId);
//			save.WritePropertyName ("name");
//			save.Write (CurAnimal.Name);
//			save.WritePropertyName ("type");
//			save.Write (CurAnimal.Type.ToString());
//			save.WritePropertyName ("hp");
//			save.Write (CurAnimal.Hp);
//			save.WritePropertyName ("atk");
//			save.Write (CurAnimal.Atk);
//			save.WritePropertyName ("asp");
//			save.Write (CurAnimal.Asp);
//			save.WritePropertyName ("life");
//			save.Write (CurAnimal.Life);
//			save.WriteObjectEnd ();
//		}
//		save.WriteObjectEnd ();
//		Console.WriteLine (sb.ToString ());
//		Debug.Log (sb.ToString());
//		PlayerPrefs.SetString ("LOGIN", sb.ToString ());
//		//		var sr = File.CreateText("Assets/Resources/Tables/LoginData.json"); 
//		//		sr.WriteLine(sb.ToString ());
//		//		sr.Close();
//	}
//	#endregion
//
//	void OnDisable(){
//		SaveData ();
//	}

}
