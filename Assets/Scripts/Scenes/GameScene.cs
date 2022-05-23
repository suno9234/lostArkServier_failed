using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    
    // Start is called before the first frame update

    CursorController _cursor;
    GameObject _player;
    GameObject _attackPivot;

    protected override void init(){
        base.init();

        SceneType = Define.Scene.Game;
        //Managers.UI.ShowSceneUI<UI_Inven>();
        Dictionary<int,Data.Stat> dict = Managers.Data.StatDict;
        gameObject.GetOrAddComponent<CursorController>();
        _player = Managers.Game.Spawn(Define.WorldObjcet.Player,"Player");
        Camera.main.gameObject.GetOrAddComponent<CameraController>().SetPlayer(_player);
        _attackPivot = GameObject.FindGameObjectWithTag("AttackPivot");
        Managers.UI.MakeWorldSpaceUI<UI_HPBar>(_player.transform,"UI_HPBar");
        //Managers.Game.Spawn(Define.WorldObjcet.Monster,"Knight");
    }  

    
    public override void Clear(){

    }
}
