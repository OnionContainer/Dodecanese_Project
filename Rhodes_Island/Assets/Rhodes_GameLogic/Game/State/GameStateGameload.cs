using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateGameload : GameStateBase {

	public GameStateGameload(GameBattle battle):base(battle){
		// Debug.Log("Game State: GameLoad");
	}

	public override void enter(){

	}

	public override void leave(){

	}

	public override void reset(){

	}

	public override void update(){
		// Debug.Log("wait for resource loading");
		if (true == DodResourceMgr.Instance.Inited || true){//暂时设置为恒为true
			//WE DO NOT HAVE LOBBY MODULE IN THIS VERSION
            //JUST SET LEVEL ID HERE
            //TO DEL
			DodResourceMgr.Instance.LevelID = 1;
			RhodesGame.Instance.stateMgr.runState(GameStateID.LEVELLOAD);
			// Debug.Log("GameStateGameload.update: Resources init complete, set level into 1.");
		}
	}



}
