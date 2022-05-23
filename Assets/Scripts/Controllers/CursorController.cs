using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    //int _mask = (1<< (int)Define.Layer.Ground | 1<< (int)Define.Layer.Monster);
    Texture2D _attackIcon;
    Texture2D _handIcon;
    Texture2D _aimIcon;
    //CursorType _cursorType = CursorType.None;

    // Start is called before the first frame update
    void Start()
    {
        _attackIcon = Managers.Resource.Load<Texture2D>("Textures/Cursor/Attack");
        _handIcon = Managers.Resource.Load<Texture2D>("Textures/Cursor/Hand");
        _aimIcon = Managers.Resource.Load<Texture2D>("Textures/Cursor/Aim");
        Cursor.SetCursor(_aimIcon,new Vector2(0,0),CursorMode.Auto);

    }

    enum CursorType{
        None,
        Attack,
        Hand,
        Aim,
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButton(0)){
            return;
        }
        /*
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.DrawRay(Camera.main.transform.position,ray.direction*100.0f,Color.red,1.0f);
        RaycastHit hit;
        
        if(Physics.Raycast(ray,out hit,100.0f,_mask)){
            if(hit.collider.gameObject.layer == (int)Define.Layer.Monster){
                if(_cursorType!=CursorType.Attack){
                    Cursor.SetCursor(_attackIcon,new Vector2(_attackIcon.width/5,0),CursorMode.Auto);
                    _cursorType= CursorType.Attack;
                }//
            }else{
                if(_cursorType!=CursorType.Hand){
                    Cursor.SetCursor(_handIcon,new Vector2(_handIcon.width/3,0),CursorMode.Auto);
                    _cursorType= CursorType.Hand;
                }
            }
            //Debug.Log($"goto {hit.point}");
            //Debug.Log($"Raycast Camera @ {hit.collider.name}");
    
        }
        */    
    }
}
