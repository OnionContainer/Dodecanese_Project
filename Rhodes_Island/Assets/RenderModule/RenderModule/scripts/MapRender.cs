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

		if(xUp > height -1 || yUp > length -1 ||xDown < 0 || yDown < 0){
			// DodEventCentre.Instance.off(EType.ACTOR_LOCATION,pathListener);
			return;
		}
		Vector2 location1 = new Vector2(xDown,yDown);
		Vector2 location2 = new Vector2(xDown,yUp);
		Vector2 location3 = new Vector2(xUp,yDown);
		Vector2 location4 = new Vector2(xUp,yUp);
		// Debug.Log(yDown);
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
	

	public static void init(int width, int height ,bool hideOrigin = true){
		Performance_Center.Instance = new Performance_Center();
		Performance_Center.Instance.origin = GlobalGameObject.Ground_Zero;
		//*****************************//
		Performance_Center.Instance.deployMap(height,width,hideOrigin);
		//*****************************//
		_test();
		Debug.Log("Performance_Center initialization complete!!");
	}



	private static void _test(){
		//anything you want to do 
	}


	///<summary> 设置地图 </summary>
	///<param name = "height"> 地图高度 </param>
	///<param name = "length"> 地图宽度 </param>
	///<param name = "hideOrigin"> 隐藏原点（默认隐藏） </param>
	///<returns></return>
	public void deployMap(int height, int length, bool hideOrigin = true){
		Performance_Center.Instance.map = new MapRender(length,height, hideOrigin);
	}



}