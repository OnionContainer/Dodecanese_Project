using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum DodEventType{
	None,
	All
}

public class DodEventCentre : MonoBehaviour {

	private static DodEventCentre instance;
	public static DodEventCentre getInstance(){
		if (DodEventCentre.instance == null) {
			DodEventCentre.instance = new DodEventCentre();
		}
		return DodEventCentre.instance;
	}
	
	private Dictionary<DodEventType, Action> dic = new Dictionary<DodEventType, Action>();

	public void on(DodEventType type, Action action){
		if (this.dic[type] == null) {
			this.dic.Add(type, new Action(action));
		}
	}

	public void off(){

	}

	public void invoke(){

	}

	// Use this for initialization
	void Start () {
		
	}

}
