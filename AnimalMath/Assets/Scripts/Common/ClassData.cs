using UnityEngine;
using System.Collections;

public class PlayerData{

	public PlayerState ePlayerType = PlayerState.Rhino;
	public int nLife = 1;
	public StageLevel eStageLevel = StageLevel.Easy;
	public EffectSkillState eEffect = EffectSkillState.None;
	public MathSkillState eMath = MathSkillState.None;
	public PassiveSkillState ePassive = PassiveSkillState.None;
};

public class OptionData{
	public bool SoundBG = true;
	public bool SoundEffect = true;
}

public class EnemyData{
	public EnemyState eType = EnemyState.Crow;
	public float MoveSpeed = 0.0f;
};

