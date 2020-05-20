using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActorType{
	NONE,
	OPERATOR,
	MONSTER,
	TOKEN,
	ANY
}

public enum CampType{
	NONE,
	SELF,
	ENEMY
}

public enum DamageType{
	PHYSICAL,
	MAGICAL,
	TRUE
}

public enum AttackTargetingType{
	ALL,		//攻击范围内的所有敌人（天火）
	PRIORITY,	//攻击范围内优先级高的敌人（真银斩）
	SINGULAR,	//只攻击一个敌人(杰西卡)
	NONE		//不攻击
}

public enum BuffTag{
	BENIGN,		//增益
	MALIGNANT	//减益
}
