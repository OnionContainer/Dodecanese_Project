using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ActorRoute : MonoBehaviour {

	public GameObject actor;

	[SerializeField]
	private List<Vector2> _route;
	private int _lastApproach = 0;
	
	private Profile _profile;
	private DodTimer _timeFaultChecker;
	private bool _routeFinished = false;


	public void setRoute(string data){
		_route = new List<Vector2>(new Vector2[]{
			new Vector2(5,5),
			new Vector2(7,7),
			new Vector2(10,0),
			new Vector2(0,0)
		});
		_timeFaultChecker = new DodTimer();
		_profile = actor.GetComponent<Profile>();
		_profile.position = _route[0];
		_lastApproach = 1;
	}

	public void dodUpdate(){
		if (_routeFinished) {//不能继续前进
			return;
		}
		Vector2 target = _route[_lastApproach + 1];
		float actualSpeed = _profile.speed * _timeFaultChecker.getElapsedTime();
		_timeFaultChecker.reset();
		_profile.position = Vector2.MoveTowards(_profile.position, target, actualSpeed);
		if (_profile.position == target){
			_setApproach();
		}
	}

	private void _setApproach(){
		_lastApproach += 1;
		if (_lastApproach >= _route.Count) {
			_routeFinished = true;
		}
	}
}
