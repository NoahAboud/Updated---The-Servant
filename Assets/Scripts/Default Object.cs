using UnityEngine;
public enum ItemType { Equipment, Weapons, Quests }

[CreateAssetMenu(fileName = "New Default Object", menuName = "Inventory System/Items")]

public class Item : ScriptableObject
{
    public string itemName;
    public ItemType type;
    public Sprite icon;
    public bool isStackable;
    public int maxStack = 99;

}
