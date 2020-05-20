using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//高层2
//底层1


//可视化地图节点事件，以便进行debug
public class MapNodeVisualizer : MonoBehaviour {

	private GameObject prefab;
	private Dictionary<string, GameObject> _dic;
	private GameObject origin;

	void Start () {

		prefab = Resources.Load<GameObject>("TempVisualizerRes/CollideBoard");
		_dic = new Dictionary<string, GameObject>();
		origin = GameObject.Find("SimpRenderOriginal");

		//ok
		
		// DodEventCentre.Instance.on(EType.ENTER_MAP_NODE, (DodEvent eSrouce)=>{
		// 	DE_EnterMapNode e = (DE_EnterMapNode)eSrouce;
		// 	_map.Add(e.point);
		// });

		// DodEventCentre.Instance.on(EType.LEAVE_MAP_NODE, (DodEvent eSource)=>{
		// 	DE_LeaveMapNode e = (DE_LeaveMapNode)eSource;
		// 	for (int i = 0; i < _map.Count; i += 1) {
		// 		if (_map[i].Equals(e.point)) {
		// 			_map.RemoveAt(i);
		// 			break;
		// 		}
		// 	}
		// });
	}

	void FixedUpdate () {

		foreach(KeyValuePair<string, GameObject> pair in _dic){
			Transform t = pair.Value.transform;
			GameObject obj = pair.Value;
			if (t.localPosition.y > 1) {
				t.localPosition = new Vector3(t.localPosition.x, 1, t.localPosition.z);
				CollideBoardCtrl ctrl = obj.GetComponent<CollideBoardCtrl>();
				ctrl.enemyOn(false);
				ctrl.operatorOn(false);
			}
		}

		MapNodeCenter center = RhodesGame.Instance.battle.mapNodeCenter;
		foreach(IntVec point in center.LoadedNodes){
			string key = point.toKey();

			if (center[point, ActorType.ANY].Count > 0) {
				if (!_dic.ContainsKey(key)) {
					GameObject obj = Instantiate(prefab, origin.transform);	
					obj.transform.localPosition = new Vector3(point.x, 1, point.y);
					_dic.Add(key, obj);
				}
				Transform t = _dic[key].transform;
				t.localPosition = new Vector3(t.localPosition.x, 2, t.localPosition.z);
			}

			if (center[point, ActorType.OPERATOR].Count > 0) {
				_dic[key].GetComponent<CollideBoardCtrl>().operatorOn(true);
			}

			if (center[point, ActorType.MONSTER].Count > 0) {
				_dic[key].GetComponent<CollideBoardCtrl>().enemyOn(true);
			}
			
		}

		// foreach(IntVec vec in _map){
		// 	string key = vec.toKey();
		// 	if (!_dic.ContainsKey(key)) {
		// 		GameObject obj = Instantiate(prefab, origin.transform);	
		// 		obj.transform.localPosition = new Vector3(vec.x, 1, vec.y);
		// 		_dic.Add(key, obj);
		// 	}
		// 	Transform t = _dic[key].transform;
		// 	t.localPosition = new Vector3(t.localPosition.x, 2, t.localPosition.z);

		// }

	}

}
