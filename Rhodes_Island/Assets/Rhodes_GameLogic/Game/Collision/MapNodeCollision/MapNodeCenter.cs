using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
存在于Battle中，用于监控所有Actor所在的地图节点的类
如果想要从某一个地图节点获取Actor，应访问此类

todo..此模块还未被测试过

优化方向：在Profile类中实现攻击优先级算法后，在每一地图单元中采用具有优先级排序的数据结构

*/
public class MapNodeCenter{

	private Dictionary<string, Dictionary<int, GameObject>> _actors;

	public DodReadOnlyDictionary<int, GameObject> this[int x, int y]{
		get{
			return new DodReadOnlyDictionary<int, GameObject>(getActorsFromPoint(new IntVec(x,y)));
		}
	}
	
	public DodReadOnlyDictionary<int, GameObject> this[IntVec point]{
		get{
			return new DodReadOnlyDictionary<int, GameObject>(getActorsFromPoint(point));
		}
	}
	
	public MapNodeCenter(){
		_actors = new Dictionary<string, Dictionary<int, GameObject>>();
		DodEventCentre.Instance.on(EType.ENTER_MAP_NODE, this.onEnter);
		DodEventCentre.Instance.on(EType.LEAVE_MAP_NODE, this.onLeave);
	}

	#region private tools
	/*获取某一点上的全部Actors*/
	private Dictionary<int, GameObject> getActorsFromPoint(IntVec point){
		string pointKey = point.toKey();
		if (!_actors.ContainsKey(pointKey)) {//如果此坐标尚未被记录过，则终止函数
			return null;
		}
		return _actors[pointKey];
	}

	private void onEnter(DodEvent e){
		DE_EnterMapNode actual = (DE_EnterMapNode)e;
		string pointKey = actual.point.toKey();//坐标键
		Profile profile = actual.publisher.GetComponent<Profile>();//获取Profile组件
		int symb = profile.getSymbol();//目标symbol
		
		if (!_actors.ContainsKey(pointKey)) {//若还未存有坐标键，则新增 坐标-Actor集合 的键值对
			_actors.Add(pointKey, new Dictionary<int, GameObject>());
		}

		if (!_actors[pointKey].ContainsKey(symb)){//若此Actor此前并未存在于此坐标，则将其加入此坐标
			_actors[pointKey].Add(symb, actual.publisher);
		} else {//若此Actor已经存在于此坐标，则报告重复进入错误
			Debug.LogWarning("Entering Map Node Twice");
		}
	}

	private void onLeave(DodEvent e){
		DE_EnterMapNode actual = (DE_EnterMapNode)e;
		string pointKey = actual.point.toKey();//坐标键
		Profile profile = actual.publisher.GetComponent<Profile>();//获取Profile组件
		int symb = profile.getSymbol();//目标symbol

		if (!_actors.ContainsKey(pointKey)){//若还未存有坐标键，则新增 坐标-Actor集合 的键值对
			_actors.Add(pointKey, new Dictionary<int, GameObject>());
		}

		if (_actors[pointKey].ContainsKey(symb)){//若此Actor已存在于此坐标，则将其移除
			_actors[pointKey].Remove(symb);
		} else {//若此Actor还未存在于此坐标，则报告无效离开错误
			Debug.LogWarning("Invalid Node Leaving");

		}
	}
	#endregion
}
