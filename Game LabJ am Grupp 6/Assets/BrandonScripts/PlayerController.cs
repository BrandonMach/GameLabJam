using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    PlayerMovment playerMovementScript;
    void Start()
    {
        playerMovementScript = this.GetComponent<PlayerMovment>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs( playerMovementScript.horizontalinput));
    }
}
