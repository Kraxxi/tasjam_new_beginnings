using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class LootDropper : MonoBehaviour
{
    public GameObject droppedItemPrefab;
    public List<Item> lootList;
    public float dropChance;
    
    public void DropLoot()
    {
        float randy = Random.Range(0f, 1f);

        Debug.Log(randy);
        
        if (randy >= 1f - dropChance)
        {
            int randyInt = Random.Range(0, lootList.Count);

            GameObject lootGO = Instantiate(droppedItemPrefab, transform.position, Quaternion.identity);
            ItemPickup lootPickup = lootGO.GetComponent<ItemPickup>();

            lootPickup.item = lootList[randyInt];
        }
    }
}
