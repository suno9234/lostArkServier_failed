using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour
{
    public static void PlayAnimBy8Dir(string animName,int dir,Animator anim,SpriteRenderer spriteRenderer){
        switch(dir){
            case 8:
            anim.Play(animName+"_U");
            break;
            case 9:
            spriteRenderer.flipX = false;
            anim.Play(animName+"_UR");
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
            spriteRenderer.flipX = true;
            anim.Play(animName+"_DR");
            break;
            case 4:
            spriteRenderer.flipX = true;
            anim.Play(animName+"_R");
            break;
            case 7:
            spriteRenderer.flipX = true;
            anim.Play(animName+"_UR");
            break;
        }
    }
    public static T GetOrAddComponent<T>(GameObject go )where T :  UnityEngine.Component{
        T component  = go.GetComponent<T>();
        if(component == null){
            component = go.AddComponent<T>();
        }
        return component;
    }
    public static GameObject FindChild(GameObject go, string name = null,bool recursive = false){
        Transform transform = FindChild<Transform>(go,name,recursive);
        if (transform == null){
            return null;
        }else{
            return  transform.gameObject;
        }
    
    }
    public static T FindChild<T>(GameObject go, string name = null,bool recursive = false) where T : UnityEngine.Object{
        if(go ==null){
            return null;
        }
        if(recursive == false){
            for ( int i =0; i <go.transform.childCount;i++){
                Transform transform = go.transform.GetChild(i);
                if(string.IsNullOrEmpty(name) || transform.name == null){
                    T component = transform.GetComponent<T>();
                    if(component != null){
                        return component;
                    }
                }
            }
        }else{
            foreach(T component in go.GetComponentsInChildren<T>()){
                if(string.IsNullOrEmpty(name) || component.name == name){
                    return component;
                }
            }
        }
        return null;

    }
}
