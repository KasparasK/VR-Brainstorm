using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    public GameObject nodePref;
    public CanvasFollowHand canvasFollowHand;

    public List<Node> nodes;
    private List<Node> selected;
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

    public Action<string> log;

    // Start is called before the first frame update
    void Start()
    {
        nodes = new List<Node>();
        selected = new List<Node>();

       CreateNewNode(new Vector3(0, 0.5f, 0.5f));
        CreateNewNode(new Vector3(0.5f, 0, 0.5f));
        CreateNewNode(new Vector3(0.5f, 0.5f, 0));
        CreateNewNode(new Vector3(0, 0.5f, 0));
        CreateNewNode(new Vector3(0.5f, -0.5f, 0));


        Select(nodes[0]);
         Select(nodes[1]);
         Select(nodes[2]);
         Select(nodes[3]);
         Select(nodes[4]);

        ConnectSelected();
   //    RemoveConnectionsFromSelected();
         /* Select(nodes[0]);
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

     public void DeleteSelectedNodes()
     {

         for (int i = 0; i < selected.Count; i++)
         {
             selected[i].RemoveAllConnections();
             nodes.Remove(selected[i]);
            Destroy(selected[i].self);
         }
         selected.Clear();

    }

    void Select(Node newSelection)
    {
        //log?.Invoke("touch end\n");

        if(!selected.Contains(newSelection))
            selected.Add(newSelection);
        else
        {
            selected.Remove(newSelection);
            newSelection.Deselect();
        }


    }
    void FixedUpdate()
    {

        for (int i = 0; i < selected.Count; i++)
        {
            selected[i].Select();
        }
    }
    public void ConnectSelected()
    {

        for (int i = 0; i < selected.Count; i++)
        {
            for (int j = 0; j < selected.Count; j++)
            {
                if (j != i)
                {
                    selected[i].AddConnection(selected[j]);
                }
            }
        }

    }

    public void RemoveConnectionsFromSelected()
    {
        for (int i = 0; i < selected.Count; i++)
        {
            selected[i].RemoveAllConnections();
        }
    }

    public void RenameSelected(string text)
    {
        for (int i = 0; i < selected.Count; i++)
        {
            selected[i].Rename(text);
        }
    }

    public void DeselectSelected()
    {
        for (int i = 0; i < selected.Count; i++)
        {
            selected[i].Deselect();
        }
        selected.Clear();
    }
}
