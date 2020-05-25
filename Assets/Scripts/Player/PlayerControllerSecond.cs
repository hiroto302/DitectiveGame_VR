using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Update と FixedUpdate で記述を分けてPlayerControllerの機能を記述


public class PlayerControllerSecond : MonoBehaviour
{
    Rigidbody rb;
    private float angleSpeed = 30.0f;
    private float moveSpeed = 1.0f;
    [SerializeField] GameObject moveTarget;
    // オキュラスクエストの入力値変数

    float x, y;
    Vector3 rightStick;
    Vector3 move = Vector3.zero;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        // 右スティック入力 方向
        rightStick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        // 左スティック操作 角度
        var leftStick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Vector3 angleVector = new Vector3( 0, leftStick.x, 0);
        transform.Rotate(0, angleVector.y * angleSpeed * Time.deltaTime, 0);
    }

    void FixedUpdate()
    {
            x = rightStick.x;
            y = rightStick.y;
            // x と z 軸のみの変更
            // Vector3 direction = new Vector3( x , 0, y);
            // Vector3 direction = new Vector3( x , 0, y);
            // move = (direction.z * moveTarget.transform.forward.normalized + direction.x * moveTarget.transform.right.normalized) * moveSpeed * 0.001f;
            // move =  rb.velocity;
            var move = (y * moveTarget.transform.forward.normalized + x * moveTarget.transform.right.normalized) * 0.00001f;
            rb.velocity = new Vector3( move.x, rb.velocity.y, move.z);
    }
}
