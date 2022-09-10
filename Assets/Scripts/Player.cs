using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Mover mover;
    public WeaponUser weaponUser;
    public AimDirection aimDirection;
    public Killable killable;
    public float startingHealth;
    public Slider slider;
    
    private void Start()
    {
        killable.currentHealth = startingHealth;
    }

    public void UpdateUI()
    {
        slider.value = killable.currentHealth / startingHealth;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        ItemPickup pickup = other.GetComponent<ItemPickup>();

        if (!pickup) return;

        pickup.item.OnCollect(this);
        Destroy(pickup.gameObject);
    }

    public void Reset(Vector3 resetPos)
    {
        transform.position = resetPos;
        killable.currentHealth = startingHealth;
    }
    
    
}
