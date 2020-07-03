using UnityEngine;

// Playerのスクリプト
// オキュラスクエスト用 transform.TranslateによるPlayerの移動方法

// Translate の 移動法でカクツク原因は, time.deltaTimeを利用すると起こるのが一つの原因であった
// 現在の解決方法
// 1. FPSが約40であるため、その乗数をかける
//    ＝＞ 対象機種がオキュラスクエストであってもデバイスによる性能差が出る場合が問題である
public class PlayerController : MonoBehaviour
{
    // Playerの状態
    public enum State
    {
        Normal,
        Talk
    }
    // Playerの現在の状態
    public State currentState;
    // Playerの移動に関する変数群
    private float angleSpeed = 45.0f;
    private float moveSpeed = 2.0f;
    private float speedMultiplier = 0.02f;
    // 顔が向いてる方向
    [SerializeField]
    Transform moveTarget = null;

    // オキュラスクエストの入力値

    float x, y;
    Vector3 move = Vector3.zero;

    // Playerが指を指している方向 PointingDirection
    [SerializeField]
    GameObject[] pointingDirections = null;

    // PlayerFootから取得
    [SerializeField]
    SE se = null;
    // 経過時間
    float elapsedTime = 0;
    void Reset()
    {
        if(!moveTarget)
        {
            moveTarget = GetComponentInChildren<OVRCameraRig>().transform.Find("TrackingSpace/CenterEyeAnchor");
        }
        pointingDirections = GameObject.FindGameObjectsWithTag("PointingDirection");
        se = transform.Find("PlayerFoot").GetComponent<SE>();
    }

    void Awake()
    {
        SetState(State.Normal);
    }
    void Update()
    {
        // Normal・Talkの状態時、移動可
        if(currentState == State.Normal || currentState == State.Talk)
        {
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

            // 足音 方向・移動
            if(Mathf.Abs(x) > 0.8f || Mathf.Abs(y) > 0.8f)
            {
                elapsedTime += Time.deltaTime;
                if(elapsedTime > 0.8f)
                {
                    se.PlaySE(0, 0.5f);
                    elapsedTime = 0;
                }
            }
            else if(Mathf.Abs(x) > 0.5f || Mathf.Abs(y) > 0.5f)
            {
                elapsedTime += Time.deltaTime;
                if(elapsedTime > 1.0f)
                {
                    se.PlaySE(0, 0.4f);
                    elapsedTime = 0;
                }
            }
            else if(Mathf.Abs(x) > 0.1f || Mathf.Abs(y) > 0.1f)
            {
                elapsedTime += Time.deltaTime;
                if(elapsedTime > 1.5f)
                {
                    se.PlaySE(2, 0.3f);
                    elapsedTime = 0;
                }
            }
        }
        // HMD内にデバッグ表示方法 表示するものは一つにすること
        // OVRDebugConsole.Log(move.ToString("f5"));
        // OVRDebugConsole.instance.AddMessage(move.ToString() + " : Time.deltaTime", Color.white);
    }

    // 現在の状態を変更するメソッド
    public void SetState(State state)
    {
        currentState = state;
        if(state == State.Normal)
        {
            // Talk状態の時、非表示
            ShowPointingDirection(false);
        }
        else if(state == State.Talk)
        {
            // Talk状態の時、表示
            ShowPointingDirection(true);
        }
    }

    // PointingDirectionの表示・非表示
    // 会話状態の時のみ、左右の手のPointingDirectionを有効にする
    void ShowPointingDirection(bool show)
    {
        foreach(GameObject pointingDirection in pointingDirections)
        {
            pointingDirection.SetActive(show);
        }
    }
}
