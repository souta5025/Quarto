using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // インスペクタビューから設定するシーン名
    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// インスペクタビューから設定したシーンを読み込む
    /// <summary>
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    // GameControllerインスタンスの実体
    private static SceneChange instance = null;

    // GameControllerインスタンスのプロパティーは、実体が存在しないとき（＝初回参照時）実体を探して登録する
    public static SceneChange Instance => instance
        ?? ( instance = GameObject.Find( "SceneManager" ).GetComponent<SceneChange>());

    private void Awake ()
    {
        // もしインスタンスが複数存在するなら、自らを破棄する
        if ( this != Instance )
        {
            Destroy ( this.gameObject );
            return;
        }

        // 唯一のインスタンスなら、シーン遷移しても残す
        DontDestroyOnLoad ( this.gameObject );
    }

    private void OnDestroy ()
    {
        // 破棄時に、登録した実体の解除を行う
        if ( this == Instance ) instance = null;
    }
}
