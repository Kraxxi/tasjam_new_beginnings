using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoomManager : MonoBehaviour
{
    public List<Spawner> spawners;
    public Transform playerSpawn;
    public Player player;
    public List<GameObject> spawnedEnemies;
    public List<Enemy> enemyTypes;
    public int level;
    public GameObject enemyPrefab;
    public Animator doorAnim;
    public TextMeshProUGUI levelIndicator;

    private bool _isSpawning;
    
    private void Start()
    {
        ResetRoom();
    }

    public void ResetRoom()
    {
        player.transform.position = playerSpawn.position;
        levelIndicator.text = $"Level: {level + 1}";
        for (int i = spawnedEnemies.Count - 1; i >= 0; i--)
        {
            Destroy(spawnedEnemies[i]);
            spawnedEnemies.RemoveAt(i);
        }
        doorAnim.SetBool("doorOpen", false);

        ItemPickup[] pickups = FindObjectsOfType<ItemPickup>();

        for (int i = pickups.Length - 1; i >= 0; i--)
        {
            Destroy(pickups[i].gameObject);
        }
        
        SpawnBasedOnLevel();
    }

    public void ProgressToNextRoom()
    {
        level++;
        ResetRoom();
    }

    private void SpawnBasedOnLevel()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        _isSpawning = true;
        for (int i = 0; i < level + 1; i++)
        {
            float randyF = Random.Range(1f, 5f);
            yield return new WaitForSeconds(randyF);
            
            int randy = Random.Range(0, spawners.Count);
            Vector3 randyPos = spawners[randy].transform.position;

            randy = Random.Range(0, enemyTypes.Count);

            GameObject enemyGO = Instantiate(enemyPrefab, randyPos, Quaternion.identity);
            EnemyBehaviour enemy = enemyGO.GetComponent<EnemyBehaviour>();
            enemy.killable.roomManager = this;
            spawnedEnemies.Add(enemyGO);
            enemy.enemy = enemyTypes[randy];
        }

        _isSpawning = false;
    }

    private void RestartGame()
    {
        level = 0;
        player.Reset(playerSpawn.position);
        ResetRoom();
    }
    
    public void OnEnemyDeath(GameObject enemyGameObject)
    {
        Player player = enemyGameObject.GetComponent<Player>();
        if (player)
        {
            RestartGame();
        }
        
        if (!spawnedEnemies.Contains(enemyGameObject)) return;
        
        spawnedEnemies.Remove(enemyGameObject);
        Destroy(enemyGameObject);
        
        if (spawnedEnemies.Count == 0 && !_isSpawning)
        {
            doorAnim.SetBool("doorOpen", true);
        }
    }
}
