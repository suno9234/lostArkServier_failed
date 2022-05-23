using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Vector2 _dir;
    float _radius = 0.7f;
    float _damage = 5;
    float _speed = 1;


    void Start()
    {
        _dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - GameObject.FindGameObjectWithTag("AttackPivot").transform.position).normalized;
        transform.position +=  (Vector3)_dir * _radius;
    }

    void Update()
    {
        transform.Translate(Time.deltaTime * _dir * _speed);
    }
    private void OnTriggerEnter2D(Collider2D collider2D) {
        if (collider2D.gameObject.tag == "Monster"){
            Debug.Log("Player Attacks Monster");
            collider2D.gameObject.GetComponent<Stat>().Hp -= (int)_damage;
            if(collider2D.gameObject.GetComponent<Stat>().Hp <=0){
                Managers.Game.Despawn(collider2D.gameObject);
            }
            Managers.Game.Despawn(this.gameObject);
        }
        if (collider2D.gameObject.tag == "BulletBorder"){
            Managers.Game.Despawn(this.gameObject);
        }
    }
}
