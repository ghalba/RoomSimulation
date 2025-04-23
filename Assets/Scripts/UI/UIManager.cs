using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject interactCanvasPrefab;
    private GameObject currentCanvasInstance;
    private InteractableObject currentTarget;
    //private Button interactButton;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void ShowInteractCanvas(InteractableObject target)
    {
        if (currentCanvasInstance == null)
        {
            currentCanvasInstance = Instantiate(interactCanvasPrefab);
        }

        currentTarget = target;

        currentCanvasInstance.SetActive(true);
        currentCanvasInstance.transform.position = target.transform.position + Vector3.up * 2f;
        currentCanvasInstance.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward); // Face player

        /*if (interactButton == null)
        {
            interactButton = currentCanvasInstance.GetComponentInChildren<Button>();
            interactButton.onClick.AddListener(() =>
            {
                if (currentTarget != null)
                {
                    currentTarget.Interact();
                    HideInteractCanvas();
                }
            });
        }*/
    }

    public void HideInteractCanvas()
    {
        if (currentCanvasInstance != null)
        {
            currentCanvasInstance.SetActive(false);
            currentTarget = null;
        }
    }

    private void Update()
    {
        if (currentCanvasInstance != null && currentCanvasInstance.activeSelf && currentTarget != null)
        {
            currentCanvasInstance.transform.position = currentTarget.transform.position + Vector3.up * 2f;
            currentCanvasInstance.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
        }
    }
}
