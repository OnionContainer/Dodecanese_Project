using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackStateBase{

	protected AttackMachine _machine;

	public AttackStateBase(AttackMachine machine){
		_machine = machine;
	}

	public abstract AttackStateType getStateName();

	public abstract void enter();

	public abstract void update();

	public abstract void reset();

	public abstract float getRemainTime();
}


public enum AttackStateType{
	WAIT,
	PREPARE,
	AFTER
}