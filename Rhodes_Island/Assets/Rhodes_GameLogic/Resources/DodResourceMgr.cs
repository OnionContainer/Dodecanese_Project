using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodResourceMgr{
	private static DodResourceMgr _instance;
	public static DodResourceMgr Instance{get{
		if (null == _instance) {
			_instance = new DodResourceMgr();
		}
		return _instance;
	}}

	private int _levelID;
	private bool _inited;
	private bool _levelPrepared;

	#region setters getters
	public int LevelID{get{
		return _levelID;
	}
	set{
		_levelID = value;
		_levelPrepared = false;
	}}

	public bool Inited{get{return _inited;}}
	public bool LevelPrepared{get{return _levelPrepared;}}
	#endregion
	
	private DodResourceMgr(){
		_levelID = -1;
		_inited = false;
		_levelPrepared = false;
	}

	public void init(){
		//todo..读取特定json文档
		_inited = true;
	}

	public void update(){/*这个update是干啥的来着……*/}

	public string getCurrentLevelRes(){
		//todo..
		return "yes!";
	}

	public string getActorResByID(int id){
		//todo..
		return "yes!";
	}

}
