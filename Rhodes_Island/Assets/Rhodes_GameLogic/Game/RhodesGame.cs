using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhodesGame{

	private static RhodesGame _instance;
	public static RhodesGame Instance{get{
		if (RhodesGame._instance == null) {
			RhodesGame._instance = new RhodesGame();
		}
		return RhodesGame._instance;
	}}

	public GameStateMgr stateMgr;
	public GameBattle battle;
	public GameLobby lobby;

	private RhodesGame(){
		battle = new GameBattle();
		stateMgr = new GameStateMgr(battle);
	}

	public void init(){
		stateMgr.init();
		Debug.Log("RhodesGame: initialization complete");
	}

	public void update(){
		
		stateMgr.update();
	}

}
