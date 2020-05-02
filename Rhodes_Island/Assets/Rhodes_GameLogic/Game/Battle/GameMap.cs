using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 模块说明: 游戏战斗地图模块  
 * 负责内容: 地图属性设置，全局buff管理  
 * 负责人: 银华  
 * 时间: 2020年3月3日12:45:41  
 */

//KR: 尽量做到职责单一 map类用于维护整个地图的拓扑结构

public class GameMap{

	private int _mapSize;//葱：这里不应该是长宽两个数吗
	private MapNode[,] _mapNodeList;

	public GameMap(){
		this._mapSize = 0;
		// this._mapNodeList = new Object();
	}

	public void init(Object res){
		this._setMapData(res);
	}

	private void _setMapData(Object res){
		//todo 
		//解析数据并生成地图
	}

	public MapNode getNodeByIndex(int index){
		//todo 以及提供各类接口
		return null;
	}

}

public enum NodeType{
	EMPTY,			//场景区域
	BLUEPOINT,		//我方基地
	REDPOINT,		//敌方出兵点
	GRAND,			//地面
	HIGHLAND		//高台
}

public class MapNode{
	
	private int _index;
	public int index{get{return this._index;}}

	private NodeType _type;
	public NodeType type{get{return this._type;}set{this._type=value;}}

	private bool _isEmpty;
	public bool isEmpty{get{return this._isEmpty;}set{this._isEmpty=value;}}

	public MapNode(int index, NodeType type){
		this._index = index;
		this._type = type;
		this._isEmpty = true;
	}

}