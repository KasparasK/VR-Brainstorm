using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Interactable dragModeToggle;
    public TouchScreenKeyboard keyboard;

    // Start is called before the first frame update
    public GameObject origin;
    void Start()
    {
        NodeManager.Instance.log += Log;
    }
    public void NewNodeClicked()
    {
        NodeManager.Instance.CreateNewNode(origin.transform.position);
    }

    public void DestroySelectedNodesClicked()
    {
        
        NodeManager.Instance.DeleteSelectedNodes();
    }

    public void ConnectSelectedNodesClicked()
    {
      
        NodeManager.Instance.ConnectSelected();
    }

    public void RemoveConnectionsFromSelectedNodesClicked()
    {

        NodeManager.Instance.RemoveConnectionsFromSelected();
    }

    public void ToggleDrag()
    {

        NodeManager.allowDragging = dragModeToggle.IsToggled;
    }

    public void RenameSelectedClicked()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }

    public void DeselectAllClicked()
    {
        NodeManager.Instance.DeselectSelected();
    }

    void Update()
    {
        if (keyboard != null && keyboard.status == TouchScreenKeyboard.Status.Visible)
        {
            NodeManager.Instance.RenameSelected(keyboard.text);
        }
    }

    public void Log(string txt)
    {
    //    log.text += txt;

    }
}
