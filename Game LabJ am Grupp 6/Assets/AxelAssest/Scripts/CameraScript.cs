using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    MindScript mindScript;
    CinemachineVirtualCamera vcam;
    void Start()
    {
        mindScript = GameObject.Find("SwitchCharacterManager").GetComponent<MindScript>();
        vcam = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        vcam.Follow = mindScript.playerCharacters[mindScript.characterIndex % 2].gameObject.transform;
    }
}
