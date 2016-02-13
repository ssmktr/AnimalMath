using UnityEngine;
using System.Collections;

public class PlayerData{

	public PlayerState ePlayerType = PlayerState.Rhino;
	public int nLife = 0;
	public EffectSkillState eEffect = EffectSkillState.None;
	public MathSkillState eMath = MathSkillState.None;
	public PassiveSkillState ePassive = PassiveSkillState.None;
}

public class OptionData{
	public bool SoundBG = true;
	public bool EffectBG = true;
	public bool initData = false;
}

