using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 現在のシーンにおいて、シーンに関するの管理を行うクラス
public class FirstStageSceneManager : MonoBehaviour
{
    [SerializeField]
    PlayerController playerController = null;
    void Reset()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log(scene + "+ scene");
        Debug.Log(scene.name + "+ sceneName");
        // 1_stageでは最初猫の説明から始まるので、状態をTalkに変更
        if(scene.name == "1_stage")
        {
            // playerController.SetState(PlayerController.State.Talk);
        }
    }

    void Update()
    {
        
    }
}
