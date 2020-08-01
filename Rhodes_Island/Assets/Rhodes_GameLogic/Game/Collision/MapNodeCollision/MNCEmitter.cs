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
	private List<IntVec> _past;//此实例“上次”判定位置时所在的地图节点

	public MNCEmitter(){
		_past = new List<IntVec>();
		_rect = new Rect(0,0,MapNodeParameter.UNIT_SUBSIZE, MapNodeParameter.UNIT_SUBSIZE);
	}

	private List<IntVec> _findIntersects(){
		


		int left = (int)(_rect.x/MapNodeParameter.UNIT_SIZE);
		int top = (int)(_rect.y/MapNodeParameter.UNIT_SIZE);
		int right = (int)(_rect.xMax/MapNodeParameter.UNIT_SIZE);
		int bottom = (int)(_rect.yMax/MapNodeParameter.UNIT_SIZE);

		// Debug.Log("left" + left + "|top"+top+"|right"+right+"|bottom"+bottom);
		List<IntVec> result = new List<IntVec>();

		for (int x = left; x <= right; x += 1){
			for (int y = top; y <= bottom; y += 1) {
				result.Add(new IntVec(x,y));
			}
		}

		return result;
	}

	public void pos(float x, float y){
		_rect.position = new Vector2(x,y);
	}

	public void pos(Vector2 point){
		_rect.position = point + Vector2.zero;
	}

	public void emitEvent(GameObject publisher, ActorType identity = ActorType.NONE){
		//todo.. test algorithm
		List<IntVec> current = this._findIntersects();

		//处于过去集合，但不处于当前集合
		List<IntVec> leave = DodMath.findComplement(_past, current);

		//处于当前集合，但不处于过去集合
		List<IntVec> enter = DodMath.findComplement(current, _past);

		foreach(IntVec point in leave) {//发布离开事件
			DodEventCentre.Instance.Invoke(new DE_LeaveMapNode(point, publisher));
		}

		foreach(IntVec point in enter) {//发布进入事件
			DodEventCentre.Instance.Invoke(new DE_EnterMapNode(point, publisher));
		}

		this._past = current;//更新点集
	}

	public void leaveAll(GameObject publisher){
		foreach(IntVec point in _past) {
			DodEventCentre.Instance.Invoke(new DE_LeaveMapNode(point, publisher));
		}
		this._past.Clear();
	}




}

