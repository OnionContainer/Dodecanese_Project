using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorBuffMgr : MonoBehaviour {

	public GameObject actor;

	[SerializeField]
	private List<Buff> _buffList = new List<Buff>();
	private LinkedList<Buff> _toRemove = new LinkedList<Buff>();
	public void init(){
		this._buffList = new List<Buff>(10);
	}

	public void removeBuff(Buff buff){
		if (!_buffList.Contains(buff)) {
			Debug.LogWarning("Removing none existing buff");
			return;
		}
		buff.terminate();
		_toRemove.AddLast(buff);
	}

	public void addBuff(Buff buff){
		if (_buffList.Contains(buff)) {
			Debug.LogWarning("Buff adding deuplicated");
			return;
		}
		_buffList.Add(buff);
		buff.launch();
	}

	void FixedUpdate(){
		int length = _toRemove.Count;
		for (int i = 0; i < length; i += 1) {//清空每个存在于移除表的buff
			Buff buff = _toRemove.First.Value;
			_toRemove.RemoveFirst();
			_buffList.Remove(buff);
		}

		foreach(Buff buff in _buffList) {
			buff.update();
		}	
	}
}
