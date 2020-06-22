using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatOption2 : Option
{
    public override string OptionName()
    {
        optionName = "特になし";
        return optionName;
    }
    public override void OptionExecution()
    {
        Debug.Log("選択肢2に触れたよ");
    }
}
