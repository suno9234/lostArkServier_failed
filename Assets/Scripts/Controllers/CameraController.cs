using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]Vector3 _delta = new Vector3(0.0f,0.0f,-0.5f);
    [SerializeField]GameObject _player =null;
    [SerializeField]Define.CameraMode _mode = Define.CameraMode.Orthographic;
    
    public void SetPlayer(GameObject player){
        _player= player;
    }
    void Start()
    {

    }

    void LateUpdate()
    {
        if (_mode == Define.CameraMode.QuarterView){
            if(_player==null){
                return;
            }
            RaycastHit hit;
            if(Physics.Raycast(_player.transform.position,_delta,out hit,_delta.magnitude,LayerMask.GetMask("Wall"))){
                float dist = (hit.point - _player.transform.position).magnitude*0.8f;
                transform.position = _player.transform.position+_delta.normalized*dist;

            }else{
                transform.position = _player.transform.position+_delta;
                transform.LookAt(_player.transform);
            }
        }else if(_mode ==Define.CameraMode.Orthographic){
            if(_player==null){
                return;
            }
            transform.position = _player.transform.position+_delta;
            transform.LookAt(_player.transform);
        }
        
    }
    public void SetQuarterView(Vector3 delta){
        _mode = Define.CameraMode.QuarterView;
        _delta = delta;
    }
}