using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemsToPickup;

    public void PickupItem(int id)
    {
        bool result =  inventoryManager.AddItem(itemsToPickup[id]);
        if (result == true) Debug.Log("Item added");
        else Debug.Log("Inventory Full");
    }

    public void GetSelectedItem()
    {
        Item recievedItem = inventoryManager.GetSelectedItem(false);

        if (recievedItem != null)
        {
            Debug.Log("Item Recieved: " + recievedItem);
        }
        else Debug.Log("No Item Recieved");
    }

    public void UseSelectedItem()
    {
        Item recievedItem = inventoryManager.GetSelectedItem(true);

        if (recievedItem != null)
        {
            Debug.Log("Item Used: " + recievedItem);
        }
        else Debug.Log("No Item Used");
    }
}
