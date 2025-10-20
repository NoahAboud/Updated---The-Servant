using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public string itemName = "Key";  // Name of the item
    private bool isInRange = false;

    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            CollectKey();
        }
    }

    void CollectKey()
    {
        Debug.Log("Key collected!");
        PlayerInventory.hasKey = true;
        gameObject.SetActive(false);  // Hide or destroy key after pickup
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            isInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isInRange = false;
    }
}
