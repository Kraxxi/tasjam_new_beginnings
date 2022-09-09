using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Enemy enemy;
    public float currentHealth;


    private void Start()
    {
        gameObject.name = enemy.enemyName;
        currentHealth = enemy.health;
    }
}
