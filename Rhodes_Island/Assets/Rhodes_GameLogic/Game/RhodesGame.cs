using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhodesGame{

	public static void init(){
		_instance = new RhodesGame();
		_instance.stateMgr.init();
		// Debug.Log("RhodesGame: initialization complete");
	}


	private static RhodesGame _instance;
	public static RhodesGame Instance{get{
		return RhodesGame._instance;
	}}

	public GameStateMgr stateMgr;
	public GameBattle battle;
	public GameLobby lobby;

	private RhodesGame(){
		battle = new GameBattle();
		stateMgr = new GameStateMgr(battle);
	}

	public void update(){
		stateMgr.update();
		battle.level.update();
	}

}
