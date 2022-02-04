using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    private const int STAGE_SIZE = 4; //ステージの一辺のサイズ
    public GameObject piece;
    public bool selectFlag = false;
    public byte[,] stage = new byte[STAGE_SIZE,STAGE_SIZE]; //置かれた駒の記憶

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
