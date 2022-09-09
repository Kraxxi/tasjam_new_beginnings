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

    public override void Unequip(WeaponUser user) { }
    public override void Equip(WeaponUser user)
    {
        
    }

    private void Swing(WeaponUser user)
    {
        
        user.weaponAnim.SetTrigger("swing");
    }

}
