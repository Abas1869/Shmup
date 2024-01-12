// LootBag.cs
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    [System.Serializable]
    public class Loot
    {
        public string lootName;
        public float dropChancePrefab1;
        public float dropChancePrefab2;
        public Sprite lootSprite;
        public GameObject lootPrefab1;
        public GameObject lootPrefab2;
    }

    public List<Loot> lootList = new List<Loot>();

    public void InstantiateLoot(Vector3 spawnPosition, GameObject lootPrefab, Sprite lootSprite)
    {
        GameObject lootGameObject = Instantiate(lootPrefab, spawnPosition, Quaternion.identity);
        lootGameObject.GetComponent<SpriteRenderer>().sprite = lootSprite;
        // Gör något med lootGameObject om det behövs
    }

    public void DropLoot(Vector3 spawnPosition)
    {
        Loot droppedItem = GetDroppedItem();
        if (droppedItem != null)
        {
            // Använd Random.Range för att avgöra vilken prefab som ska användas
            float randomValue = Random.Range(0f, 1f);

            if (randomValue <= droppedItem.dropChancePrefab1)
            {
                InstantiateLoot(spawnPosition, droppedItem.lootPrefab1, droppedItem.lootSprite);
            }
            else
            {
                InstantiateLoot(spawnPosition, droppedItem.lootPrefab2, droppedItem.lootSprite);
            }
        }
    }

    Loot GetDroppedItem()
    {
        int randomNumber = Random.Range(1, 101); // 1-100
        List<Loot> possibleItems = new List<Loot>();

        foreach (Loot item in lootList)
        {
            if (randomNumber <= item.dropChancePrefab1 || randomNumber <= item.dropChancePrefab2)
            {
                possibleItems.Add(item);
            }
        }

        if (possibleItems.Count > 0)
        {
            Loot droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return droppedItem;
        }

        Debug.Log("No loot dropped");
        return null;
    }
}
