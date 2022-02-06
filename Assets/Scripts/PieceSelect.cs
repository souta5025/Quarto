using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSelect : MonoBehaviour
{
    GameManagerScript GMscript; //GameManagerScriptが入る変数

    // Start is called before the first frame update
    void Start()
    {
        GMscript = Common.GetGameManager();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //オブジェクト上で離した時
    private void OnMouseUpAsButton()
    {
        if(GMscript.selectFlag == false){                         //駒が選ばれているか確認
            GMscript.pieceSubject.OnNext(transform.parent.gameObject);
            Destroy(this);                                        //このScriptの無効化
        }
    }
}
