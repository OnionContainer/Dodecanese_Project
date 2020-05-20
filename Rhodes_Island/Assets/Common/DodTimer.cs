using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
计时器类
*/

public class DodTimer{

	

	public float interval;//单位：秒

	private float _lastAct = 0;

	public DodTimer(float interval = 3){
		this.interval = interval;
		this._lastAct = Time.fixedTime;
	}

	public bool isReady(){
		return Time.fixedTime - this._lastAct >= this.interval;
	}

	public void reset(){
		this._lastAct = Time.fixedTime;
	}

	public float getLastAct(){
		return this._lastAct;
	}

	public float getElapsedTime(){
		return Time.fixedTime - this._lastAct;
	}

}
