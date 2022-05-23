using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    GameObject _player;
    HashSet<GameObject> _monsters = new HashSet<GameObject>();

    public GameObject Spawn(Define.WorldObjcet type ,string path, Transform parent = null,int version = 0){
        GameObject go = Managers.Resource.Instantiate(path,parent,version);
        switch(type){
            case Define.WorldObjcet.Monster:
                _monsters.Add(go);
            break;
            case Define.WorldObjcet.Player:
                _player = go;
            break;
        }
        return go;
    }

    public Define.WorldObjcet GetWorldObjcetType(GameObject go){
        BaseController bc = go.GetComponent<BaseController>();
        if(bc == null){
            return Define.WorldObjcet.Unknown;
        }
        return bc.WorldObjectType;
    }
    public void Despawn(GameObject go){
        Define.WorldObjcet type = GetWorldObjcetType(go);
        switch (type){
            case Define.WorldObjcet.Player:
                if(_player   == go){
                    _player = null;
                }
            break;
            case Define.WorldObjcet.Monster:
                if(_monsters.Contains(go)){
                    _monsters.Remove(go);
                }
            break;
        }
        Managers.Resource.Destroy(go);
    }
}
