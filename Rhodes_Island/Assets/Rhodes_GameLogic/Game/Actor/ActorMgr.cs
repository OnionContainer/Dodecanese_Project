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

	/*
	创建干员并将其移动到sideBar
	此函数所创建的干员处于未激活的状态
	*/
	public GameObject createOprt(string source){
		GameObject oprt = GameObject.Instantiate(GlobalPrefab.Actor);
		ActorData data = DodResources.GetActorData(source);
		if (data == null) {
			Debug.Log("NotFound");
			data = DodResources.GetActorData("DefaultOprt");
			Debug.Log(data.type);
		}
		oprt.GetComponent<ActorCtrl>().loadData(DodResources.GetActorData(source));
		this.sideBar.Add(oprt);
		return oprt;
	}

	/*
	创建敌人并将其移动到场上
	此函数所创建的敌人处于已激活的状态
	*/
	public GameObject createEnemy(string source){
		GameObject enemy = GameObject.Instantiate(GlobalPrefab.Actor);
		enemy.GetComponent<ActorCtrl>().loadData(DodResources.GetActorData(source));
		this.actors.Add(enemy);
		enemy.GetComponent<ActorCtrl>().activate();
		return enemy;
	}

	/*
	接收一个Actor对象，查看它是否在侧边栏中且已经准备好
	如果是，则按照提供的部属数据部署对象到地图上
	*/
	public void deployOprt(GameObject oprt, IntVec pos, int rotation){
		if (!sideBar.Contains(oprt)) {//对象未找到
			Debug.LogWarning("Deploying a non existing oprt");
			return;
		}
		Profile profile = oprt.GetComponent<Profile>();
		if (!profile.isDeployable){//对象不可部署
			Debug.LogWarning("Deploying a not deployable operator");
			return;
		}
		//部署逻辑
		profile.deploy(pos, rotation);
		oprt.SetActive(true);
		sideBar.Remove(oprt);
		actors.Add(oprt);
	}

	/*
	接受一个actor对象，查看它是否存在于场地上且能够撤退
	如果是，则撤退此对象
	*/
	public void retreatOprt(GameObject oprt){
		if (!actors.Contains(oprt)){//对象未找到
			Debug.LogWarning("retreating a none existing oprt");
			return;
		}
	}
	


	

}
