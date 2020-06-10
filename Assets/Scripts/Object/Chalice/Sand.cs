using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 砂 聖杯に追加できる重り
public class Sand : ScaleWeight
{
    // コンストラクタ 変数の初期化
    public Sand()
    {
        typeName = "Sand";
        weight = 1.0f;

    }
    public override float AddScaleWeight()
    {
        return Weight;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
