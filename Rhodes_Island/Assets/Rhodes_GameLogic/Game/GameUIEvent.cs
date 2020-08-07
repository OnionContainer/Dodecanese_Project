using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//用于接收UI事件的类
public class GameUIEventReciever{

    public GameUIEventReciever(){
        DodEventCentre.Instance.on(EType.OPERATOR_DEPLOYED, (DodEvent source)=>{
            RM_OperatorDeployed e = (RM_OperatorDeployed)source;
            
            ActorMgr actorMgr = RhodesGame.Instance.battle.actorMgr;
            GameObject oprt = actorMgr.createOprt(e.name);
            actorMgr.deployOprt(oprt, new IntVec(e.location), 0);


        });
    }

}
