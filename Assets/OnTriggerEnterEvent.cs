using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEnterEvent : MonoBehaviour
{
    public UnityEvent response;
    private void OnTriggerEnter2D(Collider2D other)
    {
        response.Invoke();
    }
}
