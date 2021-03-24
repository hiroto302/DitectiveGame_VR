using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// 測り 聖杯の合計の重さを測定する
public class ChaliceScale : MonoBehaviour
{
    // 重さの合計値
    public float totalWeight = 0;
    // 重さの合計値により決定する、移動場所を格納している親オブジェクト
    [SerializeField]
    Transform scalePointsParent = null;
    // 移動する位置
    Transform[] scalePoints;
    // 移動させる基準点
    [SerializeField]
    Transform standardPoint = null;
    // 現在の位置
    Vector3 currentPosition;
    // 次移動する位置
    Vector3 nextPosition;
    // 現在位置から次の移動位置までの距離 (0.2 間隔の距離)
    float distance;
    // 移動までにかかる時間 (移動にかかるフレームの回数)
    float second;
    // 移動スピード (0.2 を割り切ることができる値)
    float speed = 0.002f;
    // 符号 正(up) or 負(down)
    float sign;
    // SE
    [SerializeField]
    SE se = null;
    bool playSE = true;

    void Start()
    {
        // 移動位置の設定
        scalePoints = new Transform[scalePointsParent.transform.childCount];
        for(int i = 0; i < scalePointsParent.transform.childCount; i++)
        {
            scalePoints[i] = scalePointsParent.transform.GetChild(i);
        }
        // 現在位置の初期化
        currentPosition = scalePoints[(int)totalWeight].position;
        standardPoint.position = scalePoints[Mathf.CeilToInt(totalWeight)].position;
    }

    // 測り置かれている重りの取得
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Chalice")
        {
            totalWeight += other.gameObject.GetComponent<Chalice>().weight;
            sign = -1.0f;
            // SE 音 柱の移動音
            if(totalWeight >= 0 && totalWeight <= 3.0f)
            {
                se.PlaySE(0);
            }
            if(totalWeight >= 3.0f)
            {
                // 完了音のフラグ
                playSE = true;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Chalice")
        {
            totalWeight -= other.gameObject.GetComponent<Chalice>().weight;
            sign = 1.0f;
            // SE 音
            if(totalWeight >= 0 && totalWeight <= 3.0f)
            {
                se.PlaySE(0);
            }
        }
    }

    void Update()
    {
        // 次に移動する場所
        if(totalWeight <= 3.0f )
        {
            nextPosition = scalePoints[Mathf.CeilToInt(totalWeight)].position;
        }

        if(currentPosition != nextPosition)
        {
            // 距離の取得 (0.2の倍数で取得するために下記の処理を行う)
            distance = Mathf.Round((nextPosition - currentPosition).magnitude * 10.0f) * 0.1f;
            // 移動にかかる時間の取得
            second = distance / speed ;
            currentPosition = nextPosition;
        }
        // 測りの移動
        if(second > 0)
        {
            standardPoint.Translate(new Vector3(0, sign * speed, 0));
            second -= 1.0f;
        }

        // SE 重さが3以上の時の位置に移動が完了したことを知らせる音 (小数点以下の僅かな差が生まれるので下記の処理を行う)
        if( Mathf.Abs(scalePoints[3].position.y - standardPoint.position.y) < 0.01f )
        {
            if(playSE)
            {
                se.PlaySE(1);
                playSE = false;
            }
        }
    }
}
