using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Door : MonoBehaviour
{
    InventoryManager inventoryManager;

    ToolTip toolTip;

    private void Awake()
    {
        toolTip = GameObject.FindGameObjectWithTag("ToolTip").GetComponent<ToolTip>();
    }

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            if (inventoryManager.GetSelectedItem(false) != null)
            {
                if (inventoryManager.GetSelectedItem(false).type == ItemType.MainKey)
                {
                    inventoryManager.GetSelectedItem(true);
                    gameObject.SetActive(false);
                }
            }
            
        }
    }

    IEnumerator SetToolTipText()
    {
        string textAlready = "";
        if (toolTip.gameObject.GetComponent<TMP_Text>().text != null)
            textAlready = toolTip.gameObject.GetComponent<TMP_Text>().text;

        toolTip.gameObject.GetComponent<TMP_Text>().color = Color.red;

        toolTip.SetToolTip("Please use the golden key to unlock the door");
        yield return new WaitForSeconds(3);
        toolTip.gameObject.GetComponent<TMP_Text>().color = Color.white;
        toolTip.SetToolTip(textAlready);
    }

}
