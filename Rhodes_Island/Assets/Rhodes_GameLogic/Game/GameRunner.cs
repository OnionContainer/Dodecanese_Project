using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;



public class GameRunner : MonoBehaviour {

	public static GameRunner Instance;

	public bool boot = true;
	public GameObject originPoint;

	// Use this for initialization
	void Start () {


		
		
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



