﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelScript : MonoBehaviour {

	private Vector3 worldPosition;
	private Vector2 mousePosition;
	private Vector3 cubeWorldPosition;
	private Vector2 cubeWorldPositionToCanvasPosition;
	

	// Use this for initialization
	void Start () {
		Performance_Center.Instance.ui.data.setMouseDown(false);
		Performance_Center.Instance.ui.data.setMainUIMouseButtonUp(false);
		
	}


	
	// Update is called once per frame
	void Update () {


		

		
		//获取鼠标相对于棋盘平面坐标
		Plane plane = new Plane(Vector3.up, -GlobalGameObject.Ground_Zero.transform.position.y-1);

		float distance;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (plane.Raycast(ray, out distance))
		{
			worldPosition = ray.GetPoint(distance);
		}


		Vector2 mouseLocalPosition = new Vector2(0.5f+worldPosition.x-GlobalGameObject.Ground_Zero.transform.position.x,0.5f+worldPosition.z-GlobalGameObject.Ground_Zero.transform.position.z);
		
		Vector2 mapSize = loadMapSize();
		




		//修正鼠标误差
		if(Mathf.Floor(mouseLocalPosition.x)<0){
			mouseLocalPosition.x = 0;
		}
		if(Mathf.Floor(mouseLocalPosition.y)<0){
			mouseLocalPosition.y = 0;
		}
		if(Mathf.Floor(mouseLocalPosition.x) >= mapSize.x){
			mouseLocalPosition.x = mapSize.x - 0.1f;
		}
		if(Mathf.Floor(mouseLocalPosition.y) >= mapSize.y){
			mouseLocalPosition.y = mapSize.y - 0.1f;
		}
		mousePosition = new Vector2((int)(mouseLocalPosition.x - 0.5f),(int)(mouseLocalPosition.y - 0.5f));
		


		//通过bool值检测鼠标状态并执行相关功能
		if(Performance_Center.Instance.ui.data.getmouseDown() == true){
			if(Performance_Center.Instance.ui.data.getCubeCreated() == false){
				Performance_Center.Instance.ui.data.creatCube();
				
				Performance_Center.Instance.ui.data.setCubeCreated(true);

			}
			Performance_Center.Instance.ui.data.moveCube(mousePosition);
			if(Input.GetMouseButtonUp(0)){
				Performance_Center.Instance.ui.data.setMouseDown(false);
				Performance_Center.Instance.ui.data.destoryCube();
				string name = Performance_Center.Instance.ui.data.getOpName();
				DodEventCentre.Instance.Invoke(new RM_OperatorDeployed(name,mousePosition));
				print(name+" "+mousePosition);
			}
		}

		if(Performance_Center.Instance.ui.subUIData.getSubUICreated() == true){
			if(Performance_Center.Instance.ui.subUIData.getSubCanvasPointorDown()){
				if(Performance_Center.Instance.ui.subUIData.getSubUIPointorDown() == false){
					destorySubUI();
					Performance_Center.Instance.ui.subUIData.setSubCanvasPointorDown(false);
					Performance_Center.Instance.ui.subUIData.setSubUIPointorDown(false);
				}

			}
		}
		
		

		
	}


	private Vector2 loadMapSize(){
		return Performance_Center.Instance.mapSize();
		
	}

	public void MouseButtonUp(){
		Performance_Center.Instance.ui.data.setMainUIMouseButtonUp(true);
	}

	//子ui左键功能
	public void leftButtonClicked(){
		string tmp = Performance_Center.Instance.ui.subUIData.getName();
		DodEventCentre.Instance.Invoke(new RM_SubUILeftButtonClicked(tmp));
		print("leftButtonClicked "+tmp);
		// destorySubUI();
	}

	//子ui右键功能
	public void rightButtonClicked(){
		string tmp = Performance_Center.Instance.ui.subUIData.getName();
		DodEventCentre.Instance.Invoke(new RM_SubUIRightButtonClicked(tmp));
		print("rightButtonClicked "+tmp);
		// destorySubUI();
	}

	
	public void destorySubUI(){
		if(Performance_Center.Instance.ui.subUIData.getSubUICreated() == true){
			GameObject.Destroy(Performance_Center.Instance.ui.subUIData.getSubUI());
			Performance_Center.Instance.ui.subUIData.setSubUICreated(false);
		}
	}

	public void subCanvasPointorDown(){
		Performance_Center.Instance.ui.subUIData.setSubCanvasPointorDown(true);
		// print(Performance_Center.Instance.ui.subUIData.getSubCanvasPointorDown()+" "+Performance_Center.Instance.ui.subUIData.getSubUIPointorDown());
		
	}

	public void subUIPointorDown(){
		Performance_Center.Instance.ui.subUIData.setSubUIPointorDown(true);
		// print(Performance_Center.Instance.ui.subUIData.getSubCanvasPointorDown()+" "+Performance_Center.Instance.ui.subUIData.getSubUIPointorDown());

	}

	public void test(){
		DodEventCentre.Instance.Invoke(new RM_ShowUIOperator("002_amiya"));
	}

}

