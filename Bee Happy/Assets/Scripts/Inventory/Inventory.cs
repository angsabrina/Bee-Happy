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
    private int inventoryRows = 6;
    private int inventoryCols = 7;
    private GameObject[,] inventoryPics;
    private int uniqueItemCount = 0;

    //GUI Vars
    private int XSpaceBetweenSlots = 55;
    private int YSpaceBetweenSlots = 60;

    public void Awake()
    {
        Debug.Log("In inventory awkae");
        inventoryPics = new GameObject[inventoryRows, inventoryCols];

        for (int i = 0; i < inventoryRows; i++)
        {
            for (int j = 0; j < inventoryCols; j++)
            {
                GameObject slot = Instantiate(slotPrefab);
                slot.GetComponent<Transform>().SetParent(playerGUI.transform);
                float parentOffsetX = slot.GetComponent<Transform>().parent.transform.position.x/5;
                float parentOffsetY = slot.GetComponent<Transform>().parent.transform.position.y/1.5f;
                slot.GetComponent<Transform>().localPosition = new Vector3((i*XSpaceBetweenSlots) - parentOffsetX, (j*YSpaceBetweenSlots) - parentOffsetY, 0);
                inventoryPics[i, j] = slot;
            }
        }
        //checkInventoryPics();
    }

    //private void checkInventoryPics()
    //{
    //    for (int i = 0; i < inventoryRows; i++)
    //    {
    //        for (int j = 0; j < inventoryCols; j++)
    //        {
    //            Debug.Log(inventoryPics[i, j] + "   ");
    //        }
    //        Debug.Log("\n");
    //    }
    //}
    
    public void addToInventory(GameObject item, Image itemImage)
    {
        if (playerInventory.ContainsKey(item))
        {
            playerInventory[item]++;
        } else
        {
            playerInventory.Add(item, 1);
            uniqueItemCount++;
            int colth = uniqueItemCount % inventoryRows - 1;
            int rowth = uniqueItemCount / inventoryRows;
            Debug.Log("rowth: " + rowth + " colth: " + colth);
            inventoryPics[colth, rowth].GetComponent<RawImage>().texture = itemImage.mainTexture;
            //checkInventoryPics();
        }
        //Debug.Log("This was added to your inventory: " + item);
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
