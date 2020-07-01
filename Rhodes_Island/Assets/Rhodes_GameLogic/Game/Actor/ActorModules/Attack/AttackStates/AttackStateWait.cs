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
		if (_machine.profile.nodeCapture.Count > 0) {
			_machine.changeState(AttackStateType.PREPARE);
		}
	}

	public override void enter(){
		
	}

	public override void reset(){
		_timer.interval = _machine.profile.perpTime;
		_timer.reset();
	}

	public override float getRemainTime(){
		return _timer.getElapsedTime();
	}

}
