using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public abstract class InteractableObject : MonoBehaviour
{
    [Header("Interaction Settings")]
    public NeedType needType;
    public float satisfactionAmount = 25f;
    public AudioClip interactionSound;
    public GameObject Vfx;
    protected Animator _playerAnimator;

    protected AudioSource audioSource;
    protected NeedManager needManager;
    

    protected virtual void Start()
    {
        audioSource = GetComponent<AudioSource>();
        needManager = FindObjectOfType<NeedManager>();
    }

    public virtual void Interact()
    {
        // 1. Satisfy the need
        if (needManager != null)
            needManager.SatisfyNeed(needType, satisfactionAmount);

        

        // 2. Play sound
        if (audioSource != null && interactionSound != null)
            audioSource.PlayOneShot(interactionSound);
        // 3. Play VFX
        if (Vfx != null)
        {
            GameObject vfxInstance = Instantiate(Vfx, transform.position, Quaternion.identity);
            Destroy(vfxInstance, 2f); // Destroy the VFX after 2 seconds
        }
    }


    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            _playerAnimator = other.GetComponent<Animator>();
            other.GetComponent<PlayerController>().SetCurrentInteractable(this);
        }
    }


    public virtual void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerAnimator = null;
            other.GetComponent<PlayerController>().ClearInteractable();
        }
    }
}
