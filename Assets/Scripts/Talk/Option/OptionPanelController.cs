using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// OptionPanelの制御を行うクラス
// UIをまとめている親オブジェクトにアタッチ
public class OptionPanelController : MonoBehaviour
{
    [SerializeField]
    GameObject optionPanel = null;
    [SerializeField]
    PlayerController player = null;

    void Reset()
    {
        optionPanel = GameObject.Find("OptionPanel");
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void Start()
    {
        // 初期は非表示
        ShowPanel(false);
    }
    // OptionPanelの表示・非表示を制御するメソッド
    public void ShowPanel(bool show)
    {
        optionPanel.SetActive(show);
        // 表示している時.Player Talk状態する記述を書くとPanelとPalyerの距離によっては選択しづらくなる恐れがある
        if(show)
        {
            player.SetState(PlayerController.State.Talk);
        }
        if(!show)
        {
            player.SetState(PlayerController.State.Normal);
        }
    }

}
