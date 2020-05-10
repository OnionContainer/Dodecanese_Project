using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dictionaryTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Dictionary<int, int> dic = new Dictionary<int, int>();
		dic.Add(1,2);
		Debug.Log(dic[1]);
		dic.Remove(1);
		// Debug.Log(dic[1]);
		dic.Add(1,3);
		// dic.Add(1,null);
		Debug.Log(dic[1]);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
