using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker : MonoBehaviour {

	public Profile profile;

	void Awake(){

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		DodReadOnlyDictionary<int, GameObject> dic = RhodesGame.Instance.battle.mapNodeCenter[profile.nodePosition, ActorType.MONSTER];
		Debug.Log(profile.nodePosition.toKey());
		if (dic == null || dic.Count == 0) {
			return;
		}

		foreach(KeyValuePair<int, GameObject> pair in dic){
			GameObject target = pair.Value;
			Profile targetPro = target.GetComponent<Profile>();
			// Debug.Log("canblock:" + profile.canBlock);
			// Debug.Log("canblock:" + targetPro.isBlockable);
			if (profile.canBlock &&
				targetPro.isBlockable &&
				!profile.blocks.Contains(target) &&
				profile.blockAbility - targetPro.antiBlock >= 0) {

				Debug.Log("raise");

				//进行阻挡
				profile.blocks.Add(target);
				profile.blockAbility -= targetPro.antiBlock;
				targetPro.beBlockedBy = profile.actor;
				//todo..发送事件
				DodEventCentre.Instance.Invoke(new DE_Block(profile.actor, target));

			}
		}
	}
}
