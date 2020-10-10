using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class NodeSync : RealtimeComponent
{
    public Node node;
    private NodeModel _model;
    private NodeModel model
    {
        set
        {
            if (_model != null)
            {
                // Unregister from events
                _model.nameDidChange -= NameDidChange;
                _model.connectionPosADidChange -= ConnectionPosADidChange;
                _model.connectionPosBDidChange -= ConnectionPosBDidChange;
            }

            // Store the model
            _model = value;

            if (_model != null)
            {
                // Update the mesh render to match the new model
                //UpdateMeshRendererColor();

                // Register for events so we'll know if the color changes later
                _model.nameDidChange += NameDidChange;
                _model.connectionPosADidChange += ConnectionPosADidChange;
                _model.connectionPosBDidChange += ConnectionPosBDidChange;
            }
        }
    }
    private void NameDidChange(NodeModel model, string value)
    {
        node.Rename(_model.name);
    }
    private void ConnectionPosADidChange(NodeModel model, Vector3 value)
    {

    }
    private void ConnectionPosBDidChange(NodeModel model, Vector3 value)
    {

    }
    public void Rename(string n)
    {
        _model.name = n;
    }
}
