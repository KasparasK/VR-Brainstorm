using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;
[RequireComponent(typeof(NearInteractionTouchableVolume))]
public class Node : MonoBehaviour, IMixedRealityTouchHandler, IMixedRealityPointerHandler
{
    public GameObject self;
    private List<Transform> _connections;

    public Material selected;
    public Material notSelected;
    public Material touching;

    public MeshRenderer meshRenderer;

    private List<Transform> connections
    {
        get
        {
            if(_connections == null)
                _connections = new List<Transform>();

            return _connections;
        }
        set { _connections = value; }
    }


    public LineRenderer lineRenderer;

    public Action<Node> onTouchStart;
    public Action<Node> onTouchEnd;



    public int AddConnection(Node node)
    {
        GameObject toAdd = node.self;

        if(toAdd == self) //connection with self
            return -1;

        if (connections.Contains(toAdd.transform)) //connection exists
            return -2;

        connections.Add(toAdd.transform);
        RefreshConnections();
        return 1;
    }

    public void RemoveConnection(Node node)
    {
        connections.Remove(node.transform);
        RefreshConnections();
    }

    void RefreshConnections()
    {
        Vector3[] newPositions = new Vector3[connections.Count+1];


        int i = 0;
        for (i = 0; i < connections.Count;i++)
        {
            newPositions[i] = connections[i].position;
        }
        Debug.Log(i);

        newPositions[i] = transform.position;

        lineRenderer.positionCount = newPositions.Length;
        lineRenderer.SetPositions(newPositions);

    }

    public void Select()
    {
        SetMaterial(selected);
    }

    public void Deselect()
    {
        SetMaterial(notSelected);
    }

    void SetMaterial(Material mat)
    {
        meshRenderer.sharedMaterial = mat;
    }

    #region Touch

    

    #endregion
    public void OnTouchStarted(HandTrackingInputEventData eventData)
    {
        if (!NodeManager.allowDragging)
        {
            SetMaterial(touching);

            onTouchStart?.Invoke(this);
        }
    }

    public void OnTouchCompleted(HandTrackingInputEventData eventData)
    {
        if (!NodeManager.allowDragging)
        {
            SetMaterial(notSelected);

            onTouchEnd?.Invoke(this);
        }
    }

    public void OnTouchUpdated(HandTrackingInputEventData eventData)
    {
        if (!NodeManager.allowDragging)
        {

        }

        // throw new System.NotImplementedException();
    }


    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        if (!NodeManager.allowDragging)
        {

        }
        //  throw new NotImplementedException();
    }

    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {
        if (NodeManager.allowDragging)
        {
            transform.position = eventData.Pointer.Position;

        }
    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
        if (NodeManager.allowDragging)
        {

        }
        //   throw new NotImplementedException();
    }

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        if (NodeManager.allowDragging)
        {

        }
        //  throw new NotImplementedException();
    }
}
