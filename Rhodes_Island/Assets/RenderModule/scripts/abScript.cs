using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class abScript : MonoBehaviour {


	public GameObject cube;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		if(Input.GetMouseButtonDown(0)){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
            if(Physics.Raycast (ray,out hit)){
                if (hit.collider.gameObject == cube){
                    print("wtf");
                }
            }
		
		}
	}


	void creatActorUI(){
		
		// GameObject tmp = Instantiate(Resources.Load<GameObject>("RenderRes/Panel"),)

	}

	
}
