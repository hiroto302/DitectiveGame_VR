using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 猫のOption1
public class CatOption1 : Option
{
    [SerializeField]
    CatTalkController_1Stage catTalkController = null;
    void Awake()
    {
        if(catTalkController == null)
        {
            catTalkController = transform.root.gameObject.GetComponent<CatTalkController_1Stage>();
        }
    }
    public override string OptionName()
    {
        optionName = "説明をきく";
        return optionName;
    }
    public override void OptionExecution()
    {
        catTalkController.Talk2();
        // 選択後 panelを非表示
        optionPanelController.ShowPanel(false);
    }
}
