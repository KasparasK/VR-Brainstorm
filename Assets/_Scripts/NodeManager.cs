using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    public Material nodeMat;
    public GameObject nodePref;

    public List<Node> nodes;

    Node selected;

    // Start is called before the first frame update
    void Start()
    {
        selected = null;
        nodes = new List<Node>();

        CreateNewNode(new Vector3(0, 0.5f, 0.5f));
        CreateNewNode(new Vector3(0.5f, 0, 0.5f));
        CreateNewNode(new Vector3(0.5f, 0.5f, 0));

       /* Select(nodes[0]);
        Select(nodes[1]);

        Select(nodes[0]);
        Select(nodes[1]);*/

    }


    void CreateNewNode(Vector3 pos)
    {
        GameObject node = Instantiate(nodePref, pos, Quaternion.identity);
        Node nodeScript = node.GetComponent<Node>();
        nodeScript.onTouchEnd += Select;
        node.name = "NODE " + nodes.Count;
        nodes.Add(nodeScript);
    }

    void Select(Node newSelection)
    {
     
    
        if (selected != null)
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
        }

    }

}
