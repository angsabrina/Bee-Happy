using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour{

    public Dictionary<GameObject, int> playerInventory; 

    public void Start()
    {
        playerInventory = new Dictionary<GameObject, int>();
    }
    
    public void addToInventory(GameObject item)
    {
        playerInventory.Add(item, 1);
        Debug.Log("This was added to your inventory: " + item);
    }

    public void removeFromInventory(GameObject item)
    {
        int count = 0;
        playerInventory.TryGetValue(item, out count);
        if (count > 1)
        {
            playerInventory.Add(item, count - 1);
        } else
        {
            playerInventory.Remove(item);
        }
    }
}
