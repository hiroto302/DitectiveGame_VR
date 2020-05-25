using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mesen : MonoBehaviour
{
    Animator animator;
    Vector3 LookPos;
    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    void Update()
    {
        this.LookPos = Camera.main.transform.position;
    }

    private void OnAnimatorIK(int layerIndex)
    {
        this.animator.SetLookAtWeight(1.0f, 0.1f, 1.0f, 0, 0.7f);
        this.animator.SetLookAtPosition(this.LookPos);
    }
}
