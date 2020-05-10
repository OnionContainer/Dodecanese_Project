using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorBuffMgr : MonoBehaviour {

	public GameObject actor;

	private List<Buff> _buffList;

	public void init(){
		this._buffList = new List<Buff>(10);
	}

	public void createBuff(GameObject creator, GameObject receiver, string data){
		Buff buff = Buff.GetBuff(data);
		buff.creator = creator;
		buff.reciever = receiver;
		this._buffList.Add(buff);
	}

	public void removeBuff(Buff buff){
		if (_buffList.Contains(buff)) {
			buff.terminate();
			_buffList.Remove(buff);
		}
	}

	public void update(){
		foreach(Buff buff in _buffList) {
			buff.update();
		}	
	}
}
