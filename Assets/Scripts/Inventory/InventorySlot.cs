using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Image image;
    public Color selectedColor, DeselectedColor;

    // when initialised, deselect all slots to avoid bugs
    private void Awake()
    {
        DeselectSlot(); 
    }

    // changing ui color of selected slot
    public void SelectSlot()
    {
        image.color = selectedColor;
    }

    // changing ui color back when deselecting slot
    public void DeselectSlot()
    {
        image.color = DeselectedColor;
    }

    // transferring item from one slot to another
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        { 
            GameObject dropped = eventData.pointerDrag;
            InventoryItem inventoryItem = dropped.GetComponent<InventoryItem>();
            inventoryItem.parentAfterDrag = transform;
        }
    }
}
