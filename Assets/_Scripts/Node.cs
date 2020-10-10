using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using TMPro;
using UnityEngine;
[RequireComponent(typeof(NearInteractionTouchableVolume))]
public class Node : MonoBehaviour, IMixedRealityTouchHandler, IMixedRealityPointerHandler
{
    public GameObject self;
    public NodeSync nodeSync;

    public Material selected;
    public Material notSelected;
    public Material touching;

    public TMP_Text name;

    public MeshRenderer meshRenderer;

    private List<Node> _connections;
    private List<Node> connections
    {
        get
        {
            if(_connections == null)
                _connections = new List<Node>();

            return _connections;
        }
        set { _connections = value; }
    }


    public LineRenderer lineRenderer;

    public Action<Node> onTouchStart;
    public Action<Node> onTouchEnd;

    private float lastTouchEndTime;
    private const float minTimeBetweenTouchEnd = 0.1f;


    void Start()
    {
        lastTouchEndTime = Time.time;
        StartCoroutine(SlowUpdate());
    }

    public int AddConnection(Node node)
    {

        if(node == this) //connection with self
            return -1;

        if (connections.Contains(node)) //connection exists
            return -2;

        connections.Add(node);
        RefreshConnections();
        return 1;
    }

    public void RemoveConnection(Node node)
    {
        connections.Remove(node);
        RefreshConnections();
    }

    public void RemoveAllConnections()
    {
        for (int i = 0; i < connections.Count; i++)
        {
            connections[i].RemoveConnection(this);
            
        }
        connections.Clear();

        RefreshConnections();
    }



    void RefreshConnections()
    {
        Vector3[] newPositions = new Vector3[connections.Count+1];

        int i = 0;
        for (i = 0; i < connections.Count;i++)
        {
            newPositions[i] = connections[i].self.transform.position;
        }
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

    IEnumerator SlowUpdate()
    {
        while (true)
        {
            RefreshConnections();
        //    yield return new WaitForSeconds(0.05f);
         yield return new WaitForEndOfFrame();
        }
    }

    #region Touch
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
        if (!NodeManager.allowDragging )
        {
            if (Time.time - lastTouchEndTime >= minTimeBetweenTouchEnd)
            {

                onTouchEnd?.Invoke(this);

                lastTouchEndTime = Time.time;

                SetMaterial(notSelected);

            }


        }
    }

    public void Rename(string text)
    {
        nodeSync.Rename(text);
        name.text = text;
    }

    public void OnTouchUpdated(HandTrackingInputEventData eventData)
    {
        if (!NodeManager.allowDragging)
        {

        }

        // throw new System.NotImplementedException();
    }


    #endregion

    #region Grab

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

    #endregion
}
