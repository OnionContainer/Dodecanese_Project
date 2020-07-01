using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
buff类用来实现角色的攻击力、防御力、攻击速度等参数的修改


*/

public abstract class Buff{

	protected GameObject _creator;
	protected GameObject _reciever;
	public List<BuffTag> tags;

	public static Buff GetBuff(string data, GameObject creator, GameObject reciever){
		return new DefaultBuff(creator, reciever);
	}

	public abstract void update();//更新
	public abstract void launch();//启动
	public abstract void terminate();//终止
}


class DefaultBuff:Buff{

	private DodTimer _timer = new DodTimer(15);

	public DefaultBuff(GameObject creator, GameObject reciever){
		_creator = creator;
		_reciever = reciever;
	}

	public override void update(){
		Debug.Log("Buff Update");
		if (_timer.isReady()) {
			this._reciever.GetComponent<ActorBuffMgr>().removeBuff(this);
		}
		Profile profile = _reciever.GetComponent<Profile>();
		profile.position += new Vector2(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f,0.1f));
		
	}
	
	public override void launch(){
		Debug.Log("Default Buff Launched");
		_timer.reset();
	}

	public override void terminate(){
		Debug.Log("Buff terminated");
	}
}
