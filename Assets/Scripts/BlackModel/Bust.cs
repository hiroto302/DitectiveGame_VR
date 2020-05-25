using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRM;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bust : MonoBehaviour
{
    public GameObject gameObj;
    VRMBlendShapeProxy proxy;
    Animator animator;
    GameObject fadePanel;
    GameObject cameraRig;

    void Start()
    {
        proxy = gameObj.GetComponent<VRMBlendShapeProxy>();
        this.animator = gameObj.GetComponent<Animator>();
        fadePanel = GameObject.Find("FadePanel");
        cameraRig = GameObject.Find("OVRCameraRig");
        // Scene loadScene = SceneManager.GetActiveScene();  //現在のシーンを取得
    }

    void Update()
    {
        
    }

    //HandTagを追加したコントローラーを、タグを判別し振動
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Hand")
        {
            OVRInput.SetControllerVibration(0.3f, 0.3f, OVRInput.Controller.RTouch);
            OVRInput.SetControllerVibration(0.3f, 0.3f, OVRInput.Controller.LTouch);
            // Invoke("cameraRig.GetComponent<MoveController>().PunchPower()", 2);

            this.animator.SetTrigger("AngryTrigger");
            proxy.ImmediatelySetValue(BlendShapePreset.Angry, 1.0f);  //表情の変化 第一引数 BlendShapePreset key(表情の種類) 第二引数表情変化
            fadePanel.GetComponent<FadeController>().isFadeOut = true;  //画面のfadeout
            Invoke("Punch", 2.0f);  //パンチで後方に飛ぶ
            Invoke("SecondPunch", 2.25f);
            Invoke("Reset", 7.0f);  //画面の初期化
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Hand")
        {
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);

            // proxy.ImmediatelySetValue(BlendShapePreset.Angry, 0);  //表情の変化
        }
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  //画面のリロード
        proxy.ImmediatelySetValue(BlendShapePreset.Angry, 0);  //胸を触ったら怒り顔状態維持に変更したためここで初期化
    }

    // Invokeで他クラスのメソッドを扱いたいため、一度ここで自クラスのメソッドに格納する
    public void Punch()
    {
        // cameraRig.GetComponent<MoveController>().PunchPower();  //パンチ動作に合わせて後方にふっ飛ぶ,初動は早く飛ぶ
        OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.RTouch);  //振動の追加
        OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.LTouch);
    }
    public void SecondPunch()  //少し減速
    {
        // cameraRig.GetComponent<MoveController>().secondPunchPower();
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
    }
}
