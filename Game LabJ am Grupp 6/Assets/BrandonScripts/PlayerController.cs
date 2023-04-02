using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Animator> anim;
    public GameObject[] characters;
    PlayerMovment playerMovementScript;
    void Start()
    {
        playerMovementScript = this.GetComponent<PlayerMovment>();
    }
    public void Awake()
    {
        anim = new List<Animator>();
        for (int i = 0; i < characters.Length; i++)
        {
            anim.Add(characters[i].GetComponent<Animator>());
        }
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
