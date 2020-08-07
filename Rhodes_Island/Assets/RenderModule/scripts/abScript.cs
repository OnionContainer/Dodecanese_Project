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
		Performance_Center.Instance.ui.subUIData.setSubUICreated(false);
	}
	
	// Update is called once per frame
	void Update () {
		

		if(Input.GetMouseButtonUp(0)){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
            if(Physics.Raycast (ray,out hit)){
                if (hit.collider.gameObject == cube){
					actorBlockClicked();

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

	private void actorBlockClicked(){
		print(myname+"  "+position);
		print("Message sent successfully");
		DodEventCentre.Instance.Invoke(new RM_ActorBlockClicked(myname,position,cube.transform.position));
		if(Performance_Center.Instance.ui.subUIData.getSubUICreated() == false){
			GameObject tmp = loadSubCanvas();
			subUIRelocate(tmp);
			Performance_Center.Instance.ui.subUIData.setName(myname);
			Performance_Center.Instance.ui.subUIData.setSubUI(tmp);
			Performance_Center.Instance.ui.subUIData.setSubUICreated(true);
			Performance_Center.Instance.ui.subUIData.setSubCanvasPointorDown(false);
			Performance_Center.Instance.ui.subUIData.setSubUIPointorDown(false);
		}		
	}
	
	private GameObject loadSubCanvas(){
		return GameObject.Instantiate(Resources.Load<GameObject>("RenderRes/Canvas"));
	}

	private void subUIRelocate(GameObject something){
		something.transform.SetParent(cube.transform,false);
		something.transform.rotation = GlobalGameObject.Canvas.transform.rotation;
		something.transform.localPosition = new Vector3(0,0,0);
	}
	

}