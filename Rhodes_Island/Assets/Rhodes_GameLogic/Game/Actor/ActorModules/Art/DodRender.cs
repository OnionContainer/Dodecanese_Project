using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodRender : MonoBehaviour {

	private static GameObject _origin;
	public static GameObject Origin{get{
		if (_origin == null) {
			_origin = GameObject.Find("SimpRenderOriginal");
		}
		return _origin;
	}}

	public Profile profile;
	private GameObject _renderCube;

	void Awake() {
		_renderCube = Instantiate(Resources.Load<GameObject>("Block"));
		
	}

	// Use this for initialization
	void Start () {
		_renderCube.transform.parent = GameObject.Find("SimpRenderOriginal").transform;
	}
	
	// Update is called once per frame
	void Update () {
		_renderCube.transform.localPosition = new Vector3(profile.position.x, 2, profile.position.y);
	}
}
