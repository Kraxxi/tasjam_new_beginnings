using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Shooty Weapon")]
public class ShootyWeapon : Weapon
{
    public override void Attack(WeaponUser user)
    {
        Shoot(user);
    }

    private void Shoot(WeaponUser user)
    {
        Debug.Log("Shooting!");
    }
}
