using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// FirstStageにおけるシーン管理を行うクラス
public class FirstStageSceneManager : SceneMethods
{
    // 次のシーン移行へのフラグ
    bool nextScene = false;
    // 経過時間
    float elapsedTime = 0;
    // 他のスクリプト
    [SerializeField]
    ResultShowController resultShowControllerScript = null;
    [SerializeField]
    FirstStagePlayerPanelController playerPanelController = null;

    void Reset()
    {
        resultShowControllerScript = GameObject.Find("LittleCat").GetComponentInChildren<ResultShowController>();
        playerPanelController = GameObject.Find("Player").GetComponentInChildren<FirstStagePlayerPanelController>();
    }
    void Start()
    {
        // 次のシーンインデックスを取得
        GetNextSceneIndex();
    }

    void Update()
    {
        // ゲーム結果の評価文字を表示したら次のシーンに移行開始
        if(resultShowControllerScript.EvaluationShow)
        {
            nextScene = true;
        }
        // シーン移行処理
        if(nextScene)
        {
            elapsedTime += Time.deltaTime;
            if(8.0f < elapsedTime)
            {
                // LoadNextScene();
                SceneManager.LoadScene(0);
            }
            else if(3.0f < elapsedTime)
            {
                // 5秒かけてFadeOut開始
                playerPanelController.FadeOutStart();
            }
        }
    }
}
