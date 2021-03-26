﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 点滅（明->暗->明)を繰り返すスクリプト
public class BlinkLight : MonoBehaviour
{
    [SerializeField]
    Light light = null;
    // intensityの初期値
    public float initialIntensity;
    // 暗く点滅する時の値 initialIntensityより低くすること
    public float lowIntensity = 1.0f;
    // 差
    float differenceValue;
    // 点滅にかける時間
    public float blinkTime = 1.0f;
    // 点滅にかける時間の初期値
    float initialBlinkTime;
    // 点滅速度
    float blinkSpeed;
    // 点滅の方向
    float blinkDirection = -1.0f;
    // 点滅を開始するフラグ
    public bool blink = false;

    void Reset()
    {
        light = GetComponent<Light>();
        initialIntensity = light.intensity;
    }
    void Start()
    {
        initialBlinkTime = blinkTime;
        differenceValue = initialIntensity - lowIntensity;
        blinkSpeed = differenceValue / blinkTime;
    }

    void Update()
    {
        if(blink)
        {
            if(0 < blinkTime)
            {
                light.intensity += blinkDirection * blinkSpeed * Time.deltaTime;
                blinkTime -= Time.deltaTime;
            }
            else if(blinkTime <= 0)
            {
                blinkTime = initialBlinkTime;
                blinkDirection *= -1;
            }
        }
    }

    public void Blink(bool blink)
    {
        this.blink = blink;
    }
}
