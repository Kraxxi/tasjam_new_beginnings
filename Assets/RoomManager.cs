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

    private void Start()
    {
        ResetRoom();
    }

    public void ResetRoom()
    {
        player.Reset(playerSpawn.position);
        levelIndicator.text = $"Level: {level + 1}";
        for (int i = spawnedEnemies.Count - 1; i >= 0; i--)
        {
            Destroy(spawnedEnemies[i]);
            spawnedEnemies.RemoveAt(i);
        }
        doorAnim.SetBool("doorOpen", false);

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

        yield return new WaitForSeconds(1f);
        for (int i = 0; i < level + 1; i++)
        {
            int randy = Random.Range(0, spawners.Count);
            Vector3 randyPos = spawners[randy].transform.position;

            randy = Random.Range(0, enemyTypes.Count);

            GameObject enemyGO = Instantiate(enemyPrefab, randyPos, Quaternion.identity);
            EnemyBehaviour enemy = enemyGO.GetComponent<EnemyBehaviour>();
            enemy.killable.roomManager = this;
            spawnedEnemies.Add(enemyGO);
            enemy.enemy = enemyTypes[randy];

            float randyF = Random.Range(1f, 5f);
            yield return new WaitForSeconds(randyF);
        }
    }

    private void RestartGame()
    {
        level = 0;
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
        
        if (spawnedEnemies.Count == 0)
        {
            doorAnim.SetBool("doorOpen", true);
        }
    }
}
