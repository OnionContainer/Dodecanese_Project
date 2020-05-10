using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
buff类用来实现角色的攻击力、防御力、攻击速度等参数的修改


*/

public abstract class Buff{

	public GameObject creator;
	public GameObject reciever;
	public List<BuffTag> tags;

	public static Buff GetBuff(string data){
		return null;
	}

	public virtual void update(){}//更新
	public abstract void launch();//启动
	public abstract void terminate();//终止

	

}
