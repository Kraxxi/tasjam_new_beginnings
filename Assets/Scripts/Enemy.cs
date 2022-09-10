using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    public Sprite sprite;
    public string enemyName;
    public float health;
    public float knockbackMultiplier = 1f;
    public List<Item> lootList;
    public float lootDropChance;
}
