using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HPBar : UI_Base
{
    enum GameObjects{
        HPBar,
    }

    [SerializeField]
    Stat _stat;

    public override void init()
    {
        Bind<GameObject>(typeof(GameObjects));
        _stat = transform.parent.GetComponent<Stat>();
        
    }
    private void Update(){
        Transform parent = transform.parent;
        transform.position = parent.position + Vector3.up * 0.7f;
        transform.rotation = Camera.main.transform.rotation;

        float ratio = (float)_stat.Hp / (float)_stat.MaxHp;
        SetHPRatio(ratio);

    }
    public void SetHPRatio(float ratio){
        GetObject((int)GameObjects.HPBar).GetComponent<Slider>().value = ratio;
    }
}
