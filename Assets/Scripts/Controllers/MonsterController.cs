using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : BaseController
{
    Stat _stat;
    bool _isDelay = false;
    Rigidbody2D _rigidbody2D;
    float _delayTime = 0.2f;
    [SerializeField]
    float _scanRange = 10;

    [SerializeField]
    float _attackRange = 0;

    SpriteRenderer _spriteRenderer ;
    public override void init()
    {
        WorldObjectType = Define.WorldObjcet.Monster;
        _stat = gameObject.GetComponent<Stat>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        /*if(gameObject.GetComponentInChildren<UI_HPBar>() == null )
            Managers.UI.MakeWorldSpaceUI<UI_HPBar>();  
        */ 
    }

    protected override void UpdateIdle()
    {
        //Debug.Log("Monster UpdateIdle");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player == null){
            return;
        }
        float distance = (player.transform.position - transform.position).magnitude;
        if(distance<_scanRange){
            _lockTarget = player;
            State = Define.State.RUN;
            return;
        }

    }
    protected override void UpdateMoving()
    {
        if(_lockTarget != null){
            _destPos = _lockTarget.transform.position;
            float distance = (_destPos - transform.position).magnitude;
        }

        Vector3 dir = _destPos-transform.position;    
        
        //transform.rotation =  Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(dir),10*Time.deltaTime);

        if (dir.x>0){
            _spriteRenderer.flipX = true;
        }else{
            _spriteRenderer.flipX = false;
        }

        _rigidbody2D.velocity = dir.normalized*_stat.MoveSpeed;
        //transform.position += dir.normalized*Time.deltaTime*_stat.MoveSpeed;
            
        //transform.LookAt(_destPos); => 캐릭터 돌아가게 하는 주범
        
    }
    protected override void UpdateSkill()
    {
        
    }
    
    private void OnCollisionStay2D(Collision2D collision2D){
        if(collision2D.gameObject.tag == "Player" && !_isDelay){
            _isDelay = true;
            Debug.Log("Attack");
            _lockTarget.GetComponent<PlayerStat>().Hp -= _stat.Attack;
            StartCoroutine(CountAttackDelay());
        }

    }

    IEnumerator CountAttackDelay(){
        yield return new WaitForSeconds(_delayTime);
        _isDelay = false;
    }

}
