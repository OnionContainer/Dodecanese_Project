using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	private int _timeLine;//这是啥？
	private Buff[] _globalBuffList;

	public GameLevel(){

	}

	public void init(Object res){
		this.reset();
		//todo：初始化关卡参数
	}

	public void update(){
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
		//todo..
	}

}
