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
    

    public override void Unequip(WeaponUser user)
    {
        user.shootObject.SetActive(false);
    }

    public override void Equip(WeaponUser user)
    {
        user.shootObject.SetActive(true);
    }

    private void Shoot(WeaponUser user)
    {
        Debug.Log("Shooting!");
    }
}
