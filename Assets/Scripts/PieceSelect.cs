using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSelect : MonoBehaviour
{
    GameObject gamemanager; //GameManagerが入る変数

    GameManagerScript script; //GameManagerScriptが入る変数

    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.FindWithTag("GameManager"); //GameManagerをオブジェクトのtagから取得して変数に格納する
        script = gamemanager.GetComponent<GameManagerScript>(); //GameManagerの中にあるGameManagerScriptを取得して変数に格納する
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //オブジェクト上で離した時
    private void OnMouseUpAsButton() {
        script.piece = transform.parent.gameObject;
    }
}
