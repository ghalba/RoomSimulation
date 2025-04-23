using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]

public class Clickable : MonoBehaviour
{
    private InteractableObject interactable;


    private void Awake()
    {
        interactable = GetComponent<InteractableObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.Instance.ShowInteractCanvas(interactable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.Instance.HideInteractCanvas();
        }
    }



}
