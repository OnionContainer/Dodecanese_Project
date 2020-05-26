using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using UnityEngine.Events;


class Stupid{
	public List<int> a = new List<int>(new int[]{1,2,3,4,5});
	public List<IntVec> b = new List<IntVec>(new IntVec[]{
		new IntVec(1,1),
		new IntVec(500,1)
	});
}

public class GameRunner : MonoBehaviour {

	public static GameRunner Instance;

	public bool boot = true;
	public GameObject originPoint;

	// Use this for initialization
	void Start () {
		
		Stupid stupid = new Stupid();
		Debug.Log(JsonUtility.ToJson(stupid));

		if (GameRunner.Instance != null){
			throw new Exception("The Phaaaaaaaaaaaaaaantom of the doublesingleton is here, inside my code~~~");
		}

		GameRunner.Instance = this;
		SimpRenderCenter.init();
		SimpRenderCenter.Instance.showStage(10,5);
		RhodesGame.init();
	}
	
	// Update is called once per frame
	void FixedUpdate(){
		if (boot) {
			RhodesGame.Instance.update();
		}
	}
}



