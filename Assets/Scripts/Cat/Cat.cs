using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    // Catの状態を表す State型 の列挙体
    public enum State
    {
        Normal,
        Talk
    }
    // Catの現在の状態
    public State currentState;
    // Catの会話文を格納しているスクリプト
    // [SerializeField]
    // CatMessages catMessages = null;
    // 表示する会話文を制御するスクリプト
    // [SerializeField]
    // Message message = null;
    // 振り向く速度
    float rotationSpeed = 1.0f;
    [SerializeField]
    Transform playerTransfrom = null;
    void Reset()
    {
        playerTransfrom = GameObject.Find("Player").GetComponent<Transform>();
    }
    void Start()
    {
        // 状態の初期化
        currentState = State.Normal;
    }
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.T))
        // {
        //     currentState = State.Talk;
        // }
        Debug.Log(currentState + " currentState");
        // 話す状態になる時行う処理
        if(currentState == State.Talk)
        {
            // Playerの方向を向かせる
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(playerTransfrom.position.x, transform.position.y, playerTransfrom.position.z) - transform.position), rotationSpeed * Time.deltaTime);
        }
    }
    // 状態を変更するメソッド
    public void SetState(State state)
    {
        currentState = state;
    }
}
