using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySlot
{
    public Item item;
    public int amount;

    public InventorySlot(Item item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }
}

public class Inventory : MonoBehaviour
{
    public int inventorySize = 20;
    public List<InventorySlot> slots = new List<InventorySlot>();

    public delegate void OnInventoryChanged();
    public OnInventoryChanged onInventoryChanged;

    public bool AddItem(Item item, int amount = 1)
    {
        // Check for stackable slot
        if (item.isStackable)
        {
            foreach (var slot in slots)
            {
                if (slot.item == item && slot.amount < item.maxStack)
                {
                    slot.amount += amount;
                    onInventoryChanged?.Invoke();
                    return true;
                }
            }
        }

        // Add new slot if space available
        if (slots.Count < inventorySize)
        {
            slots.Add(new InventorySlot(item, amount));
            onInventoryChanged?.Invoke();
            return true;
        }

        Debug.Log("Inventory full!");
        return false;
    }

    public void RemoveItem(Item item, int amount = 1)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].item == item)
            {
                slots[i].amount -= amount;
                if (slots[i].amount <= 0) slots.RemoveAt(i);
                onInventoryChanged?.Invoke();
                return;
            }
        }
    }
}