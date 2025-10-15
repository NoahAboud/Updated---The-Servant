using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Interaction : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI interactText; 
    private bool nearCar = false;

    void Update()
    {
        // Old Input Manager version
        if (nearCar && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E pressed! Loading scene...");
            SceneManager.LoadScene("Cutscene"); 
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("car"))
        {
            nearCar = true;
            if (interactText != null)
            {
                interactText.text = "Go Home (e)";
                interactText.gameObject.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("car"))
        {
            nearCar = false;
            if (interactText != null)
                interactText.gameObject.SetActive(false);
        }
    }
}