using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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
		Performance_Center.Instance.ui = new MainUI();
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

	// private int actorNum;
	private GameObject uiPanel;
	// private GameObject[] images;
	private LinkedList<GameObject> imagesReady;
	private LinkedList<GameObject> imagesWaiting;
	public mainUIMouseData data;
	public actroSubUIData subUIData;

	public MainUI(){
		data = new mainUIMouseData();
		subUIData = new actroSubUIData();
	}

	public void init(){
		GameObject tmpUI = Resources.Load<GameObject>("RenderRes/UIPanel");
		GameObject UI = GameObject.Instantiate(tmpUI);
		UI.transform.SetParent(GlobalGameObject.Canvas.transform,false);
		uiPanel = UI;
		imagesReady = new LinkedList<GameObject>();
		imagesWaiting = new LinkedList<GameObject>();
		DodEventCentre.Instance.on(EType.ADD_OPERATOR_TO_MAINUI,addOperatorToMainUI);
	}
	

	private void addOperatorToMainUI(DodEvent eSource){
		RM_AddOperatorToMainUI e = (RM_AddOperatorToMainUI) eSource;
		GameObject tmp = GameObject.Instantiate(Resources.Load<GameObject>("RenderRes/Image"));
		imagesReady.AddLast(tmp);
		tmp.GetComponent<UIimage>().loadNameToImage(e.name);
		tmp.GetComponent<UIimage>().clickAble = true;
		tmp.transform.SetParent(this.uiPanel.transform,false);
		tmp.transform.localPosition = new Vector2(-50- (imagesReady.Count-1)*110,87.5f);
		loadImage(tmp,e.name);		
	}

	private void loadImage(GameObject image,string operatoeName){
		string path;
		path = "Assets/Resources/RenderRes/spine_assets/char/"+operatoeName+"/default/painting/char_"+operatoeName+"_1.png";
		Texture2D texture = new Texture2D(1024,1024);
		texture.filterMode = FilterMode.Trilinear;
		byte[] bytes = File.ReadAllBytes(path);
		texture.LoadImage(bytes);
		Sprite sprite = Sprite.Create(texture,new Rect(300,0,450,1024),new Vector2(0.5f,0.5f),1.0f);
		image.GetComponent<UnityEngine.UI.Image>().sprite = sprite;
	}

	public void removeFromReadyList(GameObject something){
		imagesReady.Remove(imagesReady.Find(something));
		// GameObject.Destroy(something);
		updateReadyListLocation();
		updateWaitingListLocation();
	}

	private void updateReadyListLocation(){
		if(imagesReady.First == null){return;}
		LinkedListNode<GameObject> tmpNode = imagesReady.First;
		int i = 0;
		while(tmpNode.Next != null){
			tmpNode.Value.transform.localPosition = new Vector2(-50- i*110,87.5f);
			i++;
			tmpNode = tmpNode.Next;
		}
		tmpNode.Value.transform.localPosition = new Vector2(-50- i*110,87.5f);
	}

	public void addToWaitingList(GameObject something){
		imagesWaiting.AddLast(something);
		Debug.Log(something.GetComponent<UIimage>().clickAble);
		something.GetComponent<UIimage>().clickAble=false;
		updateReadyListLocation();
		updateWaitingListLocation();
	}

	private void updateWaitingListLocation(){
		if(imagesWaiting.First == null){
			return;
		}
		LinkedListNode<GameObject> tmpNode = imagesWaiting.First;
		int i = 0;
		while(tmpNode.Next != null){
			tmpNode.Value.transform.localPosition = new Vector2(-150-(imagesReady.Count+i)*110,87.5f);
			i++;
			tmpNode = tmpNode.Next;
		}
		tmpNode.Value.transform.localPosition = new Vector2(-150-(imagesReady.Count+i)*110,87.5f);
	}

	public void addToReadyList(GameObject something){
		imagesWaiting.Remove(something);
		imagesReady.AddLast(something);
		Debug.Log(something.GetComponent<UIimage>().clickAble);
		something.GetComponent<UIimage>().clickAble=true;
		updateReadyListLocation();
		updateWaitingListLocation();
	}

	public void log(){
		Debug.Log("ready"+imagesReady.Count);
		Debug.Log("waiting"+imagesWaiting.Count);
	}


}


//主UI相关数据包括鼠标所处状态
public class mainUIMouseData{

	private bool imageMouseDown;
	private bool cubeCreated;
	private GameObject tmpCube;
	private string operatorName;
	private bool mainUIMouseButtonUp;

	public mainUIMouseData(){

	}

	public bool getMainUIMouseButtonUp(){
		return mainUIMouseButtonUp;
	}

	public void setMainUIMouseButtonUp(bool something){
		mainUIMouseButtonUp = something;
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


public class actroSubUIData{
	private bool subUICreated;
	private bool subUIPointorDown;
	private GameObject subUI;
	private bool subCanvasPointorDown;
	private string name;

	public string getName(){
		return name;
	}

	public void setName(string something){
		name = something;
	}

	public bool getSubUIPointorDown(){
		return subUIPointorDown;
	}

	public void setSubUIPointorDown(bool something){
		subUIPointorDown = something;
	}

	public bool getSubCanvasPointorDown(){
		return subCanvasPointorDown;
	}

	public void setSubCanvasPointorDown(bool something){
		subCanvasPointorDown = something;
	}

	public GameObject getSubUI(){
		return subUI;
	}

	public void setSubUI(GameObject something){
		subUI = something;
	}

	public void setSubUICreated(bool something){
		subUICreated = something;
	}

	public bool getSubUICreated(){
		return subUICreated;
	}

}