using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStatePrepare  : AttackStateBase {
	
	private DodTimer _timer;
	private GameObject _singularTarget = null;

	public AttackStatePrepare(AttackMachine machine):base(machine){
		_timer = new DodTimer(machine.profile.perpTime);
		
	}

	public override AttackStateType getStateName(){
		return AttackStateType.PREPARE;
	}

	public override void enter(){

	}

	public override void update(){
		//todo..考虑使用函数式思路，直接按照不同的攻击类型替换update函数内容，不进行if判定
		//此处代码实现singular逻辑(单体攻击)

		if (!_machine.profile.nodeCapture.Contains(_singularTarget)) {
			_machine.changeState(AttackStateType.WAIT);
			return;
		}

		if (_timer.isReady()) {
			_machine.launchAttack();
			_machine.changeState(AttackStateType.AFTER);
			return;
		}

	}

	public override void reset(){
		_timer.interval = _machine.profile.perpTime;
		_timer.reset();
		_singularTarget = _machine.profile.nodeCapture[0];
	}

	public override float getRemainTime(){
		return _timer.getElapsedTime();
	}

}
