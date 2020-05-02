using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateBattle : GameStateBase{

	public GameStateBattle(GameBattle battle):base(battle){
		this.battle = battle;
	}

	public override void enter(){

	}

	public override void leave(){

	}

	public override void update(){
		//等待修复
		// this.battle.collision.update();
		// this.battle.actorMgr.update();
		// this.battle.map.update();
	}

	public override void reset(){

	}

}
