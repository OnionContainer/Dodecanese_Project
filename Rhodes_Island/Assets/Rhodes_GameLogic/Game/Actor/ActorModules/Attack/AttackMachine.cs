using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMachine : MonoBehaviour {

	public GameObject actor;
	public Profile profile;

	private Dictionary<AttackStateType, AttackStateBase> _states;
	private AttackStateBase _currentState;
	public ActorSeeker seeker;

	public void init(GameObject actor){
		this.profile = actor.GetComponent<Profile>();
		this._states.Add(AttackStateType.WAIT, new AttackStateWait(this));
		this._states.Add(AttackStateType.PREPARE, new AttackStatePrepare(this));
		this._states.Add(AttackStateType.AFTER, new AttackStateAfter(this));
		this._currentState = this._states[AttackStateType.WAIT];

		//todo..根据profile中的属性选择ActorSeeker的对应子类并进行初始化
		this.seeker = null;
	}

	public void update(){
		_currentState.update();
	}

	public void changeState(AttackStateType type){
		_currentState = _states[type];
		_currentState.reset();
	}

	public void launchAttack(){
		//todo..进行攻击
	}

}
