using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimDirection : MonoBehaviour
{
    public Vector2 baseOffset;
    public float rangeMultiplier;
    public Vector2 Direction { get; private set; }
    public void SetDirection(Vector2 direction)
    {
        if (direction == Vector2.zero) return;

        Direction = direction;
        
        transform.localPosition = baseOffset + (Direction * rangeMultiplier);
    }
}
