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
    // 聖杯に触れたら、聖杯に水の重りを追加
    public override void OnTriggerEnter(Collider other)
    {
        if( other.gameObject.tag == "Chalice")
        {
            // 聖杯の状態が空の時、下記を実行
            if(other.gameObject.GetComponent<Chalice>().currentState == "empty")
            {
                other.gameObject.GetComponent<Chalice>().AddWeight(weight);
                other.gameObject.GetComponent<Chalice>().ChangeState(1);
                other.gameObject.GetComponent<Chalice>().InstantiateWater();
            }
        }
    }
}
