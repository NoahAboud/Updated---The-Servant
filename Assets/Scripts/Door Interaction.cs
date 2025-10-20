using TMPro; // For TextMeshPro
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public Transform door;         // Assign the door model
    public TextMeshProUGUI messageText; // Assign in Inspector
    private bool isInRange = false;
    private bool isOpen = false;

    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.D))
        {
            TryOpenDoor();
        }
    }

    void TryOpenDoor()
    {
        if (PlayerInventory.hasKey)
        {
            if (!isOpen)
            {
                Debug.Log("Door opened!");
                // Example: rotate door to open
                door.rotation = Quaternion.Euler(0, 90, 0);
                isOpen = true;
                messageText.text = "";
            }
        }
        else
        {
            StartCoroutine(ShowMessage("You need a key to open this door!"));
        }
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

    private System.Collections.IEnumerator ShowMessage(string text)
    {
        messageText.text = text;
        yield return new WaitForSeconds(2f);
        messageText.text = "";
    }
}

