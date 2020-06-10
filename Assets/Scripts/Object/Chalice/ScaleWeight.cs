using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 聖杯に追加する重りの抽象クラス
public abstract class ScaleWeight : MonoBehaviour
{
    // 重りの種類名
    protected string typeName;
    // 各種の重さ
    protected float weight;
    public string TypeName
    {
        get{ return typeName;}
    }
    public float Weight
    {
        get{ return weight;}
    }

    // 聖杯に重りを追加した時のメソッド

    public abstract float AddScaleWeight();

    // 聖杯に触れたら、聖杯に重りを追加
    void OnTriggerEnter(Collider other)
    {
        if( other.gameObject.tag == "Chalice")
        {
            Debug.Log("触れたよ");
            // 聖杯の状態が空の時、下記を実行
            if(other.gameObject.GetComponent<Chalice>().currentState == "empty")
            {
                other.gameObject.GetComponent<Chalice>().AddWeight(weight);
                other.gameObject.GetComponent<Chalice>().ChangeState(1);
            }
        }
    }
}
