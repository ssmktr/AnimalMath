using UnityEngine;
using System.Collections;

public class PlayerData{

	public string sPlayerType = "";
	public int nLife = 0;
	public EffectSkillState eEffect = EffectSkillState.None;
	public MathSkillState eMath = MathSkillState.None;
	public PassiveSkillState ePassive = PassiveSkillState.None;
};

public class EnemyData{
	public EnemyState eType = EnemyState.Crow;
	public float MoveSpeed = 0.0f;
};

