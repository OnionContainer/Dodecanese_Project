using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 大状态机 管理游戏所处阶段
 * @TODO GAMELOAD LOBBY LEVELLOAD BATTLE
 */

public enum GameStateID{
	NONE,
	GAMELOAD,
	LOBBY,
	LEVELLOAD,
	BATTLE,
	COUNT
}

public class GameStateMgr{

	private GameStateBase[] _states;
	private GameStateBase _currentState;


	public GameStateMgr(GameBattle battle){
		
	}

	public void init(){

	}

	public void dodUpdatee(){

	}
}
