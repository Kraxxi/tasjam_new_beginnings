using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Shooty Weapon")]
public class ShootyWeapon : Weapon
{
    public GameObject projectilePrefab;
    public float projectileSpeed;
    
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
        GameObject projectileGO = Instantiate(projectilePrefab, user.transform.position, user.transform.rotation);
        projectileGO.layer = LayerMask.NameToLayer("PlayerProjectiles");
        Rigidbody2D rb2d = projectileGO.GetComponent<Rigidbody2D>();
        DamageDealer damageDealer = projectileGO.GetComponent<DamageDealer>();
        damageDealer.damage = damage;
        damageDealer.knockback = knockback;

        rb2d.velocity = user.aimDirection.Direction * projectileSpeed;
    }
}
