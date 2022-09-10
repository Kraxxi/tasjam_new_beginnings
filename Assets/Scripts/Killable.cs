using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Killable : MonoBehaviour
{
    public float currentHealth;
    public bool invincible = false;
    public Animator anim;
    public Rigidbody2D rb2d;
    public float invincibilityDuration = 0.5f;
    public UnityEvent onDeath;
    public float knockbackMultiplier = 1f;
    
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            onDeath.Invoke();
        }
        else
        {

            StartCoroutine(InvincibilityFrames());
        }
    }

    public IEnumerator InvincibilityFrames()
    {
        SetInvincible(true);
        yield return new WaitForSeconds(invincibilityDuration);
        SetInvincible(false);

    }

    public void SetInvincible(bool b)
    {
        invincible = b;
        anim.SetBool("invincible", b);
    }
    
}
