using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSelect : MonoBehaviour
{
    GameManagerScript script; //GameManagerScriptが入る変数
    GameObject usepiece;

    // Start is called before the first frame update
    void Start()
    {
        script = Common.GetGameManager();
        usepiece = GameObject.FindWithTag("UsePiece");
    }

    // Update is called once per frame
    void Update()
    {

    }
    //オブジェクト上で離した時
    private void OnMouseUpAsButton()
    {
        script.piece = transform.parent.gameObject;
        script.piece.transform.position = usepiece.transform.position;
        var layerNumber = usepiece.layer;
        this.gameObject.layer = layerNumber;
    }
}
