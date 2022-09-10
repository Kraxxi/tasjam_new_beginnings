using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Health Pickup")]
public class HealthPickup : Item
{
    public float healAmount;
    public override void OnCollect(Player player)
    {
        player.killable.TakeDamage(-healAmount);
    }
}
