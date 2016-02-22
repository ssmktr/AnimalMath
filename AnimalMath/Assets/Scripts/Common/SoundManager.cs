using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : Singleton<SoundManager> {

	public bool bBg = true;
	public bool bSound = true;
	private AudioSource BtnSound;

	Dictionary<SoundState, AudioClip> DicSound = new Dictionary<SoundState, AudioClip> ();

	void Awake(){
		this.gameObject.AddComponent<AudioSource> ();
		Dictionary<SoundState, string> DicTemp = new Dictionary<SoundState, string> ();
		DicTemp.Add (SoundState.Button01, "Sound/Button01");
//		DicTemp.Add (SoundState.Button02, "Sound/Button02");
//		DicTemp.Add (SoundState.Button03, "Sound/Button03");

		for (SoundState eState = 0; eState < SoundState.Max; ++eState) {
			DicSound.Add (eState, (AudioClip)Resources.Load (DicTemp[eState], typeof(AudioClip)));
		}

		BtnSound = gameObject.AddComponent<AudioSource>() as AudioSource;
		BtnSound.volume = 1.0f;
		BtnSound.loop = false;
		BtnSound.playOnAwake = false;
		BtnSound.Stop ();

		Init();
	}
	void Init()
	{
		bBg = GameManager.Instance.optionData.SoundBG;
		bSound = GameManager.Instance.optionData.SoundEffect;
	}
	public void PlaySound(SoundState eState){
		if (bSound) {
			BtnSound.clip = DicSound [eState];
			BtnSound.loop = false;
			BtnSound.Play ();
		}
	}
}
