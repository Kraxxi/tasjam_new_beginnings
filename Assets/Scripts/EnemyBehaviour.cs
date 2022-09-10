using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Enemy enemy;
    public Killable killable;
    public SpriteRenderer sr;
    
    private void Start()
    {
        gameObject.name = enemy.enemyName;
        killable.currentHealth = enemy.health;
        sr.sprite = enemy.sprite;
        killable.knockbackMultiplier = enemy.knockbackMultiplier;
    }
}
