using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 猫のOption1
public class CatOption1 : Option
{
    [SerializeField]
    CatTalkController_1 catTalkController_1 = null;
    void Awake()
    {
        if(catTalkController_1 == null)
        {
            catTalkController_1 = transform.root.gameObject.GetComponent<CatTalkController_1>();
        }
    }
    public override string OptionName()
    {
        optionName = "説明をきく";
        return optionName;
    }
    public override void OptionExecution()
    {
        catTalkController_1.Talk2();
        // 選択後 panelを非表示
        optionPanelController.ShowPanel(false);
    }
}
