using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ActorRoute : MonoBehaviour {

	public GameObject actor;

	[SerializeField]
	private List<Vector2> _route;
	private int _lastApproach = 0;//最后一个已经到达的节点的index
	
	public Profile profile;
	private DodTimer _timeFaultChecker;
	private bool _routeFinished = false;

	private MNCEmitter _emitter;
	//todo..在角色入场的时机发布一次地图节点进入事件

	void Start(){
		_emitter = new MNCEmitter();
	}
	

	public void setRoute(){//设置行动路线
		_route = new List<Vector2>(new Vector2[]{
			new Vector2(0,0),
			new Vector2(5f,5f),
		});
		_timeFaultChecker = new DodTimer();
		profile.position = _route[0];
		_lastApproach = 0;
		
	}

	public void setRoute(IEnumerable<Vector2> data) {
		_route = new List<Vector2>(data);
		_timeFaultChecker = new DodTimer();
		profile.position = _route[0];
		_lastApproach = 0;
	}

	

	void FixedUpdate(){
		if (_routeFinished) {//不能继续前进
			_timeFaultChecker.reset();
			return;
		}

		if (!profile.moveAble) {//判断是否能够进行移动
			_timeFaultChecker.reset();
			return;
		}

		Vector2 target;
		try {
			target = _route[_lastApproach + 1];
		} catch (ArgumentOutOfRangeException) {
			return;
		}
		
		// Debug.Log(_timeFaultChecker);
		float actualSpeed = profile.speed * _timeFaultChecker.getElapsedTime();
		_timeFaultChecker.reset();
		profile.position = Vector2.MoveTowards(profile.position, target, actualSpeed);

		_emitter.pos(profile.position);
		_emitter.emitEvent(actor, ActorType.NONE);

		if (profile.position == target){
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
