using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ScaleDoorの機能実装
// 計りの重さが3以上の時のみ閉めることが可能
// 取手に触れたら、一定数閉まっていく
// 完全に閉めたら扉を固定
public class ScaleDoorController : MonoBehaviour
{
    // 扉(蓋)の状態
    // 空いている状態、閉めることが可能な状態,固定されている状態
    public enum State
    {
        Open,
        Close,
        Fixed,
    }
    // 扉の現在の状態
    public State currentState;

    [SerializeField]
    ChaliceScale chaliceScale = null;
    // 回転させる扉
    [SerializeField]
    Transform door = null;
    // 回転の中心軸
    [SerializeField]
    Transform centerPoint = null;
    // 扉が閉じる時の角速度
    float angularVelocity = -45.0f;
    // 扉が閉めきれられる角度;
    float closedValue = 155.0f;

    void Reset()
    {
        chaliceScale = transform.root.gameObject.GetComponentInChildren<ChaliceScale>();
        door = transform.parent.gameObject.transform.parent;
        centerPoint = transform.parent.Find("CenterPoint");
    }

    void Start()
    {
        // ドアの状態の初期化
        SetState(State.Open);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("ドアに触れたうよ");
        if(other.gameObject.tag == "Hand" && currentState != State.Fixed)
        {
            SetState(State.Close);
            Debug.Log("close状態にするよ");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Hand" && currentState != State.Fixed)
        {
            SetState(State.Open);
        }
    }

    void Update()
    {
        // ドアが固定状態かつ、計りの重さが3以上の時閉めることが可能
        if(currentState == State.Close && chaliceScale.totalWeight >= 3.0f )
        {
            // ドアを閉める
            door.RotateAround( centerPoint.position, door.forward.normalized, angularVelocity * Time.deltaTime);
            // closedValue 以上扉を閉めた時、扉を固定(閉め切った状態)
            closedValue += angularVelocity * Time.deltaTime;
            if(closedValue < 0)
            {
                SetState(State.Fixed);
            }
        }
    }

    // 状態を変更するメソッド
    public void SetState(State state)
    {
        currentState = state;
        // 扉が固定状態の時奥の扉を少し開く
    }
}
