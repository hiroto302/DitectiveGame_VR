using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRM;

public class Skirt : MonoBehaviour
{
    public GameObject gameObj;
    VRMBlendShapeProxy proxy;
    void Start()
    {
        proxy = gameObj.GetComponent<VRMBlendShapeProxy>();
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Hand")
        {
            proxy.ImmediatelySetValue(BlendShapePreset.Sorrow, 1.0f);
            OVRInput.SetControllerVibration(0.3f, 0.3f, OVRInput.Controller.RTouch);
            OVRInput.SetControllerVibration(0.3f, 0.3f, OVRInput.Controller.LTouch);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Hand")
        {
            proxy.ImmediatelySetValue(BlendShapePreset.Sorrow, 0);
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
        }
    }
}
