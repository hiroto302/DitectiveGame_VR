﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 特定の範囲において猫との会話を制御するクラス
public class CatTalkScopeArea : TalkScopeArea
{
    // 同階層に会話文を格納
    [SerializeField]

    CatMessages catMessages = null;
    [SerializeField]
    CatTalkController_1 catTalkController = null;
    // Catのスクリプト
    Cat cat;
    void Start()
    {
        // 各変数の取得
        if(catMessages == null)
        {
            catMessages = GetComponent<CatMessages>();
        }
        if(catTalkController == null)
        {
            catTalkController = transform.root.gameObject.GetComponent<CatTalkController_1>();
        }
        cat = transform.parent.gameObject.GetComponent<Cat>();
    }
    void OnTriggerStay(Collider other)
    {
        // 相手がPlayerかつNormal状態である時
        if(other.tag == "Player" && playerController.currentState != PlayerController.State.Talk)
        {
            // 会話開始
            if(Input.GetKeyDown(KeyCode.T) || OVRInput.GetDown(OVRInput.Button.One))
            {
                cat.SetState(Cat.State.Talk);
                // Playerを会話状態に変更
                playerController.SetState(PlayerController.State.Talk);
                // playerController.SetState(PlayerController.State.Normal);
                // アイコンを非表示
                talkIcon.SetActive(false);
                showIcon = false;
                // 一言目を表示していくメソッドを記述していく
                catTalkController.Talk1();
                // 次の選択肢を表示
            }
        }
    }
    void Update()
    {
        if(showIcon == true)
        {
            IconDirection();
        }
    }
}