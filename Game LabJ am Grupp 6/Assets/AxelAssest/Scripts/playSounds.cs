using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class playSounds : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource source;
    int counter;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            counter++;
            source.clip = clips[counter % 3];
            source.Play();
        }
    }
}
