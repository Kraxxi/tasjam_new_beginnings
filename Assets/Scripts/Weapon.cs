using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Weapon : ScriptableObject
{
    public Sprite weaponSprite;
    public float damage;
    public bool continuousAttack;
    public float attackCooldown;
    public abstract void Attack(WeaponUser user);
}
