using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SimpRenderCenter{

	private static SimpRenderCenter _instance;
	public static SimpRenderCenter Instance{get{return _instance;}}

	public static void init(){
		Debug.Log("Simp Render Initialized");
		_instance = new SimpRenderCenter();
		_test();
	}

	private static void _test(){
		Instance._mapDic.Add("ok", new MapBlock());
	}

	public GameObject originalPoint;
	public GameObject mapBlockPrefab;
	private Dictionary<string, MapBlock> _mapDic;

	private SimpRenderCenter(){
		this.originalPoint = GameObject.Find("GameOriginPoint");
		this.mapBlockPrefab = Resources.Load<GameObject>("SimpRenderRes/MapBlock");
		_mapDic = new Dictionary<string, MapBlock>();
	}
}





class MapBlock:Symbolized{

	

	private DodSymbol _symbol;

	public int getSymbol(){
		return _symbol.data;
	}

	private GameObject _obj;

	public MapBlock(){
		_symbol = new DodSymbol();

		_obj = GameObject.Instantiate(SimpRenderCenter.Instance.mapBlockPrefab, Vector3.zero, Quaternion.identity);
		_obj.transform.parent = SimpRenderCenter.Instance.originalPoint.transform;
		_obj.transform.localPosition = Vector3.zero;
	}
}