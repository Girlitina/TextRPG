using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    void Awake()
    {
        BuildItemDatabase();
    }

    public Item GetItem(int id)
    {
        return items.Find(item => item.id == id);
    }

    public Item GetItem(string title)
    {
        return items.Find(item => item.title == title);
    }

    void BuildItemDatabase()
    {
        items = new List<Item>()
        {
            new Item(1, "Diamod Sword", "Sword made of diamond",
            new Dictionary<string, int> {
                { "Power", 15}
            }),
            new Item(2, "Diamod Ore", "Shiny diamond",
            new Dictionary<string, int> {
                { "Value", 250}
            }),
            new Item(3, "Iron Sword", "Sword made of iron",
            new Dictionary<string, int> {
                { "Power", 8},
                { "Defense", 10 }
            })
        };
    }
}
