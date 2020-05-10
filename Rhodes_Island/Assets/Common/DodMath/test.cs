using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	public float drawsPerUp = 0;
	public int totalDraw = 0;
	public int totalUp = 0;
	public Random random = new Random();

	public DodTimer timer;
	// Use this for initialization
	void Start () {
		timer = new DodTimer(3);
	}
	
	// Update is called once per frame
	void Update () {

		for(int i = 0; i < 10; i += 1) {
			if (Random.Range(0,1) < 0.0035) {
				totalUp += 1;
			}
		}

		totalDraw += 1;

		if (timer.isReady()){
			timer.reset();
			drawsPerUp = totalDraw/totalUp;
			Debug.Log(drawsPerUp);
		}
		
	}
}
