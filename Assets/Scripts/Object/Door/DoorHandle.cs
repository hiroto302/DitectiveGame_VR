﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// VR用 ドアの開閉機能実装
public class DoorHandle : MonoBehaviour
{
    // 対辺の長さ
    float dz = 0;
    // 隣辺の長さ
    float dx;
    // 半径の長さ
    float radius;
    // 角度
    float deg;
    // 移動後の角度
    float posteriorAngle;
    // ドアに触れている手の位置のオブジェクト 変数群
    [SerializeField]
    GameObject handPoint = null;
    Transform handPointTransform;
    HandPoint handPointScript;
    // 回転の中心軸
    [SerializeField]
    Transform centerPoint = null;
    // 回転させるドアのオブジェクト
    [SerializeField]
    Transform door = null;

    void Reset()
    {
        // 一度親に移動してから取得 (複数のドアを作成した時、混合することを防ぐ）
        handPoint = transform.parent.Find("HandPoint").gameObject;
        centerPoint = transform.parent.Find("CenterPoint");
        door = transform.root;
    }

    void Start()
    {
        // HandPoint 変数の初期化
        handPointTransform = handPoint.transform;
        handPointScript = handPoint.GetComponent<HandPoint>();
        // 半径の取得 初期化
        Vector3 dir = centerPoint.localPosition - handPointScript.InitialPosition;
        radius = dir.magnitude;
        // 隣辺の初期の長さ（最初半径と同じ長さ）
        dx = radius;
    }

    // Handの座標取得・移動条件
    // Colliderの衝突判定したが、HandPoint と Handの距離から算出したりするなど色々開閉の条件なども変えるのもいいかも
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Hand")
        {
            // ワールド座標のHandの位置取得・HandPointの移動
            handPointTransform.position = other.gameObject.transform.position;
        }
    }

// 移動した後元の位置に戻ってカクカク動いてるように見える
    void Update()
    {
        // 対辺の取得 handPointのローカル座標から取得
        dz = handPointTransform.localPosition.z - handPointScript.InitialPosition.z;
        // 隣辺を求める
        dx = Mathf.Sqrt(radius * radius - dz * dz);
        // オイラー角取得
        float rad = Mathf.Atan2(dz, dx);
        // オイラー角をラジアンに変換
        deg = rad * Mathf.Rad2Deg;
        // 手の位置により変化したdzにより、degを算出し、それにより生まれた角度分移動
        door.RotateAround( centerPoint.position, Vector3.up, deg);
        // 移動させた後、HandPointをリセットする
        handPointTransform.localPosition = handPointScript.InitialPosition;
    }
}
