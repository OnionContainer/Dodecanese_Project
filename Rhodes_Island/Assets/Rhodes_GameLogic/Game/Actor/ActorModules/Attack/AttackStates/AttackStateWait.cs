using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStateWait : AttackStateBase {

	public AttackStateWait(AttackMachine machine):base(machine){

	}

	public override AttackStateType getStateName(){
		return AttackStateType.WAIT;
	}

	private DodTimer _timer = new DodTimer(0);

	public override void update(){

		if (_machine.seeker.targetExist()){//如果存在目标，则切换到前摇阶段
			_machine.changeState(AttackStateType.PREPARE);
		}

	}

	public override void reset(){
		_timer.reset();
	}

	public override float getRemainTime(){
		return _timer.getElapsedTime();
	}

}
