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

public enum EffectSkillState
{
	None,
	Accuracy,
	Bomb,
	RoseOfWinds,
}

public enum MathSkillState
{
	None,
	Clock,
	Key,
	Book
}

public enum PassiveSkillState
{
	None,
	MedalRibbon,
	Chest,
	Life
}

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