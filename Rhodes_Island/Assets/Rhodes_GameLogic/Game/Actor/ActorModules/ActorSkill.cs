using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
#region old

// public class ActorSkill : MonoBehaviour {

// 	public GameObject keeper;//相关的Actor对象

// 	private SkillTiming _timing = SkillTiming.NONE;//技能发动时机

// 	private bool _gainPtFromAtk = false;//是否在进行攻击时获得技能点
// 	private bool _gainPtFromTime = false;//是否随时间获得技能点
// 	private bool _gainPtFromDef = false;//是否在受击时获得技能点

// 	private int _maxPt = 30;//技能点上限
// 	private int _initPt = 15;//初始技能点
// 	private int _currentPt = 0;//当前技能点
	
// 	private DodTimer _autoRecoverTimer = new DodTimer(1);//回复技能点的频度（默认1秒）
// 	private DodTimer _remainTimer = new DodTimer();//技能持续时间


// 	public void init(string data){
// 		//todo..根据传入的数据初始化技能
// 	}


// 	public void activate(){
// 		if (_currentPt < _maxPt) {
// 			Debug.LogError("Failed to activate skill");
// 		}

// 		this._remainTimer.reset();
// 		this._isActivated = true;
// 		//具体函数应根据技能数据在技能函数表中映射得到
// 	}

// 	public void terminate(){
// 		this._isActivated = false;
// 		//具体函数应根据技能数据在技能函数表中映射得到
// 	}

// 	private void 讲真别tm报错了(){
// 		Debug.Log(_gainPtFromAtk || _gainPtFromDef || _gainPtFromTime);
// 		Debug.Log(_initPt);
// 	}

// }

// //释放时机
// public enum SkillTiming{
// 	AUTOMATIC,		//自动释放
// 	MANUAL,			//手动释放
// 	ON_ATK,			//攻击时释放
// 	NONE			//被动
// }

#endregion



/*
技能触发方式：
自动触发
	每帧检查技能点状态，满则触发
手动触发
	接收到事件时触发
攻击触发
	收到攻击前事件时检查技能点状态，满则触发

工作内容：
把数据堆进profile
实现（默认的）自动触发
实现一个加攻击力的技能
实现强力击

*/

public class ActorSkill : MonoBehaviour{

	private static Dictionary<string, SkillSetter> setters = new Dictionary<string, SkillSetter>();

	public GameObject actor;
	public Profile profile;
	public UnityAction launchSkill;//技能发动时启用的函数
	public UnityAction terminateSkill;//技能结束时启用的函数
	public UnityAction update = ()=>{};//每帧调用的函数

	/*根据输入的技能id，获取对应的技能数据，并初始化自身和对应profile中的相关数据*/
	public void loadSkill(string skillID){
		/*
		读取技能id
		查看是否已存在对应的setter
			否：创建新的SkillSetter并加入setter列表
		运行setter.setThisActor
		*/
		if (!setters.ContainsKey(skillID)) {
			setters.Add(skillID, SkillSetter.getSkillSetter(skillID));
		}
		setters[skillID].setThisActor(actor);
	}

	void FixedUpdate(){
		update();
	}
}

[Serializable]
class SkillData{

	public string id = "default";

}

abstract class SkillSetter{


	public static SkillSetter getSkillSetter(string data) {
		// SkillData skilldata = JsonUtility.FromJson<SkillData>(data);//正式代码应该为从json文件转化为对象，此处使用默认对象
		SkillData skilldata = new SkillData();//temp
		if (skilldata.id == "default") {
			return new Skill_Default(skilldata);
		}
		return null;
	}


	public SkillData skilldata;
	public SkillSetter(SkillData skilldata){
		this.skilldata = skilldata;
	}

	public abstract void setThisActor(GameObject actor);
}

class Skill_Default : SkillSetter{

	public Skill_Default(SkillData data):base(data){}

	public override void setThisActor(GameObject actor){
		ActorSkill skill = actor.GetComponent<ActorSkill>();
		skill.launchSkill = ()=>{Debug.Log("default skill launched");};
		skill.terminateSkill = ()=>{Debug.Log("default skill terminated");};
	}
}
