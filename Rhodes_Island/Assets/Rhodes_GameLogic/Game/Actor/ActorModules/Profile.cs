using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
Profile类是储存单位基本数据（如攻击力、防御力等）的类
它还提供一切用于获取Actor信息的接口
*/
public class Profile : MonoBehaviour,Symbolized {

	#region DodSymbol Implementation
	private DodSymbol _symbol;
	public int getSymbol(){
		if (_symbol == null) {
			_symbol = new DodSymbol();
		}
		return _symbol.data;
	}
	#endregion

	public GameObject actor;

	public void init(Object res){
		//todo..初始化单位数据
	}

	private string _name = "Doctor";

	//地图数据
	private Vector2 _position;
	public Vector2 position{get{return _position;}set{
		_position = value;
		SimpRenderCenter.Instance.moveActorTo(this, _position);
	}}
	private float _speed = 0.5f;
	public float speed{get{return _speed;}}
	public bool isMovingByRoute = true;

	//伤害计算、战斗相关的数据
	public AttackTargetingType attackTargetingType = AttackTargetingType.SINGULAR;//攻击取向类型
	public float perpTime = 3;//前摇时间
	public float afterTime = 1;//后摇时间
	public bool visible = false;//是否可见（隐形的单位不可见）

	public float atkPower = 1;//攻击力
	public float atkScale = 1;//攻击倍率
	public float atkBuff = 1;//攻击百分比提升
	public float armor = 50;//物理防御
	public float magicArmor = 0;//法术抗性

	public float hitpoint = 100;//生命值
	public float maxHitPoint = 100;//最高生命值

	public int blockAbility = 3;//当前可阻挡数
	public int antiBlock = 1;//被阻挡时，对阻挡干员阻挡数的消耗

	public bool isBlockable{get{return this.visible;}}//是否可以被阻挡
	public int battlePriority{get{return 0;}}//被攻击的优先级

	void Start(){
		Debug.Log("create Actor");
		SimpRenderCenter.Instance.createActor(this);
		actor.GetComponent<ActorRoute>().setRoute("no data");
		
		
		
	}

	void FixedUpdate(){

		actor.GetComponent<ActorRoute>().dodUpdate();
		SimpRenderCenter.Instance.moveActorTo(this, _position);
	}

	private void 我是报错警察不准报错(){
		Debug.Log(_name);
	}

}
