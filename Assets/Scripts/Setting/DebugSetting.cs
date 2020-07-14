using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// テストPlayが終了したらfalseにすること
public class DebugSetting : MonoBehaviour
{
    void Start()
    {
        Debug.unityLogger.logEnabled = true;
    }

}
