using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CatTalkController_1 : CatTalkController
{
    public bool talk1 = false;
    // public bool talk2 = 


    public override void SetVariables()
    {
        // talk初期化 falseを代入
        talk = new bool[3];
        for(int i = 0; i < talk.Length; i++)
        {
            talk[i] = false;
        }
        // currentMessage初期化 falseを代入
        currentMessage =  new bool[2];
        for(int i = 0; i < currentMessage.Length; i++)
        {
            currentMessage[i] = false;
        }
        // pageCount初期化
        pageCount = new int[1];
    }
    void Start()
    {
        // 最初に表示するもののみをtrue
        // currentMessage[0] = true;
    }

    // 各talkをスタートするメソッド
    public void Talk1()
    {
        talk[0] = true;
        currentMessage[0] = true;
    }
    public void Talk2()
    {
        talk[1] = true;
        currentMessage[0] = true;
    }

    public override void Update()
    {
        // Talk1
        if(talk[0])
        {
            // 一つ目のmessage表示
            if(currentMessage[0])
            {
                // messag1 を表示
                StartTalk(catMessages.MessageTest());
                // ボタンを押す必要回数を取得
                pageCount[0] = PageCount(catMessages.MessageTest());
                currentMessage[0] = false;
            }
            // message 1 表示中のボタンが押される度に引く
            if(pageCount[0] > 0)
            {
                if(Input.GetMouseButtonDown(0) || OVRInput.GetDown(OVRInput.Button.One))
                {
                    pageCount[0] --;
                }
                // message1 が 表示中は、2つ目のmessageを非表示
                currentMessage[1] = false;
            }
            else if(pageCount[0] == 0)
            {
                // message1 が終了後、2つめを表示
                currentMessage[1] = true;
            }
            // 2つ目にoptionを表示
            if(currentMessage[1])
            {
                // StartTalk("aaaaaa");
                optionPanelController.ShowPanel(true);
                currentMessage[1] = false;
                // 会話終フラグをfalseに初期化すること
                talk[0] = false;
            }
        }

        // Talk2
        if(talk[1])
        {
            if(currentMessage[0])
            {
                StartTalk(catMessages.Message2());
                pageCount[0] = PageCount(catMessages.Message2());
                currentMessage[0] = false;
            }
            if(pageCount[0] > 0)
            {
                if(Input.GetMouseButtonDown(0) || OVRInput.GetDown(OVRInput.Button.One))
                {
                    pageCount[0] --;
                }
            }
            else if(pageCount[0] == 0)
            {
                playercontroller.SetState(PlayerController.State.Normal);
                talk[1] = false;
            }
        }
    }
}
