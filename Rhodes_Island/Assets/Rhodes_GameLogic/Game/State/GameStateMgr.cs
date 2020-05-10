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

	private Dictionary<GameStateID, GameStateBase> _states;
	private GameStateBase _currentState;


	public GameStateMgr(GameBattle battle){
		_currentState = null;
		_states = new Dictionary<GameStateID, GameStateBase>();

		_states.Add(GameStateID.GAMELOAD, new GameStateGameload(battle));
		_states.Add(GameStateID.LOBBY, new GameStateLobby(battle));
		_states.Add(GameStateID.LEVELLOAD, new GameStateLevelload(battle));
		_states.Add(GameStateID.BATTLE, new GameStateBattle(battle));
		
	}

	public void init(){
		runState(GameStateID.GAMELOAD);
	}

	public void runState(GameStateID stateID){
		if (null != _currentState){
			_currentState.leave();
		}
		_currentState = _states[stateID];
		_currentState.enter();
	}

	public void update(){
		_currentState.update();
	}
}
