using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBattle{

	public GameLevel level;
	public GameMap map;
	public ActorMgr actorMgr;

	public ActorCollisionPrecessor collision;
	public ColiReporter mapNodeCPU;

	public GameUIEvent gameUIEvent;

	private bool _levelPrepared;
	public bool isLevelPrepared{get{return this._levelPrepared;}}

	public GameBattle(){
		this.level = new GameLevel();
		this.map = new GameMap();
		this.actorMgr = new ActorMgr();
		this.collision = new ActorCollisionPrecessor();
		this.gameUIEvent = new GameUIEvent();
	}

	public void prepareLevel(){
		//初始化关卡信息
		// var res = DodResourceMgr.Instance.getCurrentLevelRes();

		//初始化可视化模块
		// PerformanceCentre.俺も頑張らないと();

		//清空上次战斗产生的残余信息
		// this.車の用意できました();

		//准备完成
		this._levelPrepared = true;
	}

}
