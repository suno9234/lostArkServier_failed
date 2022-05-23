using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_Popup
{

    enum Buttons{
        PointButton,
    }

    enum Texts{
        PointText,
        ScoreText,
    }

    enum GameObjects{
        TestObject,
    }

    enum Images{
        ItemIcon,
    }

    public override void init()
    {   
        base.init();
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));

        GameObject go = GetImage((int)Images.ItemIcon).gameObject;
       
        BindEvent(go,(PointerEventData data )=>{go.gameObject.transform.position = data.position;});
    }

    int _score = 0;
    public void OnButtonClicked(){
        _score++;
        
    }
}
