using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class BoardSelect : MonoBehaviour
{
    GameManagerScript GMscript;
    //private bool onPieceFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        GMscript = Common.GetGameManager();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //入ってきた時
    private void OnMouseEnter()
    {
        transform.localScale *= 1.2f;
    }
    //出ていったとき
    private void OnMouseExit()
    {
        transform.localScale /= 1.2f;
    }
    //オブジェクト上で話した時
    private void OnMouseUpAsButton()
    {
        if(GMscript.selectFlag == true){
            var position = transform.parent.transform.position;
            GMscript.piece.transform.position = position;
            var layerNumber = this.gameObject.layer;
            Common.SetLayerRecursively(GMscript.piece, layerNumber);
            GMscript.selectFlag = false;
            //配置場所の記憶
            var numbers = transform.parent.name.Split(',').Select(x => int.Parse(x)).ToArray();
            var i = numbers[0];
            var j = numbers[1];
            GMscript.stage[i,j] = Common.ConvertBinaryNumber(GMscript.piece.name);
            Debug.Log(GMscript.CheckQuart());
            // for(i=0; i<4; i++){
            //     for(j=0; j<4; j++){
            //         Debug.Log(Convert.ToString(GMscript.stage[i,j], 2));
            //     }
            // }
            Destroy(this);
        }
    }
}
