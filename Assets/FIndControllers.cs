using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class FIndControllers : MonoBehaviour
{
    public RealtimeAvatarManager manager;
    public GameObject[] controllers;
    public GameObject[] cubes;
    int a = 0;
    // Start is called before the first frame update
    void Start()
    {
        manager.localAvatar.localPlayer.root = GameObject.Find("MRTK-Quest_OVRCameraRig(Clone)").transform;
        manager.localAvatar.localPlayer.root = GameObject.Find("MRTK-Quest_OVRCameraRig(Clone)").transform.Find("CenterEyeAnchor").transform;
    }

    // Update is called once per frame
    void Update()
    {
        controllers[0] = GameObject.Find("Right_HandRight(Clone)").transform.Find("Wrist Proxy Transform").gameObject;
        controllers[1] = GameObject.Find("Left_HandLeft(Clone)").transform.Find("Wrist Proxy Transform").gameObject;

        if (controllers[0] != null) 
        {
            cubes[0].transform.position = controllers[0].transform.position;
            cubes[0].transform.rotation= controllers[0].transform.rotation;
        }
        if (controllers[1] != null)
        {
            cubes[1].transform.position = controllers[1].transform.position;
            cubes[1].transform.rotation = controllers[1].transform.rotation;
        }

    }
}
