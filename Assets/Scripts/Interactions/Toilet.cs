using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toilet : InteractableObject
{
    public override void Interact()
    {
        base.Interact();
        if (_playerAnimator != null)
            _playerAnimator.SetTrigger("Interact");
        Debug.Log("Toilet used!");
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        

    }
    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);

        

    }
}
