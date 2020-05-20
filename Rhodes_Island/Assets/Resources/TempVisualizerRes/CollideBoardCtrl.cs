using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideBoardCtrl : MonoBehaviour {

	public GameObject enemy;
	public GameObject oparator;

	public void enemyOn(bool b){
		enemy.GetComponent<Renderer>().enabled = b;
	}

	public void operatorOn(bool b){
		oparator.GetComponent<Renderer>().enabled = b;
	}
}
