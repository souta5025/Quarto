using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //入ってきた時
    private void OnMouseEnter() {
        transform.localScale *= 1.2f;
    }
    //出ていったとき
    private void OnMouseExit() {
        transform.localScale /= 1.2f;
    }
}
