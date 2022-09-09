using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Weapons/Swingy Weapon")]
public class SwingyWeapon : Weapon
{
    public override void Attack(WeaponUser user)
    {
        Swing(user);
    }

    private void Swing(WeaponUser user)
    {
        Debug.Log("Swinging!");
    }
}
