using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inven_Item : UI_Base
{
    enum GameObjects{
        ItemIcon,
        ItemNameText,
    }

    string _name;
    // Start is called before the first frame update

    public override void init()
    {
        Bind<GameObject>(typeof(GameObjects));
        Get<GameObject>((int)GameObjects.ItemNameText).GetComponent<Text>().text = _name;
        Get<GameObject>((int)GameObjects.ItemIcon).BindEvent( (PointerEventData) => {Debug.Log($"아이템 클릭 : {_name}"); });
        
    }
    public void Setinfo(string name){
        _name = name;
    }
}
