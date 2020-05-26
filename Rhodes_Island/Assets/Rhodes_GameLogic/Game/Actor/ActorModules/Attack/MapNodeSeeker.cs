using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//此类仅用于更新Profile.nodeCapture内的数据
public class MapNodeSeeker : MonoBehaviour {

	public GameObject actor;
	public Profile profile;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		NodeMapper mapper = profile.nodeMapper;//攻击范围
		List<GameObject> list = profile.nodeCapture;//目标表
		list.Clear();

		foreach(IntVec point in mapper.finalPoints) {
			foreach(KeyValuePair<int, GameObject> pair in RhodesGame.Instance.battle.mapNodeCenter[point, ActorType.MONSTER]){
				GameObject enemy = pair.Value;
				if (!list.Contains(enemy)) {//去重
					//todo..查看是否能够加入到列表中（隐身）
					list.Add(enemy);
					//todo..排序
				}
			}
		}
	}
}