using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UICraftResult : MonoBehaviour
{
    public SlotPanel slotPanel;
    public Inventory inventory;

    public void CollectCraftResult()
    {
        slotPanel.EmptyAllSlots();
        inventory.playerItems.Add(GetComponent<UIItem>().item);
    }

}
