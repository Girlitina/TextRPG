using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IPointerDownHandler
{
    public Item item;
    private Image spriteImage;
    private UIItem selectedItem;
    public bool craftingSlot = false;
    private CraftingSlot craftingSlots;
    public bool craftedItemSlot = false;

    private void Awake()
    {
        craftingSlots = FindObjectOfType<CraftingSlot>();
        selectedItem = GameObject.Find("SelectedItem").GetComponent<UIItem>();
        spriteImage = GetComponent<Image>();
        UpdateItem(null);
    }

    public void UpdateItem(Item item)
    {
        this.item = item;
        if (this.item != null)
        {
            spriteImage.color = Color.white;
            spriteImage.sprite = item.icon;
        }
        else
        {
            spriteImage.color = Color.clear;
        }
        if (craftingSlot)
        {
            craftingSlots.UpdateRecipe();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (this.item != null)
        {
            if (selectedItem.item != null && !craftedItemSlot)
            {
                Item clone = new Item(selectedItem.item);
                selectedItem.UpdateItem(this.item);
                UpdateItem(clone);
            }
            else if (selectedItem.item == null)
            {
                selectedItem.UpdateItem(this.item);
                UpdateItem(null);
                if (craftedItemSlot)
                {
                    GetComponent<UICraftResult>().CollectCraftResult();
                }
            }
        }
        else if (selectedItem.item != null && !craftedItemSlot)
        {
            UpdateItem(selectedItem.item);
            selectedItem.UpdateItem(null);
        }
    }
}