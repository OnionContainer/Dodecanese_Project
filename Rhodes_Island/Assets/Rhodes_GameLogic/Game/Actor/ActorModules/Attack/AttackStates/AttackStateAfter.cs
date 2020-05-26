using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStateAfter :  AttackStateBase {

	private DodTimer _timer = new DodTimer(0);

	public AttackStateAfter(AttackMachine machine):base(machine){
		this._timer = new DodTimer(machine.profile.afterTime);
	}

	public override AttackStateType getStateName(){
		return AttackStateType.AFTER;
	}

	public override void enter(){
		
	}

	public override void update(){

		if (_timer.isReady()) {
			_machine.changeState(AttackStateType.WAIT);
		}

	}

	public override void reset(){
		_timer.reset();
	}

	public override float getRemainTime(){
		return 3.1415926f;
	}

}
