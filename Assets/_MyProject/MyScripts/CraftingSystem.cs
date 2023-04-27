using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSystem : MonoBehaviour
{
    public GameObject craftingTable;
    public GameObject itemToCraft;
    public GameObject[] requiredItems;

    public void CraftItem()
    {
        // Check if all required items are present on the crafting table
        foreach (GameObject requiredItem in requiredItems)
        {
            if (!craftingTable.transform.Find(requiredItem.name))
            {
                Debug.Log("Missing required item: " + requiredItem.name);
                return;
            }
        }

        // Remove all required items from the crafting table
        foreach (GameObject requiredItem in requiredItems)
        {
            GameObject itemOnTable = craftingTable.transform.Find(requiredItem.name).gameObject;
            Destroy(itemOnTable);
        }

        // Instantiate the crafted item on the crafting table
        Instantiate(itemToCraft, craftingTable.transform.position, Quaternion.identity);

        Debug.Log("Crafted item: " + itemToCraft.name);
    }
}
