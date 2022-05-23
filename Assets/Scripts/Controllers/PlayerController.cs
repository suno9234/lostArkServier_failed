using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : BaseController
{
    PlayerStat _stat;
    Vector2 _mousePosition;

    Transform _attackPivot;
    SpriteRenderer _spriteRenderer;
    bool _isShooting = false;
    bool _aming = false;
    //int _mask = (1<< (int)Define.Layer.Ground | 1<< (int)Define.Layer.Monster);

    public override Define.State State { 
        get => base.State; 
        set{
            base.State = value;
            Animator anim = GetComponent<Animator>();
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            switch(_state){
                case  Define.State.Die:
                    break;
                case  Define.State.Idle:
                    anim.Play("IDLE");
                    break;   
                case  Define.State.RUN:
                    anim.Play("RUN");
                    break;
                case Define.State.Break:
                    anim.Play("IDLE");
                    break;
                case Define.State.SHOT:
                    break;
                
            }
        } 
    }
    public override void init()
    {      
        
        _rigid2D = gameObject.GetComponent<Rigidbody2D>();

        WorldObjectType = Define.WorldObjcet.Player;
        _stat = gameObject.GetComponent<PlayerStat>();
        _mousePosition = new Vector2(0,0);
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _attackPivot = GameObject.FindGameObjectWithTag("AttackPivot").transform;

        //Managers.Input.MouseAction -=OnMouseEvent;
        //Managers.Input.MouseAction +=OnMouseEvent;
        Managers.Input.KeyAction -= OnKeyBoardEvent;
        Managers.Input.KeyAction += OnKeyBoardEvent;

        Managers.Input.MouseAction -= OnMouseEvent;
        Managers.Input.MouseAction += OnMouseEvent;
        StartCoroutine(BulletGenerator(1));

        //if(gameObject.GetComponentInChildren<UI_HPBar>() == null )
        //    Managers.UI.MakeWorldSpaceUI<UI_HPBar>(transform);
    }


    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    // 애니메이션 방향에 따라 재생하는 함수
    protected override void UpdateMoving(){
        if (Dir2V3(_dir).x <0){
            _spriteRenderer.flipX = false;
        }else if (Dir2V3(_dir).x>0){
            _spriteRenderer.flipX = true;
        }
        _rigid2D.MovePosition(transform.position + Dir2V3(_dir) * _stat.MoveSpeed * Time.deltaTime);
    }

    protected override void UpdateSkill(){
        if(_lockTarget != null){
            Vector3 dir = _lockTarget.transform.position - transform.position;
            Quaternion quat = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Lerp(transform.rotation,quat,20*Time.deltaTime);
        }
    }
    
    private void OnKeyBoardEvent(Define.KeyEvent evt){
        if(_aming){

        }else{
            switch(evt){
                case Define.KeyEvent.U:
                    State = Define.State.RUN;
                    _dir = 8;
                    
                break;
                case Define.KeyEvent.UR:
                    State = Define.State.RUN;
                    _dir = 9;
                break;
                case Define.KeyEvent.UL:
                    State = Define.State.RUN;
                    _dir = 7;
                break;
                case Define.KeyEvent.D:
                    State = Define.State.RUN;
                    _dir = 2;
                break;
                case Define.KeyEvent.DL:
                    State = Define.State.RUN;
                    _dir = 1;
                break;
                case Define.KeyEvent.DR:
                    State = Define.State.RUN;
                    _dir = 3;
                break;
                case Define.KeyEvent.L:
                    State = Define.State.RUN;
                    _dir = 4;
                break;
                case Define.KeyEvent.R:
                    State = Define.State.RUN;
                    _dir = 6;
                break;
                case Define.KeyEvent.Break:
                    State = Define.State.Idle;
                break;
                case Define.KeyEvent.Stop:
                    State = Define.State.Idle;
                break;
            }
        }
    }

    [SerializeField]
    Vector2 mousePosition;
    [SerializeField]
    Vector2 playerPosition;

    private void OnMouseEvent(Define.MouseEvent evt){
        mousePosition = Vector3.zero;
        playerPosition = transform.position;
        switch(evt){
            case Define.MouseEvent.Press:
                _aming = true;
                mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);    
                Vector2 vectorDir = (playerPosition-mousePosition).normalized;
                if(vectorDir.y < -0.9){
                    _dir = 8;
                }else if(vectorDir.y>0.9){
                    _dir = 2;
                }else if(vectorDir.x<-0.9){
                    _dir = 6;
                }else if(vectorDir.x>0.9){
                    _dir = 4;
                }else if(vectorDir.x>0){
                    if(vectorDir.y>0){
                        _dir = 1;
                    }else{
                        _dir = 7;
                    }
                }else if(vectorDir.x<0){
                    if(vectorDir.y>0){
                        _dir = 3;
                    }else{
                        _dir = 9;
                    }
                }
                if(!_isShooting)
                    State = Define.State.AMING;
            break;
            case Define.MouseEvent.PointerUp:
                _aming = false;
                _isShooting = true;
                State = Define.State.SHOT;
            break;
        }
    }
    Vector3 Dir2V3(int dir){
    
        switch(dir){
            case 8:
            return new Vector3(0,1,0);
            case 9:
            return new Vector3(1,1,0).normalized;
            case 6:
            return new Vector3(1,0,0);
            case 3:
            return new Vector3(1,-1,0).normalized;
            case 2:
            return new Vector3(0,-1,0);
            case 1:
            return new Vector3(-1,-1,0).normalized;
            case 4:
            return new Vector3(-1,0,0);
            case 7:
            return new Vector3(-1,1,0).normalized;
        }
        return new Vector3(0,0,0);
    }

    public static void PlayAnimBy8Dir(string animName,int dir,Animator anim,SpriteRenderer spriteRenderer,bool changeDir){
        switch(dir){
            case 8:
            if(changeDir){
                spriteRenderer.flipX = false;
                anim.Play(animName+"_U");
            }else{
                //spriteRenderer.flipX = true;
                anim.Play(animName+"_U");
            }
            break;
            case 9:
            if(changeDir){
                spriteRenderer.flipX = false;
                anim.Play(animName+"_UR");
            }else{
                spriteRenderer.flipX = false;
                anim.Play(animName+"_UR");
            }
            break;
            case 6:
            spriteRenderer.flipX = false;
            anim.Play(animName+"_R");
            break;
            case 3:
            spriteRenderer.flipX = false;
            anim.Play(animName+"_DR");
            break;
            case 2:
            anim.Play(animName+"_D");
            break;
            case 1:
            //spriteRenderer.flipX = true;
            anim.Play(animName+"_DR");
            break;
            case 4:
            //spriteRenderer.flipX = true;
            anim.Play(animName+"_R");
            break;
            case 7:
            //spriteRenderer.flipX = true;
            anim.Play(animName+"_UR");
            break;
        }
    }
    IEnumerator BulletGenerator(float delayTime){
        yield return new WaitForSeconds(delayTime);
        Managers.Game.Spawn(Define.WorldObjcet.Attack,"Bullet_Circle",_attackPivot.transform,1);
        StartCoroutine(BulletGenerator(1));
    }
}
