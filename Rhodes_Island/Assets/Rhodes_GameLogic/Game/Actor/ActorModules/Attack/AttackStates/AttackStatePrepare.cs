using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStatePrepare  : AttackStateBase {
	
	private DodTimer _timer;
	private GameObject _singularTarget;

	public AttackStatePrepare(AttackMachine machine):base(machine){
		_timer = new DodTimer(machine.profile.perpTime);
		
	}

	public override AttackStateType getStateName(){
		return AttackStateType.PREPARE;
	}



	public override void update(){
		
		AttackTargetingType targetingType = _machine.profile.attackTargetingType;
		ActorSeeker seeker = _machine.seeker;
		Profile profile = _machine.profile;


		bool goback = (targetingType==AttackTargetingType.NONE) ||//索敌类型为无
		(seeker.targetExist()) ||//找不到敌人
		(targetingType == AttackTargetingType.SINGULAR && _singularTarget != seeker.getFocus());//目标丢失
		if (goback) {
			_machine.changeState(AttackStateType.WAIT);
			return;
		}

		if (_timer.isReady()) {//如果已准备好，则发动攻击，进入后摇
			_machine.launchAttack();
			_machine.changeState(AttackStateType.AFTER);
		}

	}

	public override void reset(){
		_timer.interval = _machine.profile.perpTime;
		_timer.reset();
	}

	public override float getRemainTime(){
		return _timer.getElapsedTime();
	}

}
