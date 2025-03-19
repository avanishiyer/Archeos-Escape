using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public Item[] startItems;
    public int maxStackedItems = 4;
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;
    int selectedSlot;

    AudioManager audioManager;
    
    private void Awake()
    {
        // creating instance so that we can access which item we are holding
        instance = this;

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        // adding start items
        ChangeSelectedSlot(0);
        foreach (var item in startItems)
        {
            AddItem(item);
        }
    }

    private void Update()
    {
        // selecting slot
        if (Input.inputString != null)
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if (isNumber && number > 0 && number < 7)
            {
                ChangeSelectedSlot(number - 1);

                ToolTip toolTip = GameObject.FindGameObjectWithTag("ToolTip").GetComponent<ToolTip>();
                Item itemSelected = GetSelectedItem(false);
                if (itemSelected == null)
                    toolTip.SetToolTip("");
                else
                {
                    switch (itemSelected.type)
                    {
                        case ItemType.Sword:
                            toolTip.SetToolTip("Sword");
                            break;

                        case ItemType.Gun:
                            toolTip.SetToolTip("Gun");
                            break;

                        case ItemType.HealthPot:
                            toolTip.SetToolTip("HealthPot");
                            break;

                        case ItemType.Key:
                            toolTip.SetToolTip("Chest Key");
                            break;

                        case ItemType.MainKey:
                            toolTip.SetToolTip("Main Key");
                            break;

                        default:
                            break;
                    }
                }

                if (Random.Range(1, 3) == 1)
                    audioManager.PlaySFX(audioManager.invSwap1);
                else
                    audioManager.PlaySFX(audioManager.invSwap2);
            }
        }
    }

    // changing to selected slot
    void ChangeSelectedSlot(int newSlot)
    {
        // deselecting old slot
        if (selectedSlot >= 0)
        {
            inventorySlots[selectedSlot].DeselectSlot();
        }

        // selecting new slot
        inventorySlots[newSlot].SelectSlot();
        selectedSlot = newSlot;
    }

    // add item
    public bool AddItem(Item item)
    {
        // checking if item type is in inventory
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            // getting item in slot
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();

            // if item type is present and stackable
            if (itemInSlot != null &&
                itemInSlot.item == item &&
                itemInSlot.count < maxStackedItems &&
                itemInSlot.item.stackable == true)
            {
                // adding item count and calling the refreshing inventory
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true;
            }
            // if item not present in inventory
            // empty slot present
            else if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }

        return false;
    }

    // adding a new item in world
    void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItemGameObject = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGameObject.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }

    // get item that is currently selected
    // use true as input if want to use, else use false as input
    public Item GetSelectedItem(bool use)
    {
        // all inventory slot game objects present
        InventorySlot slot = inventorySlots[selectedSlot];

        // getting current item in slot
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();

        // if item is present in slot
        if (itemInSlot != null)
        {
            Item item = itemInSlot.item;

            // if want to use
            if (use == true)
            {
                // reduce count
                // if count final count is 0 then destroy object
                itemInSlot.count--;
                if (itemInSlot.count <= 0)
                {
                    Destroy(itemInSlot.gameObject);
                }
                else
                {
                    itemInSlot.RefreshCount();
                }
            }
            return item;
        }
        // if slot is empty
        return null;
    }
}
