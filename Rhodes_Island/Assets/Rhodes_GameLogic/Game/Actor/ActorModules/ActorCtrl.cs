using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
此组件是用来提供操作单个Actor的方法
*/
public class ActorCtrl : MonoBehaviour {
	public Profile profile;
	public GameObject actor;

	void Start(){
		// actor.SetActive(false);
	}

	public void loadData(ActorData data){
		if (data == null) {
			throw new System.Exception("invalid actor data");
		}
		profile.actorType = KeyMapping.ActorTypeToEnum(data.type);//设定单位类型
		actor.GetComponent<ActorRoute>().setRoute(data.route);//设定距离
		profile.nodeMapper.shifts = data.atkShifts;//设定攻击范围
	}

	//将此actor移动至场地内
	//
	public void activate(){
		actor.SetActive(true);
	}

	public void terminate(){
		actor.SetActive(false);
	}

	public void toGrave(){
		
	}

	public void shout(){
		Debug.Log("well, fuck");
	}

	
}
