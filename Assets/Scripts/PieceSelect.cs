using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSelect : MonoBehaviour
{
    GameManagerScript GMscript; //GameManagerScriptが入る変数
    GameObject usepiece;
    //private bool usedFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        GMscript = Common.GetGameManager();
        usepiece = GameObject.FindWithTag("UsePiece");
    }

    // Update is called once per frame
    void Update()
    {

    }
    //オブジェクト上で離した時
    private void OnMouseUpAsButton()
    {
        if(GMscript.selectFlag == false){
            GMscript.piece = transform.parent.gameObject;
            GMscript.piece.transform.position = usepiece.transform.position;
            var layerNumber = usepiece.layer;
            this.gameObject.layer = layerNumber;
            GMscript.selectFlag = true;
            if(GMscript.beforeQuartoNumber != GMscript.CheckQuarto()){ //見逃しがあるかの判定
                GMscript.missFlag = true;
            }else{
                GMscript.missFlag = false;
            }
            GMscript.beforeQuartoNumber = GMscript.CheckQuarto(); //見逃しているQuartoの数の保存
            Destroy(this);
        }
    }
}
