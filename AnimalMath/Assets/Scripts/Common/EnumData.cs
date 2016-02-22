using UnityEngine;
using System.Collections;

public enum SoundState
{
	Button01 = 0,
	Button02,
	Button03,
	Max}
;

public enum SceneState
{
	//	Title,
	Main,
	GameReady,
	//	GameStart,
	Max}
;

public enum PopupState
{
	None = 0,

};

public enum SkillState
{
	None = 0,
	Accuracy,
	Bomb,
	RoseOfWinds,
	Clock,
	Key,
	Book,
	MedalRibbon,
	Chest,
	Life,
	MAX
};

public enum SkillType
{
None,
	Effect,
	Math,
	Passive
};

public enum PlayerState
{
	Rhino,
	Sheep,
};

public enum StageLevel
{
	Easy,
	Normal,
	Hard
};

public enum CalcMark
{
	Sum = 0,
	Sub,
	Mul,
	Div,
};

public enum EnemyState
{
	Crow = 0,
	Mouse,
	Peacock,
	Rattlesnake,
	Snail,
	MoveSnake,
	Max}
;