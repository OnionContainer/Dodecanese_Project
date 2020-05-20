using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
可能的优化方向：
当前获取节点内actor的策略会导致频繁创建DodReadOnlyLibrary对象
考虑通过在MapNodeCenter中创建长生命周期的对象来避免频繁构造

以及优先级排序
*/


public class MapNodeSeeker: ActorSeeker{

    private ActorType _targetType;
    private NodeMapper _nodeMapper = new NodeMapper();

    public MapNodeSeeker(ActorType targetType){
        _targetType = targetType;
        // RhodesGame.Instance.battle.mapNodeCenter.getActorsFromPoint
        // ReadOnlyCollectionBase a = new Dictionary<int,int>();
        // System.Collections.ReadOnlyCollectionBase a = null;
        
    }

    //返回目前捕捉的所有Actor中优先级最高者
    public GameObject getFocus(){
        return _collectActors()[0];
    }

    //返回目前捕捉的所有Actor中优先级为前num名者
    public GameObject[] getFocusList(int num){
        GameObject[] result = new GameObject[num];
        List<GameObject> list = _collectActors();

        for (int i = 0; i < num; i += 1) {
            result[i] = list[i];
        }


        return result;
    }

    //返回目前捕捉的所有Actor
    public GameObject[] getCaptureList(){
        return _collectActors().ToArray();
    }

    //返回是否存在已捕捉的Actor
    public bool targetExist(){
        foreach(IntVec point in _nodeMapper.finalPoints){
            if (RhodesGame.Instance.battle.mapNodeCenter[point, _targetType].Count > 0){
                return true;
            }
        }
        return false;
    }

    private List<GameObject> _collectActors(){//寻找当前所有被捕捉的actor
        List<GameObject> actorList = new List<GameObject>();

        foreach(IntVec point in _nodeMapper.finalPoints){
            foreach(GameObject actor in RhodesGame.Instance.battle.mapNodeCenter[point, _targetType]){
                if (!actorList.Contains(actor) && actor.GetComponent<Profile>().actorType == _targetType) {
                    actorList.Add(actor);
                }
            }
        }
        // profileList.Sort();//todo..实现priority后按照优先级排序

        return actorList;
    }
}


/*
一个数学类，用来计算当前所监控的点位是哪些
*/
class NodeMapper{

    private IntVec _origin;
    private List<IntVec> _shifts; 
    private int _rotate = 0;//顺时针旋转多少次
    private List<IntVec> _finalPoints = new List<IntVec>();

    #region getters and setters
    public IEnumerable<IntVec> shifts{set{
        _shifts = new List<IntVec>(value);
        _calculateFinalPoints();
    }}

    public int rotate{set{
        _rotate = value;
        _calculateFinalPoints();
    }}

    public IntVec origin{set{
        _origin = value;
        _calculateFinalPoints();
    }}

    public IEnumerable<IntVec> finalPoints{get{
        return _finalPoints;
    }}
    #endregion

    #region constructors
    public NodeMapper(){
        _origin = new IntVec(0,0);
        _shifts = new List<IntVec>();
        _calculateFinalPoints();
    }

    public NodeMapper(IntVec origin){
        _origin = origin;
        _shifts = new List<IntVec>();
        _calculateFinalPoints();
    }

    public NodeMapper(IntVec origin, IEnumerable<IntVec> list){
        _origin = origin;
        _shifts = new List<IntVec>(list);
        _calculateFinalPoints();
    }
    #endregion

    //计算当前的数据所对应的所有finalPoints
    private void _calculateFinalPoints(){
        _finalPoints.Clear();
        foreach(IntVec point in _shifts){
            IntVec shifted = point.clone();
            shifted.rotateClockwise(_rotate);
            shifted.plus(_origin);
            _finalPoints.Add(shifted);
        }
    }
}
