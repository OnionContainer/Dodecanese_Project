using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockClick : MonoBehaviour {



	public GameObject boundActor;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// if (Input.GetMouseButtonDown(0) && profile != null) {
		// 	Debug.Log(profile.actor);
		// }
	}

	void OnMouseDown(){

		if (boundActor == null) {
			Debug.LogWarning("Actor Not Bound");
		}

		DodEventCentre.Instance.Invoke(new DE_ActorClicked(boundActor));
		
	}
}
