using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour{

    //Fill ins
    public Dictionary<GameObject, int> playerInventory;
    public GameObject playerGUI;
    public GameObject slotPrefab;

    //Vars
    private int inventoryRows = 6;
    private int inventoryCols = 7;
    private GameObject[,] inventoryPics;
    private int uniqueItemCount = 0;

    public void Start()
    {
        playerInventory = new Dictionary<GameObject, int>();
        playerGUI = GameObject.Find("Inventory");

        for(int i = 0; i < inventoryRows; i++)
        {
            for (int j = 0; j < inventoryCols; j++)
            {
                GameObject slot = Instantiate(slotPrefab);
                slot.GetComponent<Transform>().SetParent(playerGUI.transform);
                float parentOffsetX = slot.GetComponent<Transform>().parent.transform.position.x/5;
                float parentOffsetY = slot.GetComponent<Transform>().parent.transform.position.y/1.5f;
                slot.GetComponent<Transform>().localPosition = new Vector3((i*50) - parentOffsetX, (j*60) - parentOffsetY, 0);
            }
        }
    }
    
    public void addToInventory(GameObject item)
    {
        if (playerInventory.ContainsKey(item))
        {
            playerInventory[item]++;
        } else
        {
            playerInventory.Add(item, 1);
            uniqueItemCount++;
            int rowth = uniqueItemCount % inventoryRows;
        }
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
