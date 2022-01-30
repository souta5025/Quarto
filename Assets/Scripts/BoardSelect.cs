using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSelect : MonoBehaviour
{
    GameManagerScript script;
    // Start is called before the first frame update
    void Start()
    {
        script = Common.GetGameManager();
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
        var position = this.transform.position;
        script.piece.transform.position = position;
        var layerNumber = this.gameObject.layer;
        Common.SetLayerRecursively(script.piece, layerNumber);
    }
}
