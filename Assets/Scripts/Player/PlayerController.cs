using UnityEngine;

// オキュラスクエスト用 transform.TranslateによるPlayerの移動方法

// Translate の 移動法でカクツク原因は, time.deltaTimeを利用すると起こるのが一つの原因であった
// 現在の解決方法
// 1. FPSが約40であるため、その乗数をかける
//    ＝＞ 対象機種がオキュラスクエストであってもデバイスによる性能差が出る場合が問題である
public class PlayerController : MonoBehaviour
{
    private float angleSpeed = 45.0f;
    private float moveSpeed = 2.0f;
    private float speedMultiplier = 0.02f;
    [SerializeField]
    Transform moveTarget = null;

    // オキュラスクエストの入力値

    float x, y;
    Vector3 move = Vector3.zero;

    void Reset()
    {
        if(!moveTarget)
        {
            moveTarget = GetComponentInChildren<OVRCameraRig>().transform.Find("TrackingSpace/CenterEyeAnchor");
        }
    }
    void Update()
    {
        Debug.Log(Time.deltaTime.GetType());
        // 左スティック入力 角度・旋回
        Vector2 leftStick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        transform.Rotate(new Vector3(0, leftStick.x, 0) * angleSpeed * speedMultiplier);
        // transform.Rotate(new Vector3(0, leftStick.x, 0) * angleSpeed * Time.deltaTime);

        // 右スティック入力 方向・移動
        Vector2 rightStick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        // x, y -1.0 ~ 1.0 の値
        x = rightStick.x;
        y = rightStick.y;
        move = (x * moveTarget.right.normalized + y * moveTarget.forward.normalized ) * moveSpeed * speedMultiplier;
        // move = (x * moveTarget.right.normalized + y * moveTarget.forward.normalized ) * moveSpeed * Time.deltaTime;
        transform.Translate(move, Space.World);

        // HMD内にデバッグ表示方法 表示するものは一つにすること
        // OVRDebugConsole.Log(move.ToString("f5"));
        // OVRDebugConsole.instance.AddMessage(move.ToString() + " : Time.deltaTime", Color.white);
    }
}
