using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
    [SerializeField]
    protected Vector3 _destPos;
    [SerializeField]
    protected GameObject _lockTarget;
    [SerializeField]
    protected Define.State _state = Define.State.Idle;

    [SerializeField]
    protected Rigidbody2D _rigid2D;

    [SerializeField]
    protected int _dir;

    public Define.WorldObjcet WorldObjectType{get;protected set;} = Define.WorldObjcet.Unknown;

    public virtual Define.State State{
        get{return _state;}
        set{
            _state = value;
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
                case  Define.State.Skill:
                    anim.CrossFade("ATTACK",0.1f,-1,0);
                    break;
            }
        }
    }

    

    private void Start(){
        init();
    }
    protected virtual void FixedUpdate()
    {

        switch(State){
            case Define.State.Die:
                UpdateDie();
                break;
            case Define.State.Idle:
                UpdateIdle();
                break;
            case Define.State.RUN:
                UpdateMoving();
                break;
            case Define.State.Skill:
                UpdateSkill();
                break;
        }
        
    }
    public abstract void init();
    protected virtual void UpdateDie(){}
    protected virtual void UpdateIdle(){}
    protected virtual void UpdateMoving(){}
    protected virtual void UpdateSkill(){}
}
