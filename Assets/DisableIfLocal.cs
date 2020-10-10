using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class DisableIfLocal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (transform.root.GetComponent<RealtimeView>().isOwnedLocally)
        {
            gameObject.SetActive(false);
        }
    }
}
