using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public const int STAGE_SIZE = 4; //ステージの一辺のサイズ
    public GameObject piece;
    public bool selectFlag = false; //pieceを選んでいるかの判定
    public byte[,] stage = new byte[STAGE_SIZE,STAGE_SIZE]; //置かれた駒の記憶
    public int beforeQuartoNumber = 0; //見落としたQuartoの数の記録
    public bool missFlag = false; //Quartoの見落としを判定する
    public int CurrentPlayer =  2; //現在のプレーヤー
    //ターン表示テキスト
    public Text turn;

    // Start is called before the first frame update
    void Start()
    {
        //ターン表示テキストの初期値を代入
        Common.ChangeSelectText(CurrentPlayer);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int CheckQuarto(){
        int cnt = 0;
        for(var i = 0; i < STAGE_SIZE; i++){ //横の判定
            var tmp = stage[i,0];
            for(var j = 0; j < STAGE_SIZE; j++){
                tmp &= stage[i,j];
            }
            if(tmp > 0){
                cnt++;
            }
        }
        for(var i = 0; i < STAGE_SIZE; i++){ //縦の判定
            var tmp = stage[0,i];
            for(var j = 0; j < STAGE_SIZE; j++){
                tmp &= stage[j,i];
            }
            if(tmp > 0){
                cnt++;
            }
        }
        {                                    //斜めの判定
            var tmp = stage[0,0];
            for(var i = 0; i < STAGE_SIZE; i++){
                tmp &= stage[i,i];
            }
            if(tmp > 0){
                cnt++;
            }
        }
        {
            var tmp = stage[3,0];
            for(var i = 0; i < STAGE_SIZE; i++){
                tmp &= stage[STAGE_SIZE-(i+1),i];
            }
            if(tmp > 0){
                cnt++;
            }
        }
        return cnt;
    }

}
