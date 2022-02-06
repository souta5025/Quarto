using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;

public class GameManagerScript : MonoBehaviour
{
    private const int STAGE_SIZE = 4; //ステージの一辺のサイズ
    private GameObject piece;
    public bool selectFlag = false; //pieceを選んでいるかの判定
    private byte[,] stage = new byte[STAGE_SIZE,STAGE_SIZE]; //置かれた駒の記憶
    private int beforeQuartoNumber = 0; //見落としたQuartoの数の記録
    private bool missFlag = false; //Quartoの見落としを判定する
    private int CurrentPlayer =  2; //現在のプレーヤー
    private GameObject usepiece;
    //ターン表示テキスト
    public Text turn;

    public Subject<(Vector3 , int, int[])> boardSubject = new Subject<(Vector3, int, int[])>();
    public Subject<GameObject> pieceSubject = new Subject<GameObject>();
    public Subject<int> buttonSubject = new Subject<int>();

    // Start is called before the first frame update
    void Start()
    {
        //ターン表示テキストの初期値を代入
        ChangeSelectText(CurrentPlayer);

        usepiece = GameObject.FindWithTag("UsePiece");

        boardSubject.Subscribe((input) =>{
            var(position, layerNumber, numbers) = input;             //タプルを展開
            piece.transform.position = position;        //駒を選んだボードの位置に移動
            Common.SetLayerRecursively(piece, layerNumber);  //駒のレイヤーを元に戻す
            selectFlag = false;                           //駒の選択が切れたことを記録
            //配置場所の記憶
            var i = numbers[0];
            var j = numbers[1];
            stage[i,j] = Common.ConvertBinaryNumber(piece.name);
            ChangeSelectText(CurrentPlayer);   //手番のテキストの変更
            missFlag = false;                         //見落としを無かったことにする
        });

        pieceSubject.Subscribe((input) =>{
            piece = input;
            piece.transform.position = usepiece.transform.position; //UI上に移動
            var layerNumber = usepiece.layer;                     //UIlayerの取得
            Common.SetLayerRecursively(piece, layerNumber); //layerを変更してUIに表示
            selectFlag = true;                           //駒を選択したことを記録
            //前の手番で見逃しがあるかの判定
            if(beforeQuartoNumber != CheckQuarto()){
                missFlag = true;
            }else{
                missFlag = false;
            }
            beforeQuartoNumber = CheckQuarto();         //見逃しているQuartoの数の保存
            ChangePlayer();                                //プレーヤーチェンジ
            turn.text = CurrentPlayer.ToString() + "Pのターンです";   //ターンの表示を変更
        });

        buttonSubject.Subscribe((_)=>{
            if(beforeQuartoNumber == CheckQuarto()){
                if(missFlag == false){
                    Debug.Log("Not Quarto");
                    return;
                }
            }
            Debug.Log("Quarto!");
        });

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

    private void ChangePlayer(){
        if(CurrentPlayer == 1){
            CurrentPlayer = 2;
        }else{
            CurrentPlayer = 1;
        }
    }

    private void ChangeSelectText(int player){
        turn.text = player.ToString() + "Pは駒を選択してください";
    }

}
