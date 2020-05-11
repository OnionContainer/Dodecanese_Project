using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameRunner : MonoBehaviour {

	public bool boot = true;
	public GameObject originPoint;

	// Use this for initialization
	void Start () {
		SimpRenderCenter.init();
		if (boot) {
			RhodesGame.Instance.init();
		}
	}
	
	// Update is called once per frame
	void FixedUpdate(){
		if (boot) {
			RhodesGame.Instance.update();
		}
		
	}
}



