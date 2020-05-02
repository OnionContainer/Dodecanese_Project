using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameStateBase{
	protected GameBattle battle;
	public GameStateBase(GameBattle battle){

	}
	public abstract void enter();
	public abstract void update();
	public abstract void leave();
	public abstract void reset();
}
