using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActorData{
	public string[] initBuffs = new string[]{"default", "default"};
	public string type = "MONSTER";
	public Vector2[] route = new Vector2[]{new Vector2(2,2), new Vector2(10,5), new Vector2(0,0)};
	public IntVec[] atkShifts = new IntVec[]{new IntVec(0,0)};
}