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
}
