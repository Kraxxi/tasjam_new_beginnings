using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Killable : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public bool invincible = false;
    public Animator anim;
    public Rigidbody2D rb2d;
    public float invincibilityDuration = 0.5f;
    public float knockbackMultiplier = 1f;
    public RoomManager roomManager;
    public UnityEvent onTakeDamage;
    public UnityEvent onDeath;
    public GameObject bloodSplatPrefab;
    public AudioClip hurtSound;
    public float minPitch;
    public float maxPitch;
    
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
            onTakeDamage.Invoke();
            return;
        }

        var audioGO = Instantiate(new GameObject());
        var audioSource = audioGO.AddComponent<AudioSource>();
        audioSource.volume = 0.5f;
        audioSource.pitch = Random.Range(minPitch, maxPitch);
        audioSource.PlayOneShot(hurtSound);
        Destroy(audioSource, hurtSound.length);

        if (currentHealth <= 0)
        {
            roomManager.OnEnemyDeath(transform.root.gameObject);
            onDeath.Invoke();
        }
        else
        {
            StartCoroutine(InvincibilityFrames());
        }

        Instantiate(bloodSplatPrefab, transform.position, Quaternion.identity);
        onTakeDamage.Invoke();
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
