using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMachine : MonoBehaviour {

	public GameObject actor;
	public Profile profile;

	private Dictionary<AttackStateType, AttackStateBase> _states;
	private AttackStateBase _currentState;

	void Awake(){
		_states = new Dictionary<AttackStateType, AttackStateBase>();
		this._states.Add(AttackStateType.WAIT, new AttackStateWait(this));
		this._states.Add(AttackStateType.PREPARE, new AttackStatePrepare(this));
		this._states.Add(AttackStateType.AFTER, new AttackStateAfter(this));
		this._currentState = this._states[AttackStateType.WAIT];
	}

	void Start(){
		// this.seeker.nodeMapper.origin = profile.nodePosition.clone();
	}

	void FixedUpdate(){
		_currentState.update();
	}

	public void changeState(AttackStateType type){
		Debug.Log(type.ToString());
		_currentState = _states[type];
		_currentState.reset();//todo..remove enter
	}

	public void launchAttack(){
		Debug.Log("ATTACK");
		//todo..进行攻击
	}

}


