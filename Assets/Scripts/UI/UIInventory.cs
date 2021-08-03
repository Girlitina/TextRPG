using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField]
    private SlotPanel[] slotPanels;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void AddItemToUI(Item item)
    {
        foreach (SlotPanel sp in slotPanels)
        {
            if (sp.ContainsEmptySlot())
            {
                sp.AddNewItem(item);
                break;
            }
        }
    }
}
