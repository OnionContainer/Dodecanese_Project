using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using UnityEngine.Events;



public class GameRunner : MonoBehaviour {

	public static GameRunner Instance;


	// Use this for initialization
	void Start () {
		
		Performance_Center.init(10,5);
		
		if (GameRunner.Instance != null){
			throw new Exception("The Phaaaaaaaaaaaaaaantom of the doublesingleton is here, inside my code~~~");
		}

		GameRunner.Instance = this;
		SimpRenderCenter.init();
		SimpRenderCenter.Instance.showStage(10,5);
		RhodesGame.init();

		
	}
	
	
	private DodTimer timer;
	void FixedUpdate(){
		
		RhodesGame.Instance.update();
	}
}



