using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : MonoBehaviour
{
    public Transform target;
    public Mover mover;


    private void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    private void FixedUpdate()
    {
        Seek();
    }

    public void Seek()
    {
        if (target == null) return;

        Vector2 targetDirection = target.transform.position - transform.position;
        
        mover.Move(targetDirection);
    }
}
