using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ActorRoute : MonoBehaviour {

	public GameObject actor;

	private List<Vector2> _route;
	private int _lastApproach = 0;
	
	private Profile _profile;
	private DodTimer _timeFaultChecker;
	private bool _routeFinished = false;

	private MNCEmitter _emitter;

	void Start(){
		_emitter = new MNCEmitter();
	}
	

	public void setRoute(string data){
		_route = new List<Vector2>(new Vector2[]{
			new Vector2(1,1),
			new Vector2(5,5),
			new Vector2(7,7),
			new Vector2(10,0),
			new Vector2(0,0)
		});
		Debug.Log("Set Route");
		_timeFaultChecker = new DodTimer();
		_profile = actor.GetComponent<Profile>();
		_profile.position = _route[0];
		_lastApproach = 1;
	}

	void FixedUpdate(){
		if (_routeFinished) {//不能继续前进
			_timeFaultChecker.reset();
			return;
		}

		if (!_profile.moveAble) {//判断是否能够进行移动
			_timeFaultChecker.reset();
			return;
		}

		Vector2 target;
		try {
			target = _route[_lastApproach + 1];
		} catch (IndexOutOfRangeException) {
			Debug.Log("can't approach");
			return;
		}
		
		// Debug.Log(_timeFaultChecker);
		float actualSpeed = _profile.speed * _timeFaultChecker.getElapsedTime();
		_timeFaultChecker.reset();
		_profile.position = Vector2.MoveTowards(_profile.position, target, actualSpeed);

		_emitter.pos(_profile.position);
		_emitter.emitEvent(actor, ActorType.NONE);

		if (_profile.position == target){
			_setApproach();
		}
	}

	private void _setApproach(){
		_lastApproach += 1;
		if (_lastApproach + 1 >= _route.Count) {
			_routeFinished = true;
		}
	}
}
