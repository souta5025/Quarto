using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public const int STAGE_SIZE = 4; //ステージの一辺のサイズ
    public GameObject piece;
    public bool selectFlag = false;
    public byte[,] stage = new byte[STAGE_SIZE,STAGE_SIZE]; //置かれた駒の記憶
    public int beforeQuartoNumber = 0;
    public bool missFlag = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int CheckQuarto(){
        int cnt = 0;
        for(var i = 0; i < STAGE_SIZE; i++){
            var tmp = stage[i,0];
            for(var j = 0; j < STAGE_SIZE; j++){
                tmp &= stage[i,j];
            }
            if(tmp > 0){
                cnt++;
            }
        }
        for(var i = 0; i < STAGE_SIZE; i++){
            var tmp = stage[0,i];
            for(var j = 0; j < STAGE_SIZE; j++){
                tmp &= stage[j,i];
            }
            if(tmp > 0){
                cnt++;
            }
        }
        {
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
