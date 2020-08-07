using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIimage : MonoBehaviour {

	public GameObject image;
	private bool imageDisabled = false;
	public string myName;
	public bool clickAble;

	public void hideImage(){
		if(this.imageDisabled == false){
			// this.image.SetActive(false);
			// image.transform.localPosition += new Vector3(0,-175,0);
			Performance_Center.Instance.ui.removeFromReadyList(image);
			Performance_Center.Instance.ui.addToWaitingList(image);
			
			this.imageDisabled = true;
			DodEventCentre.Instance.on(EType.SHOW_UI_OPERTAOR,showImage);
			// Performance_Center.Instance.ui.log();
		}

		
	}

	public void showImage(DodEvent source){
		RM_ShowUIOperator e = (RM_ShowUIOperator) source;
		string name = e.name;
		// print(myName.Equals(name));
		if(!myName.Equals(name)){
			return;
		}

		if(this.imageDisabled == true){
			this.imageDisabled = false;
			Performance_Center.Instance.ui.addToReadyList(image);
			// Performance_Center.Instance.ui.log();
		}
	}


	public void mouseButtonDown(){
		if(clickAble){
			Performance_Center.Instance.ui.data.setMouseDown(true);
			Performance_Center.Instance.ui.data.setCubeCreated(false);
		}
	}


	public void setNameToUIControl(){
		Performance_Center.Instance.ui.data.setOpName(myName);
	}

	public void loadNameToImage(string name){
		myName = name;
	}
	

}
