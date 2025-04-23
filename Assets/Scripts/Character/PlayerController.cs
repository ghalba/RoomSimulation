using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InteractableObject currentInteractable;

    void Update()
    {
        if (currentInteractable != null && Input.GetKeyDown(KeyCode.E))
        {
            currentInteractable.Interact();
        }
    }

    public void SetCurrentInteractable(InteractableObject obj)
    {
        currentInteractable = obj;
    }

    public void ClearInteractable()
    {
        currentInteractable = null;
    }
}
