using System.Collections.Generic;

public class Inventory : Singleton<Inventory>
{
    private List<ItemData> items = new List<ItemData>();

    public void AddItem(ItemData item)
    {
        items.Add(item);
    }
}
