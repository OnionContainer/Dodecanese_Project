using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateBattle : GameStateBase{

	public GameStateBattle(GameBattle battle):base(battle){
		this._battle = battle;
	}

	public override void enter(){

	}

	public override void leave(){

	}

	public override void update(){
		//等待修复
		// _battle.collision.update();
		// Debug.Log("Battle Running");
		_battle.actorMgr.update();
		_battle.map.update();
	}

	public override void reset(){

	}

}
