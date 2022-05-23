using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginScene : BaseScene
{
    public Button _startBtn;
    protected override void init(){
        base.init();
        SceneType = Define.Scene.Login;
        _startBtn.onClick.AddListener(LoadMainScene);
    }
    public override void Clear()
    {
        Debug.Log("LoginScene Clear");
    }

    private void Update(){
    }
    private void LoadMainScene(){
        Managers.Scene.LoadScene(Define.Scene.Game);
    }
}
