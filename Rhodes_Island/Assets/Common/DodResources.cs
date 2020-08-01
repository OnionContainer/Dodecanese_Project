using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DodResources{

	public static ActorData GetActorData(string actorname){
		if (!File.Exists("Assets/Resources/ActorData/" + actorname + ".json")) {
			return null;
		}
		return JsonUtility.FromJson<ActorData>(
			new StreamReader("Assets/Resources/ActorData/" + actorname + ".json").ReadToEnd()
		);
	}

	public static GameLevelData GetLevelData(string levelname){
		if (!File.Exists("Assets/Resources/GameLevelData/" + levelname + ".json")) {
			return null;
		}
		return JsonUtility.FromJson<GameLevelData>(
			new StreamReader("Assets/Resources/GameLevelData/" + levelname + ".json").ReadToEnd()
		);
	}

}
