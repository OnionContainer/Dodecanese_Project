using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIimage : MonoBehaviour {

	public GameObject image;
	private bool imageDisabled = false;
	public string myName;

	public void hideImage(){
		if(this.imageDisabled == false){
			// this.image.SetActive(false);
			image.transform.localPosition += new Vector3(0,-100,0);
			this.imageDisabled = true;
			DodEventCentre.Instance.on(EType.OPERATOR_WITHDRAWD,showImage);
			
		}

		
	}

	public void showImage(DodEvent source){
		RM_OperatorWithdrawd e = (RM_OperatorWithdrawd) source;
		string name = e.name;
		if(myName != name){
			return;
		}

		if(this.imageDisabled == true){
			this.imageDisabled = false;
			image.transform.localPosition += new Vector3(0,100,0);
		}
	}


	public void mouseButtonDown(){
		Performance_Center.Instance.ui.data.setMouseDown(true);
		Performance_Center.Instance.ui.data.setCubeCreated(false);
	}


	public void setNameToUIControl(){
		Performance_Center.Instance.ui.data.setOpName(myName);
	}

	public void loadNameToImage(string name){
		myName = name;
	}
}
