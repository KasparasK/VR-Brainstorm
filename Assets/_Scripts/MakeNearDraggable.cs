using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    public static void MakeNearDraggable(GameObject target)
    {
        // Instantiate and add grabbable
        target.AddComponent<NearInteractionGrabbable>();

        // Add ability to drag by re-parenting to pointer object on pointer down
        var pointerHandler = target.AddComponent<PointerHandler>();
        pointerHandler.OnPointerDown.AddListener((e) =>
        {
            if (e.Pointer is SpherePointer)
            {
                target.transform.parent = ((SpherePointer)(e.Pointer)).transform;
            }
        });
        pointerHandler.OnPointerUp.AddListener((e) =>
        {
            if (e.Pointer is SpherePointer)
            {
                target.transform.parent = null;
            }
        });
    }
}
