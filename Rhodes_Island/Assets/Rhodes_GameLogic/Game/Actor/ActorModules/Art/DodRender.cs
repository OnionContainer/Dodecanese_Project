using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodRender : MonoBehaviour {


	private static GameObject _origin;
	public static GameObject Origin{get{
		if (_origin == null) {
			_origin = GameObject.Find("SimpRenderOriginal");
		}
		return _origin;
	}}

	public Profile profile;
	[SerializeField]
	private GameObject _renderCube;

	void Awake() {
		_renderCube = Instantiate(Resources.Load<GameObject>("SimpRenderRes/Block"));
	}

	// Use this for initialization
	void Start () {
		_renderCube.transform.parent = GameObject.Find("SimpRenderOriginal").transform;
		if (profile.actorType == ActorType.OPERATOR) {
			_renderCube.GetComponent<Renderer>().material = Resources.Load<Material>("SimpRenderRes/Operator");
		} else if (profile.actorType == ActorType.MONSTER) {
			_renderCube.GetComponent<Renderer>().material = Resources.Load<Material>("SimpRenderRes/Enemy");
		}
		_renderCube.GetComponent<BlockClick>().boundActor = profile.actor;//设定相关游戏对象
		DodEventCentre.Instance.on(EType.UI_ACTOR_CLICKED, onClick);//监听点击事件 
	}
	
	// Update is called once per frame
	void Update () {
		_renderCube.transform.localPosition = new Vector3(profile.position.x, 2, profile.position.y);
	}

	private void onClick(DodEvent source){
		DE_ActorClicked e = (DE_ActorClicked)source;
		if (e.clickedActor == this.profile.actor) {
			Debug.Log("recieved");
			GameObject infoBoard = GlobalGameObject.InfoBoard;
			infoBoard.GetComponent<ObjInfoCtrl>().showInfo(this.profile);
		}

		

		
	}
	
}
