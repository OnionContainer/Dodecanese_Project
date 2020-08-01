using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateLevelload: GameStateBase {

	public GameStateLevelload(GameBattle battle):base(battle){
		
	}

	public override void enter(){
		_battle.prepareLevel();
	}

	public override void leave(){

	}

	public override void reset(){

	}

	public override void update(){
		if (true == DodResourceMgr.Instance.LevelPrepared || true) {//暂时设为恒为true
            if (true == _battle.isLevelPrepared || true) {//暂时设为恒为true
                RhodesGame.Instance.stateMgr.runState(GameStateID.BATTLE);
                // Debug.Log("GameStateLevelload.update: level " + DodResourceMgr.Instance.LevelID + " is prepared.");
            }
        }
	}



}