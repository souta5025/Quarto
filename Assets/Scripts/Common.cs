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

    public static byte ConvertBinaryNumber(string pieceName){
        byte result = 0;
        if(pieceName.Contains("Light")) result |= 0b00000001;
        if(pieceName.Contains("Dark"))  result |= 0b00000010;
        if(pieceName.Contains("Round")) result |= 0b00000100;
        if(pieceName.Contains("Square"))result |= 0b00001000;
        if(pieceName.Contains("Tall"))  result |= 0b00010000;
        if(pieceName.Contains("Short")) result |= 0b00100000;
        if(pieceName.Contains("Solid")) result |= 0b01000000;
        if(pieceName.Contains("Hollow"))result |= 0b10000000;
        return result;
    }


}
