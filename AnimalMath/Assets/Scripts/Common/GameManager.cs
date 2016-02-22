using UnityEngine;
using System.IO;
using System.Text;
using System.Collections;
using UnityEngine.SceneManagement;
using LitJson;



public class GameManager : Singleton<GameManager>
{	
	public bool bGameLogin = false;
	public PlayerState ePlayerState = PlayerState.Rhino;
	public PlayerData playerData = new PlayerData ();
	public OptionData optionData = new OptionData ();
	public int Gold = 9999;
	public Score score = new Score();

	public void Awake ()
	{
		
		Debug.Log ("GameManager Awake");
	}

	public void InitPlayerData()
	{
		playerData = new PlayerData();
	}
	public void NextScene(string strScene){
		SceneManager.LoadScene (strScene);
	}

	#region SAVE_DATA
	public void SaveGameDataToLocal()
	{
		StringBuilder sb = new StringBuilder();
		JsonWriter save = new JsonWriter(sb);
		save.WriteObjectStart();
		save.WritePropertyName("Gold");
		save.Write(Gold);
		save.WritePropertyName("EasyScoreFirst");
		save.Write(score.EasyScoreFirst);
		save.WritePropertyName("EasyScoreSecond");
		save.Write(score.EasyScoreSecond);
		save.WritePropertyName("EasyScoreThird");
		save.Write(score.EasyScoreThird);
		save.WritePropertyName("NormalScoreFirst");
		save.Write(score.NormalScoreFirst);
		save.WritePropertyName("NormalScoreSecond");
		save.Write(score.NormalScoreSecond);
		save.WritePropertyName("NormalScoreThird");
		save.Write(score.NormalScoreThird);
		save.WritePropertyName("HardScoreFirst");
		save.Write(score.HardScoreFirst);
		save.WritePropertyName("HardScoreSecond");
		save.Write(score.HardScoreSecond);
		save.WritePropertyName("HardScoreThird");
		save.Write(score.HardScoreThird);
		save.WriteObjectEnd();
		Debug.Log(sb.ToString());
		PlayerPrefs.SetString("GAMEDATA", sb.ToString());
	}
	public void SaveOptionData ()
	{
		StringBuilder sb = new StringBuilder ();
		JsonWriter save = new JsonWriter (sb);
		save.WriteObjectStart ();
		save.WritePropertyName ("SoundBG");
		save.Write (optionData.SoundBG);
		save.WritePropertyName ("SoundEffect");
		save.Write (optionData.SoundEffect);
		save.WritePropertyName("Language");
		save.Write(optionData.Language);
		save.WriteObjectEnd ();	
//		Console.WriteLine (sb.ToString ());
		Debug.Log (sb.ToString ());
		PlayerPrefs.SetString ("OPTION", sb.ToString ());
	}

	#endregion

	//	#region SAVE_DATA_SAMPLE
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
