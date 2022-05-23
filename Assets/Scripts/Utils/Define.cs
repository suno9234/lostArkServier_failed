using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum WorldObjcet{
        Unknown,
        Player,
        Monster,
        Attack,
    }
    public enum State{
        Die,
        RUN,
        Idle,
        Break,
        Skill,
        AMING,
        SHOT,
    }
    public enum Layer{
        Monster = 8,
        Ground  = 9,
        Block   = 10,
    }
    public enum Scene{
        Unknown,
        Login,
        Lobby,
        Game,
        
    }
    public enum Sound{
        Bgm,
        Effect,
        MaxCount
    }
    public enum UIEvent{
        Click,
        Drag,
    }
    public enum MouseEvent{
        Press,
        PointerDown,
        PointerUp,
        Click,
    }
    public enum KeyEvent{
        U,
        UR,
        R,
        DR,
        D,
        DL,
        L,
        UL,
        Stop,
        Break,
    }
    public enum CameraMode{
        QuarterView,
        Orthographic,
    }
}
