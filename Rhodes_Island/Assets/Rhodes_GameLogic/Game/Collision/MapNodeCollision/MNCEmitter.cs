using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
Map Node Collision Emitter
地图节点碰撞消息生成器
此类是碰撞箱数据、碰撞事件生成逻辑的封装
要浏览或设置地图参数，请访问MapNodeParameter类
*/
public class MNCEmitter{

	private Rect _rect;//此实例所关注的碰撞箱
	private List<Vector2> _past;//此实例“上次”判定位置时所在的地图节点

	public MNCEmitter(){
		_past = new List<Vector2>();
	}
}

class MapNodeCollisionMath{
	
}
