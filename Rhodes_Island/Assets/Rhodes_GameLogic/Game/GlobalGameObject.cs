using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
此类用于调用全局唯一的游戏对象
*/
public class GlobalGameObject{

	private static GameObject _infoBoard;
	public static GameObject InfoBoard{get{
		if (_infoBoard == null) {
			_infoBoard = GameObject.Find("ObjectInfo");
		}
		return _infoBoard;
	}}

	private static GameObject _ObjInfoOriginal;
	public static GameObject ObjInfoOriginal{get{
		if (_ObjInfoOriginal == null) {
			_ObjInfoOriginal = GameObject.Find("ObjInfoOriginal");
		}
		return _ObjInfoOriginal;
	}}

	private static GameObject _BattleFieldOriginal;
	public static GameObject BattleFieldOriginal{get{
		if (_BattleFieldOriginal == null) {
			_BattleFieldOriginal = GameObject.Find("BattleFieldOriginal");
		}
		return _BattleFieldOriginal;
	}}
	
}
