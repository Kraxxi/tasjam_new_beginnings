using UnityEngine;

public class Projectile : MonoBehaviour
{
    public DamageDealer damageDealer;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Collided with {other.gameObject.name}", other.gameObject);

        Killable killable = other.GetComponent<Killable>();

        if (killable && killable.invincible) return;
        
        Destroy(gameObject);
    }
}
