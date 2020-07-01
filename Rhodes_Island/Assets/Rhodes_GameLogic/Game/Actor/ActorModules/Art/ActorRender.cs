using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActorRender : MonoBehaviour {

	private float x,y;
	public GameObject myself;
	public bool hideBlock;
	public bool showPath = true;
	private Vector2 tmpvec2;
	public int level = 2;
	private GameObject myCube;


	// Use this for initialization
	void Start () {
		// Debug.Log(this);
		tmpvec2 = GetVector2();
		x = tmpvec2.x;
		y = tmpvec2.y;
		creatActorCube();
		if(this.hideBlock == true){
			myself.GetComponent<MeshRenderer>().enabled = false;
		}
		

	}


	
	// Update is called once per frame
	void Update () {
		// Debug.Log(this.myself);
		Vector2 tmpvec2 = GetVector2();
		moveTo(tmpvec2);
		sendPosition(showPath);
		
	}

	private void creatActorCube(){
		GameObject actorCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		actorCube.transform.parent = GlobalGameObject.Ground_Zero.transform;
		actorCube.transform.localPosition = new Vector3(x,level,y);
		myCube = actorCube;
	}




	private void moveTo(Vector2 vec){
		x = vec.x;
		y = vec.y;
		myCube.transform.localPosition = new Vector3(x,level,y);
	}

	private void sendPosition(bool isSend){
		if(isSend == true){
			DodEventCentre.Instance.Invoke(new RM_ActorLocation(new Vector2(x,y)));
		}
	}

	private Vector2 GetVector2(){
		Vector2 tmpvec2 = myself.GetComponent<Profile>().position;
		return tmpvec2;
	}
}

