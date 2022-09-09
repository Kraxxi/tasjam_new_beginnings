using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    public SpriteRenderer sr;
    public Collider2D itemCollider;
    
    private void Start()
    {
        sr.sprite = item.itemSprite;
    }

    public void DelayEnableCollider()
    {
        StartCoroutine(ActivateCollider());
    }
    
    private IEnumerator ActivateCollider()
    {
        yield return new WaitForSeconds(1);
        itemCollider.enabled = true;
    }
}
