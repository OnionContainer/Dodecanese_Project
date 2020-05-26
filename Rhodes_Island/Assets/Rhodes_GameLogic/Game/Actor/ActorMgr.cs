using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorMgr{

	public List<GameObject> actors;//场地上的Actor
	public List<GameObject> sideBar;//存储在侧边栏还未上场的干员

	public ActorMgr(){
		actors = new List<GameObject>();
		sideBar = new List<GameObject>();
	}

	public void init(Object res){
		this._initEnemy(res);
		this._initOprt(res);
	}

	private void _initEnemy(Object res){
		//todo..
	}

	private	void _initOprt(Object res){
		//todo..
	}

	public void awake(){
		foreach(GameObject actor in actors){
			// actor.GetComponent<ActorControl>();
		}
	}

	public void update(){
		foreach(GameObject actor in actors){
			// actor.GetComponent<ActorControl>().update();
		}
	}

	public void reset(){

	}

	public void createActor(ActorType actorType, Object res){
		//create actor
	}

	public GameObject getActorBySymbol(int symbol){
		for (int i = 0; i < this.actors.Count; i += 1) {
			var actor = this.actors[i];
			if (symbol == actor.GetComponent<DodSymbol>().data){
				return actor;
			}
		}

		return null;
	}

	public void deployOprt(int symbol, Vector2 pos, int rotate){
		//todo..设置oprt到场上
	}

}
