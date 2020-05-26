using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjInfoCtrl : MonoBehaviour {

	private static GameObject _AtkRangeBox;
	private static GameObject AtkRangeBox{get{
		if (_AtkRangeBox == null) {
			_AtkRangeBox = Resources.Load<GameObject>("SimpRenderRes/ObjectInfo/AtkRangeBox");
		}
		return _AtkRangeBox;
	}}

	// Use this for initialization
	void Start () {
		
	}
	
	public void showInfo(Profile profile){
		GameObject centre = GlobalGameObject.ObjInfoOriginal;
		foreach(IntVec point in profile.nodeMapper.finalPoints) {
			GameObject box = Instantiate(AtkRangeBox, centre.transform);
			box.transform.localPosition = new Vector3(point.x, 1, point.y);
		}
	}

	void FixedUpdate(){//实时更新的数据

	}
}
