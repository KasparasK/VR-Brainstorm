using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Interactable dragModeToggle;

    // Start is called before the first frame update
    public void NewNodeClicked()
    {
        NodeManager.Instance.CreateNewNode(transform.position);
    }

    public void ToggleDrag()
    {
        NodeManager.allowDragging = dragModeToggle.IsToggled;
    }
}
