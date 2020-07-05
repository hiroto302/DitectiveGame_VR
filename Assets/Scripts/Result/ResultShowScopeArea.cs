﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultShowScopeArea : MonoBehaviour
{
    // 各スクリプト
    [SerializeField]
    PlayerController playerController = null;
    [SerializeField]
    ResultShowController resultShowController = null;


    void Reset()
    {
        // 各スクリプトの取得
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        resultShowController = GameObject.Find("LittleCat").GetComponent<ResultShowController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            // Playerの状態変更
            playerController.SetState(PlayerController.State.Talk);
            // ゲーム結果の表示
            resultShowController.ShowResult();
        }
    }
}
