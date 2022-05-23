using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    private void Change2Main(){
        Managers.Scene.LoadScene(Define.Scene.Game);
    }
}
