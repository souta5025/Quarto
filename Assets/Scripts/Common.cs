using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Common
{
    public static GameManagerScript GetGameManager(){
        var gamemanager = GameObject.FindWithTag("GameManager"); //GameManagerをオブジェクトのtagから取得して変数に格納する
        var script = gamemanager.GetComponent<GameManagerScript>(); //GameManagerの中にあるGameManagerScriptを取得して変数に格納する
        return script;
    }
    
}
