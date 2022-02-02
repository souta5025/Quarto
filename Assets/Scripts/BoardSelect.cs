using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSelect : MonoBehaviour
{
    GameManagerScript GMscript;
    private bool onPieceFlag = false;
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
        if(GMscript.selectFlag){
            if(onPieceFlag == false){
                var position = transform.parent.transform.position;
                GMscript.piece.transform.position = position;
                var layerNumber = this.gameObject.layer;
                Common.SetLayerRecursively(GMscript.piece, layerNumber);
                GMscript.selectFlag = false;
                onPieceFlag = true;
            }
        }
    }
}
