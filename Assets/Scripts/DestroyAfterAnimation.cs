using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterAnimation : MonoBehaviour
{
    public Animator anim;

    private void Awake()
    {
        if (anim == null) { anim = GetComponent<Animator>(); }
    }

    private void Start()
    {
        Destroy(gameObject, anim.GetCurrentAnimatorStateInfo(0).length);
    }
}
