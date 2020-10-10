using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectToPlayerCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        NodeManager.Instance.canvasFollowHand.ConnectToTarget(gameObject);
    }
}
