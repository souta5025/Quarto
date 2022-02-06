using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class BoardSelect : MonoBehaviour
{
    GameManagerScript GMscript;

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
    //オブジェクト上で離した時
    private void OnMouseUpAsButton()
    {
        var position = transform.parent.transform.position;
        var layerNumber = this.gameObject.layer;
        var numbers = transform.parent.name.Split(',').Select(x => int.Parse(x)).ToArray();
        if(GMscript.selectFlag == true){
            GMscript.boardSubject.OnNext((position,layerNumber,numbers));
            Destroy(this);
        }
    }
}
