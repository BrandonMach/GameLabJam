using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Animator> anim;
    PlayerMovment playerMovementScript;
    void Start()
    {
        playerMovementScript = this.GetComponent<PlayerMovment>();
    }

    // Update is called once per frame
    void Update()
    {
        //anim 0 = walk animation
        for (int i = 0; i < anim.Count; i++)
        {
            anim[i].SetFloat("Speed", Mathf.Abs(playerMovementScript.horizontalinput));
        }
      
    }
}
