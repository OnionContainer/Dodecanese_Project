using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/**
 * 模块说明: 游戏战斗地图模块  
 * 负责内容: 地图属性设置，全局buff管理  
 * 负责人: 银华  
 * 时间: 2020年3月3日12:45:41  
 */

//KR: 全局由关卡模块管理 @银华
//这里可以包含全局的调整值/生命值/涨费
//全游戏标准值使用常量定义在BattleConst类中 示例可以看下方
//另：私有成员命名请在前面加下划线 声明的成员请在构造函数中全部初始化一个值，防止undefi

public class GameLevel{
	private int _initialCost;
	private int _currentCost;
	private int _lifePoint;
	private Buff[] _globalBuffList;
	private LinkedList<LevelTimelineCommand> _timeline = new LinkedList<LevelTimelineCommand>();
	private DodTimer _timer = new DodTimer();

	public void init(string levelCode){
		this.reset();
		GameLevelData data = DodResources.GetLevelData(levelCode);
		//判空
		if (data == null) {
			throw new System.Exception("level not found");
		}


		

		//循环构筑timeline
		string[] spliter = new string[]{"__"};

		foreach(string code in data.commandSource) {
			_timeline.AddLast(new LevelTimelineCommand(
				code.Split(spliter, StringSplitOptions.None)
			));
		}

		foreach(LevelTimelineCommand line in _timeline) {
			line.print();
		}

		//todo：初始化关卡参数
	}

	public void update(){
		// while (_timeline.Count > 0 && _timer.getElapsedTime() > _timeline.First.Value.time) {
		// 	LevelTimelineCommand toExecute = _timeline.First.Value;
		// 	// if (toExecute.type.Equals("Enemy_Out")) {
		// 	// 	Debug.Log("Enemy_Out");
		// 	// }
			
		// }
		//todo
		//更新费用
		//更新全局buff
	}

	public void changeCost(){
		//todo..
	}

	private void _updateTime(){}
	private void _updateCost(){}

	public void reset(){
		_timer.reset();
		//todo..
	}

}



public class LevelTimelineCommand{
	public int time = 1000;
	public string type = "Enemy_Out";
	public string resource = "Neosb";
	public LevelTimelineCommand(){}
	public LevelTimelineCommand(int time, string type, string res){
		this.time = time;
		this.type = type;
		this.resource = res;
	}
	public LevelTimelineCommand(string[] codes) {
		this.time = Int16.Parse(codes[0]);
		this.type = codes[1];
		this.resource = codes[2];
	}
	public void print(){
		Debug.Log("LevelTimeLine:\nTime:" + this.time + 
			"\nType:" + this.type + 
			"\nResource:" + this.resource
		);

	}
}


