using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Enemy enemy;
    public Killable killable;
    public LootDropper lootDropper;
    public SpriteRenderer sr;
    
    private void Start()
    {
        gameObject.name = enemy.enemyName;
        killable.currentHealth = enemy.health;
        killable.maxHealth = enemy.health;
        sr.sprite = enemy.sprite;
        killable.knockbackMultiplier = enemy.knockbackMultiplier;
        lootDropper.dropChance = enemy.lootDropChance;
        lootDropper.lootList = enemy.lootList;
    }
}
