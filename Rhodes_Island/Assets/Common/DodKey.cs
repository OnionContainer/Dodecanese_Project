using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//用来从字符串转换到enum值的工具类
public class KeyMapping{
	private static KeyMapping _instance;
	private static KeyMapping instance{get{
		if (_instance == null) {
			_instance = new KeyMapping();
		}
		return _instance;
	}}

	private DodReadOnlyDictionary<string, ActorType> actorType;

	private KeyMapping(){
		Dictionary<string, ActorType> actorTypeOrigin = new Dictionary<string, ActorType>();
		actorTypeOrigin.Add("NONE", ActorType.NONE);
		actorTypeOrigin.Add("OPERATOR", ActorType.OPERATOR);
		actorTypeOrigin.Add("MONSTER", ActorType.MONSTER);
		actorTypeOrigin.Add("TOKEN", ActorType.TOKEN);
		actorTypeOrigin.Add("ANY", ActorType.ANY);
		actorType = new DodReadOnlyDictionary<string, ActorType>(actorTypeOrigin);
	}

	//public part
	public static ActorType ActorTypeToEnum(string str){
		return instance.actorType[str];
	}
}

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
