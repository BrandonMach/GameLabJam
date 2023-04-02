using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    float length, startPosx, startPosy;
    public GameObject cam;
    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        startPosx = transform.position.x;
        startPosy = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    private void Update()
    {
        float temp = (cam.transform.position.x) * (1 - parallaxEffect);
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startPosx + dist, startPosy, transform.position.z);

        if (temp > startPosx + length) startPosx += length;
        else if(temp < startPosx - length) startPosx -= length;
    }
}
