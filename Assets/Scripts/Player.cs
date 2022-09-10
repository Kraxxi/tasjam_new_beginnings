using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Mover mover;
    public WeaponUser weaponUser;
    public AimDirection aimDirection;
    public Killable killable;
    public float startingHealth;
    
    
    private void Start()
    {
        killable.currentHealth = startingHealth;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ItemPickup pickup = other.GetComponent<ItemPickup>();

        if (!pickup) return;

        pickup.item.OnCollect(this);
        Destroy(pickup.gameObject);
    }
}
