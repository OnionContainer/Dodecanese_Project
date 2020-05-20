using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapNodeParameter{

	public static float UNIT_SIZE = 1f;//地图节点尺寸
	public static float UNIT_SUBSIZE = 0.9f;//碰撞箱尺寸

	public static float UNIT_CENTERLIZE_SHIFT = 5f;//碰撞箱需向右/下移动的距离
	//这个值是（节点尺寸/碰撞箱尺寸）/2这么算的，没有做成表达式因为感觉没必要……写死还少次运算呢

	private MapNodeParameter(){}

}
