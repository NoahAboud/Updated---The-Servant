using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item; // Drag your KeyItem here in Inspector

    private void OnTriggerEnter(Collider other)
    {
        Inventory inventory = other.GetComponent<Inventory>();
        if (inventory != null)
        {
            inventory.AddItem(item);
            Destroy(gameObject); // remove the key from the scene
        }
    }
}
