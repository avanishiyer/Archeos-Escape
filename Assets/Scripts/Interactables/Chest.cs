using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Text;
using TMPro;

public class Chest : MonoBehaviour
{
    [SerializeField] Item key;
    [SerializeField] Item mainKey;
    [SerializeField] Item healthPot;

    public enum ChestType { locked, unlocked };
    public ChestType chestType;
    public Item[] itemsInChest;
    public string itemsInChestCode;

    InventoryManager inventoryManager;

    [SerializeField] float timeToUnlock = 1f;
    float timeInProgress;

    [SerializeField] private string id;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    private Vector3 position;
    private bool isActive = true;
    private bool savedIsActive;

    ToolTip toolTip;

    private void Awake()
    {
        toolTip = GameObject.FindGameObjectWithTag("ToolTip").GetComponent<ToolTip>();
    }

    private void Start()
    {
        //var sb = new StringBuilder();
        //foreach (Item item in itemsInChest)
        //{
        //    if (item.type == ItemType.HealthPot) sb.Append('1');
        //    if (item.type == ItemType.Key) sb.Append('2');
        //    if (item.type == ItemType.MainKey) sb.Append('3');
        //}
        //itemsInChestCode = sb.ToString();

        inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();

        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        timeInProgress = 0f;

        if (!isActive)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (chestType == ChestType.unlocked)
            {
                if (timeInProgress < timeToUnlock)
                {
                    timeInProgress += Time.deltaTime;
                }
                else
                {
                    UnlockChest();
                }
            }
            else if (chestType == ChestType.locked)
            {
                Item item = inventoryManager.GetSelectedItem(false);
                if (item != null)
                {
                    if (item.type == ItemType.Key)
                    {
                        if (timeInProgress < timeToUnlock)
                        {
                            timeInProgress += Time.deltaTime;
                        }
                        else
                        {
                            inventoryManager.GetSelectedItem(true);
                            UnlockChest();
                        }
                    }
                    else
                        StartCoroutine(SetToolTipText());
                }
                else
                    StartCoroutine(SetToolTipText());
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            timeInProgress = 0f;
        }
    }
    private void UnlockChest()
    {
        for (int i = 0; i < itemsInChest.Length; i++)
        {
            bool result = inventoryManager.AddItem(itemsInChest[i]);
            if (result == true) Debug.Log("Item added");
            else Debug.Log("Inventory Full");
        }

        gameObject.SetActive(false);
    }

    //public void LoadData(GameData data)
    //{
    //    data.chestLocation.TryGetValue(id, out position);
    //    data.chestLocked.TryGetValue(id, out chestType);
    //    data.chestItems.TryGetValue(id, out itemsInChestCode);
    //    data.chestActive.TryGetValue(id, out savedIsActive);
    //    isActive = savedIsActive;

    //    if (isActive)
    //    {
    //        transform.position = position;

    //        itemsInChest = new Item[] { };
    //        var list = new List<Item>();
    //        for (int i = 0; i < itemsInChestCode.ToCharArray().Length; i++)
    //        {
    //            if (itemsInChestCode.ToCharArray()[i] == '1') list.Add(healthPot);
    //            if (itemsInChestCode.ToCharArray()[i] == '2') list.Add(key);
    //            if (itemsInChestCode.ToCharArray()[i] == '3') list.Add(mainKey);
    //        }
    //        itemsInChest = list.ToArray();
    //    } 
    //}

    //public void SaveData(ref GameData data)
    //{
    //    if (data.chestLocation.ContainsKey(id)) data.chestLocation.Remove(id);
    //    if (data.chestItems.ContainsKey(id)) data.chestItems.Remove(id);
    //    if (data.chestLocked.ContainsKey(id)) data.chestLocked.Remove(id);
    //    if (data.chestActive.ContainsKey(id)) data.chestActive.Remove(id);

    //    data.chestLocation.Add(id, transform.position);
    //    data.chestLocked.Add(id, chestType);
    //    data.chestItems.Add(id, itemsInChestCode);
    //    data.chestActive.Add(id, isActive);
    //}

    IEnumerator SetToolTipText()
    {
        string textAlready = "";
        if (toolTip.gameObject.GetComponent<TMP_Text>().text != null)
            textAlready = toolTip.gameObject.GetComponent<TMP_Text>().text;

        toolTip.gameObject.GetComponent<TMP_Text>().color = Color.red;

        toolTip.SetToolTip("Please use the silver key to unlock the chest");
        yield return new WaitForSeconds(3);
        toolTip.gameObject.GetComponent<TMP_Text>().color = Color.white;
        toolTip.SetToolTip(textAlready);
    }
}
