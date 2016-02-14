using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PopupResultScript : MonoBehaviour {
	private GameScript m_sGame = null;
	private UILabel m_tDif;
	private UILabel m_tSuccess;

	public void SetManager(GameScript manager){
		m_sGame = manager;
	}
	public void Init(){
		GameData.SetBtn (this.transform, "BtnExit", "Press", this);
		m_tDif = this.transform.FindChild ("tDif").GetComponent<UILabel> ();
		m_tSuccess = this.transform.FindChild ("tScore").GetComponent<UILabel> ();
		m_tDif.text = GameManager.Instance.playerData.eStageLevel.ToString ();
		int iSuccess = m_sGame.m_sGameUi.GetSuccess ();
		int iTime = (int)m_sGame.m_sGameUi.GetTime ();
		if (StageLevel.Easy == GameManager.Instance.playerData.eStageLevel) {
			m_tSuccess.text = string.Format ("{0} x 10 + {1} = \n{2}", iSuccess, iTime, iSuccess * 10 + iTime);
		} else if (StageLevel.Normal == GameManager.Instance.playerData.eStageLevel) {
			m_tSuccess.text = string.Format ("{0} x 100 + {1} = \n{2}", iSuccess, iTime, iSuccess * 100 + iTime);
		} else if (StageLevel.Hard == GameManager.Instance.playerData.eStageLevel) {
			m_tSuccess.text = string.Format ("{0} x 1000 + {1} = \n{2}", iSuccess, iTime, iSuccess * 1000 + iTime);
		} 
		m_tSuccess.text = m_tSuccess.text.Replace ("\\n", "\n");
	}
	void Press(GameObject oBtn){
		if ("BtnExit" == oBtn.name) {
			Destroy (this.gameObject);
			SceneManager.LoadScene ("Main");
		}
	}
	void Start () {
	}
	void Update () {
	}
}
