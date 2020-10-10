using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFollowHand : MonoBehaviour
{
    private bool setup = true;
    public GameObject canvases;
    private GameObject target;
    public void ConnectToTarget(GameObject target)
    {
        this.target = target;
        GetComponentInChildren<UIManager>().origin = target;

        setup = true;
        canvases.SetActive(true);
    }


    void Update()
    {
        if (setup)
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime *7);
            transform.rotation = Quaternion.Lerp(transform.rotation, target.transform.rotation, Time.deltaTime * 7);

        }
    }
}
