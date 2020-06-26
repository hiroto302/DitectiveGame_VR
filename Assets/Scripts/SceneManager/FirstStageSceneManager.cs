using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 現在のシーンにおいて、シーンに関するの管理を行うクラス
public class FirstStageSceneManager : MonoBehaviour
{
    [SerializeField]
    PlayerController playerController = null;
    [SerializeField]
    CatTalkController_1Stage catTalkController = null;
    void Reset()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        catTalkController = GameObject.Find("Cat").GetComponent<CatTalkController_1Stage>();
    }
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        // 1_stageでは最初猫の説明から始まるので、状態をTalkに変更
        if(scene.name == "1_stage")
        {
            playerController.SetState(PlayerController.State.Talk);
            catTalkController.FirstContactTalk();
        }
    }

}
