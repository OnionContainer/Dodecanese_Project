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

	private static GameObject _TestActors;
	public static GameObject TestActors{get{
		if (_TestActors == null) {
			_TestActors = GameObject.Find("TestActors");
		}
		return _TestActors;
	}}

	private static GameObject _Ground_Zero;
	public static GameObject Ground_Zero{get{
		if (_Ground_Zero == null) {
			_Ground_Zero = GameObject.Find("Ground_Zero");
		}
		return _Ground_Zero;
	}}

	private static GameObject _Canvas;
	public static GameObject Canvas{get{
		if(_Canvas == null){
			_Canvas = GameObject.Find("Canvas");
		}
		return _Canvas;
	}}
}

public class GlobalPrefab{

	private static GameObject _Actor;
	public static GameObject Actor{get{
		if (_Actor == null) {
			_Actor = Resources.Load<GameObject>("Actor");
		}
		return _Actor;
	}}
}