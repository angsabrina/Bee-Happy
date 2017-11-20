using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    
    public static Inventory Instance { get; private set; }

    List<GameObject> inventory;

    public Inventory(int size)
    {
        inventory = new List<GameObject>(size);
    }

    public void AddFlowerInventory(GameObject flower)
    {
        inventory.Add(flower);

        foreach(GameObject g in inventory)
        {
            Debug.Log(g.name);
        }
    }
}
