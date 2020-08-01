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
		Vector2 tmpvec2 = GetVector2();
		moveTo(tmpvec2);
		sendPosition(showPath);
		// Debug.Log(tmpvec2);
		
	}

	private void creatActorCube(){
		GameObject actorCube = Resources.Load<GameObject>("RenderRes/ActorBlock");
		GameObject actorBlock = Instantiate(actorCube,new Vector3(x,level,y),Quaternion.identity,GlobalGameObject.Ground_Zero.transform);
		print(actorBlock);
		actorBlock.transform.localPosition = new Vector3(x,level,y);
		myCube = actorBlock;
		actorBlock.GetComponent<abScript>().setName(myself.GetComponent<Profile>().name);
	}




	private void moveTo(Vector2 vec){
		x = vec.x;
		y = vec.y;
		myCube.transform.localPosition = new Vector3(x,level,y);
		myCube.GetComponent<abScript>().setPosition(new Vector2((int)x,(int)y));
		// Debug.Log(myCube.transform.localPosition);

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

