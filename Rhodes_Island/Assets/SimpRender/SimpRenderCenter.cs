using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
/*
简易渲染模块


*/
public class SimpRenderCenter{

	private static SimpRenderCenter _instance;
	public static SimpRenderCenter Instance{get{return _instance;}}

	public static void init(){
		Debug.Log("Simp Render Initialized");
		_instance = new SimpRenderCenter();
		_test();
	}

	private static void _test(){
		var p = new Profile();
		_instance.createActor(p);
		_instance.moveActorTo(p, new Vector2(6,7.7f));
		
	}

	public GameObject originalPoint;
	public GameObject mapBlockPrefab;

	private MapBlock[,] _mapDic;
	private Dictionary<int, MapBlock> _actorDic;

	private SimpRenderCenter(){
		this.originalPoint = GameObject.Find("SimpRenderOriginal");
		this.mapBlockPrefab = Resources.Load<GameObject>("SimpRenderRes/MapBlock");
		_mapDic = new MapBlock[10,8];
		_actorDic = new Dictionary<int, MapBlock>();
	}

	public void createActor(Symbolized obj){
		var block = new MapBlock();
		_actorDic.Add(obj.getSymbol(), block);
		block.level = 2;
	}

	public void moveActorTo(Symbolized obj, Vector2 point){
		_actorDic[obj.getSymbol()].moveTo(point);
	}

	//显示战场
	public void showStage(int width, int height){
		_mapDic = new MapBlock[width,height];

		Material mat0 = Resources.Load<Material>("SimpRenderRes/MapBlockSkin");
		Material mat1 = Resources.Load<Material>("SimpRenderRes/MapBlockSkin1");

		for(int x = 0; x < width; x += 1) {
			for (int y = 0; y < height; y += 1) {
				_mapDic[x,y] = new MapBlock(new Vector2(x,y));
				bool xIsEven = x % 2 == 0;
				bool yIsEven = y % 2 == 0;
				
				//做个花纹
				if ((xIsEven && yIsEven) || (!xIsEven && !yIsEven)){
					_mapDic[x,y].obj.GetComponent<MeshRenderer>().material = mat1;
				} else {
					_mapDic[x,y].obj.GetComponent<MeshRenderer>().material = mat0;
				}

				_mapDic[x,y].level = 1;
				
			}
		}
	}
}





class MapBlock:Symbolized{

	private DodSymbol _symbol;

	private float _level = 0;
	public float level{get{
		return _level;
	}set{
		_level = value;
		var vec = obj.transform.localPosition;
		obj.transform.localPosition = new Vector3(vec.x, _level, vec.z);
	}}

	public int getSymbol(){
		return _symbol.data;
	}

	public GameObject obj;

	public MapBlock(){
		_symbol = new DodSymbol();

		obj = GameObject.Instantiate(SimpRenderCenter.Instance.mapBlockPrefab, Vector3.zero, Quaternion.identity);
		obj.transform.parent = SimpRenderCenter.Instance.originalPoint.transform;
		obj.transform.localPosition = Vector3.zero;
	}

	public MapBlock(Vector2 pos):this(){
		moveTo(pos);
	}

	public void moveTo(Vector2 place){
		obj.transform.localPosition = new Vector3(place.x, _level, place.y);
	}
}