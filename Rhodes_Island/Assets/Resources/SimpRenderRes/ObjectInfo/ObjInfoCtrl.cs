using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;

public class ObjInfoCtrl : MonoBehaviour {

	private static GameObject _AtkRangeBox;
	private static GameObject AtkRangeBox{get{
		if (_AtkRangeBox == null) {
			_AtkRangeBox = Resources.Load<GameObject>("SimpRenderRes/ObjectInfo/AtkRangeBox");
		}
		return _AtkRangeBox;
	}}

	private UnityAction _resetAction = new UnityAction(()=>{Debug.Log("Reset Executed");});//复位函数

	// Use this for initialization
	void Start () {
		
	}
	
	public void showInfo(Profile profile){
		_resetAction();
		_resetAction -= _resetAction;
		_resetAction += ()=>{Debug.Log("Reset Executed");};//执行并清空复位函数

		GameObject centre = GlobalGameObject.ObjInfoOriginal;
		GameObject infoBoard = GlobalGameObject.InfoBoard;
		// centre.transform.SetParent(GlobalGameObject.ObjInfoOriginal.transform);//重设父节点

		Debug.Log(profile.nodeMapper.stringify());

		foreach(IntVec point in profile.nodeMapper.finalPoints) {
			GameObject box = Instantiate(AtkRangeBox, centre.transform);
			box.transform.localPosition = new Vector3(point.x, 1, point.y);
			_resetAction += ()=>{Destroy(box);};
		}

	}

	void FixedUpdate(){//实时更新的数据

	}
}
