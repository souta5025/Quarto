using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Common
{
    public static GameManagerScript GetGameManager()
    {
        var gamemanager = GameObject.FindWithTag("GameManager"); //GameManagerをオブジェクトのtagから取得して変数に格納する
        var script = gamemanager.GetComponent<GameManagerScript>(); //GameManagerの中にあるGameManagerScriptを取得して変数に格納する
        return script;
    }
    /// <summary>
    /// 自分自身を含むすべての子オブジェクトのレイヤーを設定します
    /// https://baba-s.hatenablog.com/entry/2014/12/02/100720
    /// </summary>
    public static void SetLayerRecursively(
        this GameObject self,
        int layer
    )
    {
        self.layer = layer;

        foreach (Transform n in self.transform)
        {
            SetLayerRecursively(n.gameObject, layer);
        }
    }

    //public static string ConvertBinaryNumber(string pieceName){
        //switch{
          //  (when str.Contains())
        //}
    //}

}
