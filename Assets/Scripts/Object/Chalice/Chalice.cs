using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 聖杯クラス

public class Chalice : MonoBehaviour
{
    // 聖杯の初期の重さ
    public float weight = 1.0f;
    // 聖杯の状態 空・満たされている状態の2つ
    string[] state = {"empty", "fill"};
    // 現在の状態
    public string currentState;
    // 状態を変更するメソッド
    public void ChangeState(int num)
    {
        currentState = state[num];
    }
    // 現在加えられている重り
    public string containedScale = null;
    // 加えることができる重りである 砂・水 のオブジェクト
    [SerializeField]
    GameObject sand;
    GameObject sandObject;
    [SerializeField]
    GameObject water;
    GameObject waterObject;
    // 加える重りの位置
    [SerializeField]
    Transform scalePosition;
    // 聖杯内から溢れたことを判定するために扱うオブジェクト
    [SerializeField]
    GameObject DropObject;
    // Dropオブジェクトを生成する位置
    [SerializeField]
    Transform dropObjectPoint;
    // DropObjectの変数
    GameObject dropObject;
    DropObject dropObjectScript;
    // SE
    [SerializeField]
    SE se = null;

    void Reset()
    {
        // DropGameObjectPointの取得
        dropObjectPoint = transform.GetChild(0);
        // SEの取得
        se = GetComponent<SE>();
    }
    // 重りに触れたら実行するメソッド
    public void AddWeight(float scale)
    {
        weight += scale;
    }
    // 聖杯の中に砂を生成するメソッド
    public void InstantiateSand()
    {
        sandObject = Instantiate(sand, scalePosition.position, Quaternion.identity) as GameObject;
        sandObject.transform.parent = gameObject.transform;
    }
    // 聖杯の中に水を生成するメソッド
    public void InstantiateWater()
    {
        sandObject = Instantiate(water, scalePosition.position, Quaternion.identity) as GameObject;
        sandObject.transform.parent = gameObject.transform;
    }
    // DropObjectを生成するメソッド
    void InstantiateDropObject()
    {
        dropObject = Instantiate(DropObject, dropObjectPoint.position, Quaternion.identity) as GameObject;
        dropObject.transform.parent = gameObject.transform;
    }
    // 逆さまにしたら追加した重りを削除するメソッド
    void DropScaleWeight()
    {
        // 空の状態・重さに変更
        ChangeState(0);
        weight = 1.0f;
        // 重りの削除
        foreach(Transform children in gameObject.transform)
        {
            if(children.gameObject.tag == "ScaleWeight")
            {
                Destroy(children.gameObject);
            }
        }
        // dropObjectの位置をリセット
        dropObject.transform.position = dropObjectPoint.position;
        if(containedScale == "Water")
        {
            // 水が落ちる音
            se.PlaySE(0);
        }
        else if(containedScale == "Sand")
        {
            // 砂が落ちる音
            se.PlaySE(1);
        }
    }
    void Start()
    {
        //初期の状態
        currentState = state[0];
        // DropObjectの生成・変数の初期化
        InstantiateDropObject();
        dropObjectScript = dropObject.GetComponent<DropObject>();
    }

    void Update()
    {
        // 容器内が満たされている時,DropGameObjectが落ちたら実行する処理
        if(dropObjectScript.velocityY > 1.0f)
        {
            DropScaleWeight();
        }
    }
}
