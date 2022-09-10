using UnityEngine;


[CreateAssetMenu(menuName = "Weapons/Swingy Weapon")]
public class SwingyWeapon : Weapon
{
    public GameObject swingPrefab;

    public override void Attack(WeaponUser user)
    {
        Swing(user);
    }

    public override void Unequip(WeaponUser user) { }
    public override void Equip(WeaponUser user) { }

    private void Swing(WeaponUser user)
    {
        GameObject swingGO = Instantiate(swingPrefab, user.transform.position, user.transform.rotation, user.transform);
        DamageDealer damageDealer = swingGO.GetComponent<DamageDealer>();
        damageDealer.damage = damage;
        damageDealer.knockback = knockback;

    }

}
