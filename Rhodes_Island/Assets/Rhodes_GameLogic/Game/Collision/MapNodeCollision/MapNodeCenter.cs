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
	private static DodReadOnlyDictionary<int, GameObject> _empty = 
	new DodReadOnlyDictionary<int, GameObject>(new Dictionary<int, GameObject>());//固定的一个空列表

	private List<IntVec> _loadedNode;
	public IEnumerable<IntVec> LoadedNodes{get{
		return _loadedNode;
	}}

	private Dictionary<string, Dictionary<int, GameObject>> _operators;//储存干员
	private Dictionary<string, Dictionary<int, GameObject>> _enemies;//储存敌人
	private Dictionary<string, Dictionary<int, GameObject>> _actors;//储存所有actor

	private Dictionary<string, DodReadOnlyDictionary<int, GameObject>> _readonlyOperators;//储存干员只读节点
	private Dictionary<string, DodReadOnlyDictionary<int, GameObject>> _readonlyEnemies;//储存敌人只读节点
	private Dictionary<string, DodReadOnlyDictionary<int, GameObject>> _readonlyActors;//储存所有actor只读节点

	public DodReadOnlyDictionary<int, GameObject> this[int x, int y, ActorType identity]{
		get{
			return this[new IntVec(x,y), identity];
		}
	}
	
	public DodReadOnlyDictionary<int, GameObject> this[IntVec point, ActorType identity]{
		get{
			string pointKey = point.toKey();
			if (!_actors.ContainsKey(pointKey)) {
				return MapNodeCenter._empty;//返回一个固定的空列表避免判空操作
			}
			if (identity == ActorType.MONSTER) {
				return _readonlyEnemies[pointKey];
			} else if (identity == ActorType.OPERATOR) {
				return _readonlyOperators[pointKey];
			} else if (identity == ActorType.ANY) {
				return _readonlyActors[pointKey];
			} else {
				Debug.LogWarning("Invalid Actor Type Request");
				return null;
			}
		}
	}
	
	public MapNodeCenter(){
		_loadedNode = new List<IntVec>();
		_actors = new Dictionary<string, Dictionary<int, GameObject>>();
		_enemies = new Dictionary<string, Dictionary<int, GameObject>>();
		_operators = new Dictionary<string, Dictionary<int, GameObject>>();
		_readonlyActors = new Dictionary<string, DodReadOnlyDictionary<int, GameObject>>();
		_readonlyEnemies = new Dictionary<string, DodReadOnlyDictionary<int, GameObject>>();
		_readonlyOperators = new Dictionary<string, DodReadOnlyDictionary<int, GameObject>>();
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

	private void _initPoint(IntVec point) {

		_loadedNode.Add(point.clone());

		string pointKey = point.toKey();
		Dictionary<int, GameObject>[] dics = new Dictionary<int, GameObject>[]{
			new Dictionary<int, GameObject>(),
			new Dictionary<int, GameObject>(),
			new Dictionary<int, GameObject>()
		};

		_actors.Add(pointKey, dics[0]);
		_readonlyActors.Add(pointKey, new DodReadOnlyDictionary<int, GameObject>(dics[0]));

		_enemies.Add(pointKey, dics[1]);
		_readonlyEnemies.Add(pointKey, new DodReadOnlyDictionary<int, GameObject>(dics[1]));

		_operators.Add(pointKey, dics[2]);
		_readonlyOperators.Add(pointKey, new DodReadOnlyDictionary<int, GameObject>(dics[2]));
	}

	private void onEnter(DodEvent eSource){
		DE_EnterMapNode e = (DE_EnterMapNode)eSource;
		string pointKey = e.point.toKey();//坐标键
		Profile profile = e.publisher.GetComponent<Profile>();//获取Profile组件
		int symb = profile.getSymbol();//目标symbol
		ActorType actorType = profile.actorType;//目标类型
		
		if (!_actors.ContainsKey(pointKey)) {//若还未存有坐标键，则新增 坐标-Actor集合 的键值对
			_initPoint(e.point);
		}

		if (!_actors[pointKey].ContainsKey(symb)){//若此Actor此前并未存在于此坐标，则将其加入此坐标
			_actors[pointKey].Add(symb, e.publisher);
			if (actorType == ActorType.OPERATOR) {//将此Actor依照种类存入对应的表中
				_operators[pointKey].Add(symb, e.publisher);
			} else if (actorType == ActorType.MONSTER) {
				_enemies[pointKey].Add(symb, e.publisher);
			}
			
		} else {//若此Actor已经存在于此坐标，则报告重复进入错误
			Debug.LogWarning("Entering Map Node Twice");
		}
	}

	private void onLeave(DodEvent eSource){
		DE_LeaveMapNode e = (DE_LeaveMapNode)eSource;
		string pointKey = e.point.toKey();//坐标键
		Profile profile = e.publisher.GetComponent<Profile>();//获取Profile组件
		int symb = profile.getSymbol();//目标symbol
		ActorType actorType = profile.actorType;//目标类型

		if (!_actors.ContainsKey(pointKey)){//若还未存有坐标键，则新增 坐标-Actor集合 的键值对
			_initPoint(e.point);
		}

		if (_actors[pointKey].ContainsKey(symb)){//若此Actor已存在于此坐标，则将其移除
			_actors[pointKey].Remove(symb);
			if (actorType == ActorType.MONSTER) {//将此Actor依照种类从对应的表中移除
				_enemies[pointKey].Remove(symb);
				// Debug.Log("remove");
			} else if (actorType == ActorType.OPERATOR) {
				_operators[pointKey].Remove(symb);
			}
		} else {//若此Actor还未存在于此坐标，则报告无效离开错误
			Debug.Log(pointKey);
			Debug.LogWarning("Invalid Node Leaving");
		}
	}
	#endregion
}
