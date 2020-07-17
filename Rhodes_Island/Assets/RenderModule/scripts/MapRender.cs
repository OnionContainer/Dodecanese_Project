using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRender {

	private GameObject parent;
	private int height;
	private int length;
	private bool hide;
	private GameObject[,] mapBlocks;
	private bool[,] mapPath;
	private Material blue,red,yellow;


	public Vector2 mapSize(){
		return new Vector2(this.length,this.height);
	}



	public MapRender(int length, int height, bool hideOrigin = true){
		this.length = length;
		this.height = height;
		this.hide = hideOrigin;
		this.mapBlocks = new GameObject[length,height];
		this.blue = Resources.Load<Material>("RenderRes/Materials/Blue");
		this.yellow = Resources.Load<Material>("RenderRes/Materials/Yellow");
		this.red = Resources.Load<Material>("RenderRes/Materials/Red");
		this.mapPath = new bool[length,height];

		this.parent = GlobalGameObject.Ground_Zero;
		this.creatMap(this.length,this.height);
		DodEventCentre.Instance.on(EType.ACTOR_LOCATION,this.pathListener);

	}

	private void creatMap(int length, int height){
		for(int i = 0; i < length; i++){
			for(int j = 0; j < height; j ++){
				GameObject tmp = GameObject.CreatePrimitive(PrimitiveType.Cube);
				mapBlocks[i,j] = tmp;
				tmp.transform.parent = parent.transform;
				tmp.transform.localPosition = new Vector3(i,1,j);
				mapPath[i,j] = true;
				if((i+j)%2 == 0){
					tmp.GetComponent<MeshRenderer>().material = this.yellow;
				}else{
					tmp.GetComponent<MeshRenderer>().material = this.blue;
				}
			}
		}
		this.hideParent();
	}


	private void hideParent(){
		parent.GetComponent<MeshRenderer>().enabled = !hide;
	}


	private void pathListener(DodEvent source){
		RM_ActorLocation e = (RM_ActorLocation)source;
		Vector2 tmpvec = e.location;
		float x = tmpvec.x;
		float y = tmpvec.y;


	    float xDown = Mathf.Floor(x);
		float xUp = Mathf.Ceil(x);
		float yDown = Mathf.Floor(y);
		float yUp = Mathf.Ceil(y);

		if(xUp > length -1 || yUp > height -1 ||xDown < 0 || yDown < 0){
			return;
		}
		Vector2 location1 = new Vector2(xDown,yDown);
		Vector2 location2 = new Vector2(xDown,yUp);
		Vector2 location3 = new Vector2(xUp,yDown);
		Vector2 location4 = new Vector2(xUp,yUp);
		bool sample1 = mapPath[(int)location1.x,(int)location1.y];
		bool sample2 = mapPath[(int)location2.x,(int)location2.y];
		bool sample3 = mapPath[(int)location3.x,(int)location3.y];
		bool sample4 = mapPath[(int)location4.x,(int)location4.y];

		if(sample1 == true){
			sample1 = false;
			mapBlocks[(int)location1.x,(int)location1.y].GetComponent<MeshRenderer>().material = this.red;
		}
		if(sample2 == true){
			sample2 = false;
			mapBlocks[(int)location2.x,(int)location2.y].GetComponent<MeshRenderer>().material = this.red;
		}
		if(sample3 == true){
			sample1 = false;
			mapBlocks[(int)location3.x,(int)location3.y].GetComponent<MeshRenderer>().material = this.red;
		}
		if(sample4 == true){
			sample1 = false;
			mapBlocks[(int)location4.x,(int)location4.y].GetComponent<MeshRenderer>().material = this.red;
		}

	}
}


public class Performance_Center {

	public static Performance_Center Instance;
	public GameObject origin;
	private MapRender map;
	public int actorNum = 10;
	public MainUI ui;
	public bool test = false;

	

	public static void init(int width, int height ,bool hideOrigin = true){
		Performance_Center.Instance = new Performance_Center();
		Performance_Center.Instance.origin = GlobalGameObject.Ground_Zero;
		Performance_Center.Instance.ui = new MainUI(10);
		Performance_Center.Instance.ui.init();
		//*****************************//
		Performance_Center.Instance.deployMap(height,width,hideOrigin);
		//*****************************//
		_test();
		Debug.Log("Performance_Center initialization complete!!");
	}



	private static void _test(){
		//anything you want to do 
	}



	public void deployMap(int height, int length, bool hideOrigin = true){
		Performance_Center.Instance.map = new MapRender(length,height, hideOrigin);
	}

	public Vector2 mapSize(){
		return map.mapSize();
	}



}

public class MainUI{

	private int actorNum;
	private GameObject uiPanel;
	private GameObject[] images;
	public mainUIMouseData data;

	public MainUI(int num){
		this.actorNum = num;
		images = new GameObject[this.actorNum];
		data = new mainUIMouseData();
	}

	public void init(){
		GameObject tmpUI = Resources.Load<GameObject>("RenderRes/UIPanel");
		GameObject UI = GameObject.Instantiate(tmpUI);
		UI.transform.SetParent(GlobalGameObject.Canvas.transform,false);
		uiPanel = UI;
		for(int i = 0; i < actorNum; i ++){
			images[i] = GameObject.Instantiate(Resources.Load<GameObject>("RenderRes/Image"));
			images[i].transform.SetParent(this.uiPanel.transform,false);
			images[i].transform.localPosition = new Vector2(50+ i*110,50);
			// images[i].GetComponent<UIImage>().burnNum(i);
		}
	}

	public GameObject getImage(int num){
		return this.images[num];
	}


}


//主UI相关数据包括鼠标所处状态
public class mainUIMouseData{

	private bool imageMouseDown;
	private bool cubeCreated;
	private GameObject tmpCube;
	private string operatorName;

	public mainUIMouseData(){

	}

	public string getOpName(){
		return operatorName;
	}

	public bool getmouseDown(){
		return imageMouseDown;
	}


	public GameObject getCube(){
		return tmpCube;
	}

	public bool getCubeCreated(){
		return cubeCreated;
	}

	public void setMouseDown(bool something){
		imageMouseDown = something;
	}



	public void setCubeCreated(bool something){
		cubeCreated = something;
	}

	public void creatCube(){
		tmpCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		tmpCube.transform.parent = GlobalGameObject.Ground_Zero.transform;
	}

	public void moveCube(Vector2 target){
		tmpCube.transform.localPosition = new Vector3(target.x,2,target.y);
	}

	public void destoryCube(){
		GameObject.Destroy(tmpCube);
	}

	public void setOpName(string something){
		operatorName = something;
	}
}