using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 水 聖杯に追加できる重り
public class Water : ScaleWeight
{
    // コンストラクタ
    public Water()
    {
        typeName = "Water";
        weight = 0.5f;
    }

    public override float AddScaleWeight()
    {
        return weight;
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
