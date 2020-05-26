﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


/*
Profile类是储存单位基本数据（如攻击力、防御力等）的类
它还提供一切用于获取Actor信息的接口
*/
public class Profile : MonoBehaviour,Symbolized {
	public GameObject actor;

	#region DodSymbol Implementation
	private DodSymbol _symbol;
	public int getSymbol(){
		if (_symbol == null) {
			_symbol = new DodSymbol();
		}
		return _symbol.data;
	}
	#endregion

	#region 测试数据
	public string dataName = "";
	
	#endregion

	#region 基础数据
	private string _name = "Doctor";
	public ActorType actorType = ActorType.OPERATOR;
	#endregion

	#region 几何数据


	[SerializeField]
	private IntVec _nodePosition = new IntVec(0,0);//干员部署到的位置（敌人的这项属性恒为-1，-1）
	public IntVec nodePosition{get{
		return _nodePosition;
	}set{
		_nodePosition = value;
		nodeMapper.origin = _nodePosition;
	}}

	[SerializeField]
	private Vector2 _position;
	public Vector2 position{get{return _position;}set{
		_position = value;
	}}
	private float _speed = 2f;
	public float speed{get{return _speed;}set{
		//todo..
		_speed = value;
	}}
	#endregion

	#region 伤害计算、战斗相关的数据
	public AttackTargetingType attackTargetingType = AttackTargetingType.SINGULAR;//攻击取向类型
	public float perpTime = 3;//前摇时间
	public float afterTime = 1;//后摇时间
	public bool visible = true;//是否可见（隐形的单位不可见）

	public float atkPower = 1;//攻击力
	public float atkScale = 1;//攻击倍率
	public float atkBuff = 1;//攻击百分比提升
	public float armor = 50;//物理防御
	public float magicArmor = 0;//法术抗性

	public float hitpoint = 100;//生命值
	public float maxHitPoint = 100;//最高生命值

	public bool stunned = false;//被眩晕
	public bool freezed = false;//被冰冻
	public bool moveAble{get{//可以移动
		return !isBlocked && !stunned && !freezed;
		// return false;
	}}

	public int blockAbility = 3;//当前可阻挡数
	public int antiBlock = 1;//被阻挡时，对阻挡干员阻挡数的消耗
	public List<GameObject> blocks = new List<GameObject>();//正在阻挡的敌人
	public GameObject beBlockedBy = null;//被谁阻挡
	public bool canBlock{get{//是否可以进行阻挡
		return blockAbility > 0;//考虑被眩晕等其他因素
	}}

	public NodeMapper nodeMapper = new NodeMapper();//攻击范围数据
	public List<GameObject> nodeCapture = new List<GameObject>();//已捕捉到的敌人

	public bool isBlockable{get{return this.visible;}}//是否可以被阻挡
	public bool isBlocked{get{return beBlockedBy!=null;}}//是否已被阻挡
	public int battlePriority{get{return 0;}}//被攻击的优先级
	#endregion

	#region 资源控制
	private bool _resourceLoaded = false;
	public void loadRes(string res){
		_resourceLoaded = true;
	}
	#endregion

	void Awake(){
		
	}

	void Start(){
		Debug.Log("create Actor");
		actor.GetComponent<ActorRoute>().setRoute("no data");
		nodeMapper.shifts = new IntVec[]{
			new IntVec(0,0),
			new IntVec(1,1),
			new IntVec(2,2)
		};
		try {
			//todo..Load Data File & Setup
			// string jsonfile = File.ReadAllText("Assets/Resources/TestJson/" + dataName + ".json");
			// Debug.Log(jsonfile);
			// ProfileJsonFormat jk = JsonUtility.FromJson<ProfileJsonFormat>(jsonfile);
			// jk.logData();
		} catch (FileNotFoundException) {
			Debug.LogWarning("File " + dataName + " Not Found");
		}
		
	}

	void FixedUpdate(){
		//也许黑板类没必要update
	}

	private void 我是报错警察不准报错(){
		Debug.Log(_name + _resourceLoaded);
	}
}


class ProfileJsonFormat{
	public int k = 0;

	public void logData(){
		Debug.Log("Kqoweuhffffffffffoqiwehf:" + k);
	}
}