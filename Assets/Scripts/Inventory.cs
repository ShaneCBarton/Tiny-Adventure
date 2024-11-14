using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    private List<ItemData> items = new List<ItemData>();

    public void AddItem(ItemData item)
    {
        items.Add(item);
        Debug.Log("Item added to dummy inventory.");
    }
}
