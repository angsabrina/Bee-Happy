//public static Inventory Instance { get; private set; }

//public GameObject inventory;
//public GameObject EmptyObject;
//private int InventorySize = 54;

//public GameObject[] invItems;

//List<KeyValuePair<int, GameObject>> items = new List<KeyValuePair<int, GameObject>>();
//List<KeyValuePair<int, int>> itemCount = new List<KeyValuePair<int,int>>();

//void Awake()
//{
//    Instance = this;
//}



//void InitializeInventory()
//{
//    invItems = new GameObject[InventorySize];
//    for (int i = 0; i < InventorySize; i++)
//    {
//        invItems[i] = EmptyObject;
//        items.Add(new KeyValuePair<int, GameObject>(i, invItems[i]));
//        itemCount.Add(new KeyValuePair<int, int>(i, 0));
//    }
//}

//void addToInventory(int amount, GameObject flower)
//{
//    for(int i = 0; i < invItems.Length; i++)
//    {
//        if(invItems[i].name != "Empty")
//        {
//            if (invItems[i].name == flower.name)
//            {
//                int val = itemCount[i].Value + amount;
//                itemCount[i] = new KeyValuePair<int, int>(itemCount[i].Key, val);
//                break;
//            }
//        } else
//        {
//            int val = itemCount[i].Value + amount;
//            invItems[i] = flower;
//            items.Add(new KeyValuePair<int, GameObject>(i, flower));
//            itemCount.Add(new KeyValuePair<int, int>(i, val));
//            break;
//        }
//    }
//}
////public void AddFlowerInventory(GameObject flower)
////{
////    Debug.Log(flower + " has been added to inventory");
////    Debug.Log(inventory);
////    inventory.Add(flower);
////    Debug.Log(inventory.Count);
////}