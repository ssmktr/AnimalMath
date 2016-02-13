using UnityEngine;
using System.Collections;

public class PlayerData{

	public PlayerState ePlayerType = PlayerState.Rhino;
	public int nLife = 0;
	public EffectSkillState eEffect = EffectSkillState.None;
	public MathSkillState eMath = MathSkillState.None;
	public PassiveSkillState ePassive = PassiveSkillState.None;
};

<<<<<<< HEAD
public class OptionData{
	public bool SoundBG = true;
	public bool EffectBG = true;
	public bool initData = false;
}
=======
public class EnemyData{
	public EnemyState eType = EnemyState.Crow;
	public float MoveSpeed = 0.0f;
};
>>>>>>> 0d7beacabd7e95f6df19f5d9c1b94c6c08e3331d

