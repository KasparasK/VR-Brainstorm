using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class AssignReferences : MonoBehaviour
{
    public RealtimeAvatarManager manager;
    public Transform head;
    public Transform handL;
    public Transform handR;
    public Transform headRef;
    public Transform handLRef;
    public Transform handRRef;
    public GameObject root;
    // Start is called before the first frame update
    void Start()
    {
        root = GameObject.Find("MRTK-Quest_OVRCameraRig(Clone)");
        headRef = GameObject.Find("CenterEyeAnchor").transform;
        handLRef = GameObject.Find("LeftControllerAnchor").transform;
        handRRef = GameObject.Find("RightControllerAnchor").transform;
    }
    private void Update()
    {
        head.position = headRef.position;
        head.rotation = headRef.rotation;

        handL.position = handLRef.position;
        handL.rotation = handLRef.rotation;

        handR.position = handRRef.position;
        handR.rotation = handRRef.rotation;
    }
}
