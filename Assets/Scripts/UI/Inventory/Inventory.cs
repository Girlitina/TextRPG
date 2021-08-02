using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{
    public class Inventory : MonoBehaviour
    {
        public List<Item> playerItems = new List<Item>();
        [SerializeField]
        private UIInventory InventoryUI;
        ItemDatabase itemDatabase;

        private void Awake()
        {
            itemDatabase = FindObjectOfType<ItemDatabase>();
        }
        private void Start()
        {
            GiveItem(1);
        }

        public void GiveItem(int id)
        {
            Item itemToAdd = itemDatabase.GetItem(id);
            InventoryUI.AddItemToUI(itemToAdd);
            playerItems.Add(itemToAdd);
        }

        public void GiveItem(string itemName)
        {
            Item itemToAdd = itemDatabase.GetItem(itemName);
            InventoryUI.AddItemToUI(itemToAdd);
            playerItems.Add(itemToAdd);
        }

        public Item CheckForItem(int id)
        {
            return playerItems.Find(item => item.id == id);
        }

        public void RemoveItem(int id)
        {
            Item itemToRemove = CheckForItem(id);
            if (itemToRemove != null)
            {
                playerItems.Remove(itemToRemove);
            }
        }
    }
}
