using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInteractable : MonoBehaviour
{
    public static event EventHandler OnAnyColorPlacedHere;
    [SerializeField] private Transform interactableTransformPoint;

    //private ColorObject colorObject;

    public static void ResetStaticData()
    {
        OnAnyColorPlacedHere = null;
    }

    public virtual void Interact(AnimationAndMovementController player)
    {
        Debug.LogError("BaseCounter.Interact();");
    }

    public Transform GetColorObjectFollowTransform()
    {
        return interactableTransformPoint;
    }

    /*public void SetColorObject(ColorObject colorObject)
    {
        this.colorObject = kitchenObject;

        if (kitchenObject != null)
        {
            OnAnyColorPlacedHere?.Invoke(this, EventArgs.Empty);
        }
    }

    public ColorObject GetColorObject()
    {
        return colorObject;
    }

    public void ClearColorObject()
    {
        colorObject = null;
    }

    public bool HasColorObject()
    {
        return colorObject != null;
    }*/
}
