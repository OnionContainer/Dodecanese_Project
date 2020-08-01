using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using UnityEngine.Events;
using System.IO;



public class GameRunner : MonoBehaviour {

	public static GameRunner Instance;


	// Use this for initialization
	void Start () {

		//split test



		//end

		
		// string defaultCode = JsonUtility.ToJson(new GameLevelData());
		// StreamWriter writer = new StreamWriter("Assets/Resources/GameLevelData/default.json");
		// writer.WriteLine(defaultCode);
		// writer.Close();

		Performance_Center.init(10,5);
		DodEventCentre.Instance.Invoke(new RM_AddOperatorToMainUI("002_amiya"));
		if (GameRunner.Instance != null){
			throw new Exception("The Phaaaaaaaaaaaaaaantom of the doublesingleton is here, inside my code~~~");
		}

		GameRunner.Instance = this;
		RhodesGame.init();

		// RhodesGame.Instance.battle.actorMgr.createOprt("fuck");
		// print(JsonUtility.ToJson(new ActorData()));
		RhodesGame.Instance.battle.actorMgr.createEnemy("Neosb");
		RhodesGame.Instance.battle.actorMgr.createEnemy("sb");
		RhodesGame.Instance.battle.level.init("default");
		
	}
	
	
	private DodTimer timer;


	void FixedUpdate(){
		
		RhodesGame.Instance.update();
	}
}



