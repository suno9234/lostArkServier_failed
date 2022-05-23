using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance; //유일성 보장
    static Managers Instance{get{init(); return s_instance;}}
    #region Games
    GameManager _game = new GameManager();
    public static GameManager Game{get {return Instance._game;}}
    #endregion
    #region Contents
    DataManager _data = new DataManager();
    InputManager _input = new InputManager();
    ResourceManager _resource = new ResourceManager();
    UIManager _ui = new UIManager();
    SceneManagerEx _scene = new SceneManagerEx();
    SoundManager _sound = new SoundManager();
    PoolManager _pool = new PoolManager();
    
    public static DataManager Data {get{return Instance._data;}}
    public static InputManager Input{get{return Instance._input;}}
    public static ResourceManager Resource{get{return Instance._resource;}}
    public static UIManager UI{get{return Instance._ui;}}
    public static SceneManagerEx Scene{get{return Instance._scene;}}
    public static SoundManager Sound{get{return Instance._sound;}}
    public static PoolManager Pool{get{return Instance._pool;}}
    #endregion
    
    
    void Start()
    {
        //초기화
        init();
    }

    
    void Update()
    {
        _input.OnUpdate();
    }

    static void init(){ //초기화
        if (s_instance==null){
            GameObject go = GameObject.Find("@Managers");
            if (go == null){
                go = new GameObject{name = "@Managers"};
                go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();
            s_instance._data.init();
            s_instance._sound.init();
            s_instance._pool.init();

        }
        
    }
    public static void Clear(){
        Sound.Clear();
        Input.Clear();
        Scene.Clear();
        UI.Clear();

        //Pool은 항상 마지막에
        Pool.Clear();
    }
}
