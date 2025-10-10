using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float PlayerDistance;
    Interactable currentInteractable;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        CheckInteraction();
        if (Input.GetKeyDown(KeyCode.R) && currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }

    void CheckInteraction()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        if (Physics.Raycast(ray, out hit, PlayerDistance))
        {
            if (hit.collider.tag == "Interactable")
            {
                Interactable newInteractable = hit.collider.GetComponent<Interactable>();

                if (newInteractable.enabled)
                {
                    SetNewCurrentInteractable(newInteractable);
                }
                else
                {
                    DisableCurrentInteractable();
                }
            }
        }
        else
        {
            DisableCurrentInteractable();
        }
        void SetNewCurrentInteractable(Interactable newinteractable)
        {
            currentInteractable = newinteractable;
            currentInteractable.EnableOutline();
        }

        void DisableCurrentInteractable()
        {
            if (currentInteractable)
            {
                currentInteractable.DisableOutline();
                currentInteractable = null;
            }
        }
    }
}
