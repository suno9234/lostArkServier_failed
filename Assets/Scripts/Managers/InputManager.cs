using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager
{
    public Action<Define.KeyEvent>KeyAction = null;
    public Action<Define.MouseEvent> MouseAction = null;

    int _playerDir = 0;
    bool _mousePressed = false;
    float _pressedTime = 0;
    
    public void OnUpdate(){

        if(EventSystem.current.IsPointerOverGameObject()){
            return;
        }

        if (KeyAction!=null){
            if(Input.GetKey(KeyCode.W) && (Input.GetKey(KeyCode.S)== false)){
                if(Input.GetKey(KeyCode.D)){
                    KeyAction.Invoke(Define.KeyEvent.UR);
                    _playerDir = 9;
                }else if(Input.GetKey(KeyCode.A)){
                    KeyAction.Invoke(Define.KeyEvent.UL);
                    _playerDir = 7;
                }else{
                    KeyAction.Invoke(Define.KeyEvent.U);
                    _playerDir = 8;
                }
            }
            else if(Input.GetKey(KeyCode.S) && (Input.GetKey(KeyCode.W)==false)){
                if(Input.GetKey(KeyCode.D)){
                    KeyAction.Invoke(Define.KeyEvent.DR);
                    _playerDir = 3;
                }else if(Input.GetKey(KeyCode.A)){
                    KeyAction.Invoke(Define.KeyEvent.DL);
                    _playerDir = 1;
                }else{
                    KeyAction.Invoke(Define.KeyEvent.D);
                    _playerDir = 2;
                }
            }
            else if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) == false && Input.GetKey(KeyCode.W)==false && Input.GetKey(KeyCode.S)==false){
                KeyAction.Invoke(Define.KeyEvent.L);
                _playerDir = 4;
            }
            else if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A)== false && Input.GetKey(KeyCode.W)==false && Input.GetKey(KeyCode.S)==false ){
                KeyAction.Invoke(Define.KeyEvent.R);
                _playerDir = 6;
            }
            else if(!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D)){
                if(_playerDir != 0){
                    KeyAction.Invoke(Define.KeyEvent.Break);
                    _playerDir = 0;
                }
           }
        }
        if (MouseAction!= null){
            if(Input.GetMouseButton(0)){
                if(_mousePressed == false){
                    MouseAction.Invoke(Define.MouseEvent.PointerDown);
                    _pressedTime = Time.time;
                }

                MouseAction.Invoke(Define.MouseEvent.Press);
                _mousePressed = true;
            }else{
                if(_mousePressed){
                    if(Time.time < _pressedTime +0.2f)
                        MouseAction.Invoke(Define.MouseEvent.Click);
                    MouseAction.Invoke(Define.MouseEvent.PointerUp);
                }
                _mousePressed=false;
                _pressedTime = 0;
            }
            
        }
    }
    public void Clear(){
        KeyAction = null;
        MouseAction = null;
    }
}
