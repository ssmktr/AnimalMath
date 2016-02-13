using UnityEngine;
using System.Collections;

public class PlayerData
{

	public PlayerState ePlayerType = PlayerState.Rhino;
	public int nLife = 1;
	public StageLevel eStageLevel = StageLevel.Easy;
	public SkillData Effect = new SkillData();
	public SkillData Math = new SkillData();
	public SkillData Passive = new SkillData();
};

public class OptionData
{
	public bool SoundBG = true;
	public bool SoundEffect = true;
}

public class EnemyData
{
	public EnemyState eType = EnemyState.Crow;
	public float MoveSpeed = 0.0f;
};

public class SkillData
{
	public SkillState Name = SkillState.None;
	public SkillType Type = SkillType.None;
	public int Price = 0;
	public string Guide = "";
}

