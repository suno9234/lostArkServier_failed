using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    public T Load<T>(string path) where T : Object{
        if(typeof(T)==typeof(GameObject)){
            string name = path;
            int index = name.LastIndexOf('/');
            if(index >=0){
                name = name.Substring(index +1);
            }
            GameObject go = Managers.Pool.GetOriginal(name);
            if(go != null){
                return go as T;
            }
        }
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null,int version = 0){
        GameObject original = Load<GameObject>($"Prefabs/{path}");
        if (original == null){
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }
        if(original.GetComponent<Poolable>()!=null){
            return Managers.Pool.Pop(original,parent).gameObject;
        }
        GameObject go = null;
        if (version == 0){
            go = Object.Instantiate(original,parent);
        }else if (version ==1){
            go = Object.Instantiate(original,parent.position,new Quaternion(0,0,0,0));
        }
        go.name = original.name;
        return go;
    }

    public void Destroy(GameObject go){
        if (go == null){
            return;
        }
        Poolable poolable = go.GetComponent<Poolable>();
        if(poolable!=null){
            Managers.Pool.Push(poolable);
        }
        
        Object.Destroy(go);
    }
}
