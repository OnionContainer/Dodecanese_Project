using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRunner : MonoBehaviour {

	// Use this for initialization
	void Start () {
		RhodesGame.Instance.init();
	}
	
	// Update is called once per frame
	void FixedUpdate(){

		RhodesGame.Instance.update();
	}
}
