using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorSkill : MonoBehaviour {

	public GameObject keeper;//相关的Actor对象

	private SkillTiming _timing = SkillTiming.NONE;//技能发动时机

	private bool _gainPtFromAtk = false;//是否在进行攻击时获得技能点
	private bool _gainPtFromTime = false;//是否随时间获得技能点
	private bool _gainPtFromDef = false;//是否在受击时获得技能点

	private int _maxPt = 30;//技能点上限
	private int _initPt = 15;//初始技能点
	private int _currentPt = 0;//当前技能点
	
	private DodTimer _autoRecoverTimer = new DodTimer(1);//回复技能点的频度（默认1秒）
	private DodTimer _remainTimer = new DodTimer();//技能持续时间

	private bool _isActivated = false;//技能模块已启动
	private bool _isOnStage = false;//技能模块已部署到场上

	public void init(string data){
		//todo..根据传入的数据初始化技能
	}

	public void onDeploy(){
		this._isOnStage = true;
		//具体函数应根据技能数据在技能函数表中映射得到
	}

	public void offStage(){
		this._isOnStage = false;
		//具体函数应根据技能数据在技能函数表中映射得到
	}

	public void update(){
		//按时间获取技能点
		if (_gainPtFromTime && _currentPt < _maxPt && _autoRecoverTimer.isReady()){
			_currentPt += 1;
			_autoRecoverTimer.reset();
		}

		//自动触发
		if (_timing == SkillTiming.AUTOMATIC && _currentPt>=_maxPt) {
			this.activate();
		}

		//自动递减剩余时间
		if (_isActivated && _remainTimer.isReady()) {
			terminate();
		}
	}

	public void activate(){
		if (_currentPt < _maxPt) {
			Debug.LogError("Failed to activate skill");
		}

		this._remainTimer.reset();
		this._isActivated = true;
		//具体函数应根据技能数据在技能函数表中映射得到
	}

	public void terminate(){
		this._isActivated = false;
		//具体函数应根据技能数据在技能函数表中映射得到
	}

	private void 讲真别tm报错了(){
		Debug.Log(_gainPtFromAtk || _gainPtFromDef || _gainPtFromTime);
		Debug.Log(_initPt);
		Debug.Log(_isOnStage);
	}

}

//释放时机
public enum SkillTiming{
	AUTOMATIC,		//自动释放
	MANUAL,			//手动释放
	ON_ATK,			//攻击时释放
	NONE			//被动
}

