using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    public Material nodeMat;
    public GameObject nodePref;

    public List<Node> nodes;

    Node selected;

    #region Instance
    private static NodeManager _instance;
    public static NodeManager Instance
    {
        get
        {
            if (_instance != null)
                return _instance;

            throw new Exception("SoundManager error: You request instance before class initialization.");
        }
    }

    void Awake()
    {

        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;//Avoid doing anything else
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    public static bool allowDragging;

    // Start is called before the first frame update
    void Start()
    {
        selected = null;
        nodes = new List<Node>();

      /*  CreateNewNode(new Vector3(0, 0.5f, 0.5f));
        CreateNewNode(new Vector3(0.5f, 0, 0.5f));
        CreateNewNode(new Vector3(0.5f, 0.5f, 0));*/

       /* Select(nodes[0]);
        Select(nodes[1]);

        Select(nodes[0]);
        Select(nodes[1]);*/

    }


     public void CreateNewNode(Vector3 pos)
    {
        GameObject node = Instantiate(nodePref, pos, Quaternion.identity);
        Node nodeScript = node.GetComponent<Node>();
        nodeScript.onTouchEnd += Select;
        node.name = "NODE " + nodes.Count;
        nodes.Add(nodeScript);
    }

    void Select(Node newSelection)
    {
     /*   if (selected != null)
        {
           int returnCode = selected.AddConnection(newSelection);

           if(returnCode == -2)
                selected.RemoveConnection(newSelection);

           selected.Deselect();
           selected = null;
        }
        else
        {
            selected = newSelection;
            selected.Select();
        }*/
        selected = newSelection;
        selected.Select();
    }

}
