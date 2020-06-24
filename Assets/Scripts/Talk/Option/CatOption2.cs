using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatOption2 : Option
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
        optionName = "特になし";
        return optionName;
    }
    public override void OptionExecution()
    {
        // Talk3を実行
        catTalkController_1.Talk3();
        // 選択後 panelを非表示
        optionPanelController.ShowPanel(false);
    }
}
