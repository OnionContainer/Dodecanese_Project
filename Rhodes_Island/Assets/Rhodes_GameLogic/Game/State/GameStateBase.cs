using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameStateBase{
	protected GameBattle _battle;
	public GameStateBase(GameBattle battle){
		_battle = battle;
	}
	public abstract void enter();
	public abstract void update();
	public abstract void leave();
	public abstract void reset();
}
