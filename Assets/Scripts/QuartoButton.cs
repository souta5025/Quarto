using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuartoButton : MonoBehaviour
{
    GameManagerScript GMscript;
    // Start is called before the first frame update
    void Start()
    {
        GMscript = Common.GetGameManager();
    }
    // ボタンが押された場合,呼び出される関数
    public void OnClick()
    {
        if(GMscript.beforeQuartoNumber == GMscript.CheckQuarto()){
            if(GMscript.missFlag == false){
                Debug.Log("Not Quarto");
                return;
            }
        }
        Debug.Log("Quarto!");
    }
}
