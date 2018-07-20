using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour{


    //Fill ins
    public Dictionary<GameObject, int> playerInventory = new Dictionary<GameObject, int>();
    public GameObject playerGUI;
    public GameObject slotPrefab;

    //Vars
    private int inventoryCols = 6;
    private int inventoryRows = 7;
    private GameObject[,] inventoryPics;
    private int uniqueItemCount = 0;

    //GUI Vars
    private int XSpaceBetweenSlots = 55;
    private int YSpaceBetweenSlots = 60;

    public void Awake()
    {
        inventoryPics = new GameObject[inventoryCols, inventoryRows];

        for (int i = 0; i < inventoryCols; i++)
        {
            for (int j = 0; j < inventoryRows; j++)
            {
                GameObject slot = Instantiate(slotPrefab);
                slot.GetComponent<Transform>().SetParent(playerGUI.transform);
                float parentOffsetX = slot.GetComponent<Transform>().parent.transform.position.x/5;
                float parentOffsetY = slot.GetComponent<Transform>().parent.transform.position.y/1.5f;
                slot.GetComponent<Transform>().localPosition = new Vector3((i*XSpaceBetweenSlots) - parentOffsetX, (j*YSpaceBetweenSlots) - parentOffsetY, 0);
                inventoryPics[i, j] = slot;
            }
        }
    }

    public void addToInventory(GameObject item, Image itemImage)
    {
        if (playerInventory.ContainsKey(item))
        {
            playerInventory[item]++;
        }
        else
        {
            playerInventory.Add(item, 1);
            uniqueItemCount++;
            int colth;
            int rowth = uniqueItemCount / inventoryRows;
            if (uniqueItemCount % inventoryCols == 1)
            {
                colth = 0;
            } else if (uniqueItemCount % inventoryCols == 0)
            {
                colth = inventoryCols - 1;
            } else
            {
                colth = uniqueItemCount % inventoryCols - 1;
            }
            inventoryPics[colth, rowth].GetComponent<RawImage>().texture = itemImage.mainTexture;
            inventoryPics[colth, rowth].gameObject.tag = "InventoryItem";
        }
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
