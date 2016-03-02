using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class AdsScript : MonoBehaviour {
	public ShowOptions m_sOpt = new ShowOptions ();
	void Start () {
	}
	public void InitAds(){
		Advertisement.Initialize ("104019", true);
	}
	public void PlayAds(){
		m_sOpt.resultCallback = AdsFinished;
		Advertisement.Show (null, m_sOpt);
	}
	void AdsFinished(ShowResult result){
		if (ShowResult.Finished == result) {
			GameManager.Instance.NextScene (GameData.GameScene);
		}
	}
}
