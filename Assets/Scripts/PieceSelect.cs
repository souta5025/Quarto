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
        if(GMscript.selectFlag == false){                         //駒が選ばれているか確認
            GMscript.piece = transform.parent.gameObject;         //選んだ駒の取得
            GMscript.piece.transform.position = usepiece.transform.position; //UI上に移動
            var layerNumber = usepiece.layer;                     //UIlayerの取得
            this.gameObject.layer = layerNumber;                  //layerを変更してUIに表示
            GMscript.selectFlag = true;                           //駒を選択したことを記録
            if(GMscript.beforeQuartoNumber != GMscript.CheckQuarto()){ //前の手番で見逃しがあるかの判定
                GMscript.missFlag = true;
            }else{
                GMscript.missFlag = false;
            }
            GMscript.beforeQuartoNumber = GMscript.CheckQuarto(); //見逃しているQuartoの数の保存
            Common.ChangePlayer();                                //プレーヤーチェンジ
            GMscript.turn.text = GMscript.CurrentPlayer.ToString() + "Pのターンです";   //ターンの表示を変更
            Destroy(this);                                        //このScriptの無効化
        }
    }
}
