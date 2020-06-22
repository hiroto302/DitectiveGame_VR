using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// OptionPanelの制御を行うクラス
// UIをまとめている親オブジェクトにアタッチ
public class OptionPanelController : MonoBehaviour
{
    [SerializeField]
    GameObject optionPanel = null;
    void Reset()
    {
        optionPanel = GameObject.Find("OptionPanel");
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
    }

}
