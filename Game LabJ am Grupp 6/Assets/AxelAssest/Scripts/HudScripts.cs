using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudScripts : MonoBehaviour
{
    public MindScript mindScript;
    public GameObject duckPanel, fishPanel, duckIcons, fishIcons;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (mindScript.characterIndex % 2 == 0)
        {
            duckPanel.SetActive(true);
            duckIcons.SetActive(true);
            fishIcons.SetActive(false);
            fishPanel.SetActive(false);
        }
        else if(mindScript.characterIndex % 2 == 1)
        {
            duckPanel.SetActive(false);
            duckIcons.SetActive(false);
            fishIcons.SetActive(true);
            fishPanel.SetActive(true);
        }
    }
}
