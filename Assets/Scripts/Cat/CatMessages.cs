using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Catが話す内容を記述するスクリプト
public class CatMessages : MonoBehaviour
{
    [SerializeField]
    Message message = null;
    // 分割文字
    string[] splitKeyWord = new string[1];
    // ページ数(分割回数)
    
    // List<string> catMessages = new List<string>();
    void Reset()
    {
        // Message スクリプトの取得
        message = transform.root.gameObject.GetComponentInChildren<Message>();
    }
    void Start()
    {
        // messageで使用している分割文字を格納
        splitKeyWord[0] = message.splitString;
    }
    // 会話内容をセットして開始するメソッド
    void StartTalk(string catMessage)
    {
        message.SetMessagePanel(catMessage);
        message.MessageStart();
    }
    // 1つのメッセージあたりの、ページー数(分割した回数・セパレーターの数)を取得するメソッド
    public int PageCount(string splitTarget)
    {
        string[] page = splitTarget.Split(splitKeyWord, StringSplitOptions.None);
        return page.Length;
    }

    // 会話文
    public string FirstContactMessage()
    {
        string catMessage = "ようこそにゃ！\n我が国の探偵に立候補しくれてありがとなのにゃ"
                            +"正式に任命して頂くために、試練に挑む必要があるにゃ！<>"
                            +"さっそく今回は、試練「聖杯の部屋」に挑んでもらうのにゃ！<>"
                            +"試練内容の説明をするから、よく聞くことだにゃ！<>"
                            +"部屋には、「聖杯」が３つあるにゃ\nそして、その重さの合計を測る「はかり」があるにゃ<>"
                            +"このはかりは、「ある重さ以上」の時、「ふた」を閉めることができるにゃ<>"
                            +"ある重さは、聖杯３つ分の重さと同じだにゃ\n聖杯は、砂と水を入れることで重さを変えることができるにゃ<>"
                            +"聖杯自身の重さを、「１」とした時\nそれに加えることがきる砂の重さも、「１」\n水が、だいたい「0.5」にゃ\n砂と水はどちらか一つし入れることができないにゃ<>"
                            +"ふたを閉めるとことで、部屋からでるための扉が開くにゃ\n一度扉を開けば閉じなくなり、閉じたはかりのふたは開くことができなくなるにゃ<>"
                            +"閉じてしまったら、フタの内側にある聖杯は持ち出すことが出来なくなるにゃ<>"
                            +"多くの聖杯を持ち出せるよう頑張るにゃ！";
        return catMessage;
    }
    // 一言目
    public string Message1()
    {
        string catMessage = "何か用かにゃ ???";
        return catMessage;
    }
    // Optionの「説明をきく」を選択時に発する文
    public string Message2()
    {
        string catMessage = "もう一度言うから良く聞くことだにゃ<>"
                            +"ここに3つの聖杯が用意されてるにゃ\n"
                            +"その聖杯の合計の重さを測る台に、\n合計の重さが「３以上」になるように置くにゃ<>"
                            +"聖杯自身の重さは、「１」\nそれに加えることがきる砂の重さも、「１」\n水が、「0.5」にゃ<>"
                            +"合計の重さが「3以上」の時、\n台のフタに触れてで閉じることが可能になるにゃ"
                            +"閉じてしまったら、フタの内側にある聖杯は持ち出すことが出来なくなるにゃ"
                            +"多くの聖杯を持ち出せるよう頑張るにゃ！";
        return catMessage;
    }
    // Optionの「特になし」を選択時に発する文
    public string Message3()
    {
        string catMessage = "探偵への道のりは険しそうだにゃ";
        return catMessage;
    }
    // Debug用
    public string MessageTest()
    {
        string catMessage = "１ページ目１段落目\n１ページ目２段落目<>"
                            + "2ページ目<>"
                            + "3ページ目";
        return catMessage;
    }

    // セットした内容を話す

    // // cat の message を追加するメソッド
    // void AddMessage()
    // {
    //     catMessages.Add(CatMessage1());
    // }
}
