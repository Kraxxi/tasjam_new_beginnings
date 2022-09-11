using Unity.Mathematics;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float damage;
    public float knockback;
    public GameObject bloodSplatterParticles;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Killable killable = other.GetComponent<Killable>();

        if (!killable || killable.invincible) return;


        killable.TakeDamage(damage);
        Vector2 forceDirection = (killable.transform.position - transform.position);
        forceDirection.Normalize();
        Vector2 force = forceDirection * knockback * killable.knockbackMultiplier;
        killable.rb2d.AddForce(force, ForceMode2D.Impulse);


        Vector2 diffVector = killable.transform.position - transform.position;

        var bloodSplatter = Instantiate(bloodSplatterParticles, killable.transform.position, Quaternion.identity);
        bloodSplatter.transform.right = diffVector;
    }
}
