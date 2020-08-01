using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class abScript : MonoBehaviour {

	private string myname;
	private Vector2 position;
	public GameObject cube;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		

		if(Input.GetMouseButtonUp(0)){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
            if(Physics.Raycast (ray,out hit)){
                if (hit.collider.gameObject == cube){
					sentEvent();
                }
            }
		
		}
	}

	public void setName(string something){
		myname = something;
	}

	public void setPosition(Vector2 location){
		position = location;
	}

	public void sentEvent(){
		print(myname+"  "+position);
		print("Message sent successfully");
		DodEventCentre.Instance.Invoke(new RM_ActorBlockClicked(myname,position,cube.transform.position));		
	}
	
	
}
