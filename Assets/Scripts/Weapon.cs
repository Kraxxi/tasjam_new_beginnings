using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Weapon : Item
{
    public float damage;
    public bool continuousAttack;
    public float attackCooldown;
    
    
    public abstract void Attack(WeaponUser user);
    public abstract void Unequip(WeaponUser user);
    public abstract void Equip(WeaponUser user);
    public override void OnCollect(Player player)
    {
        player.weaponUser.Unequip();
        player.weaponUser.Equip(this);
    }
}

