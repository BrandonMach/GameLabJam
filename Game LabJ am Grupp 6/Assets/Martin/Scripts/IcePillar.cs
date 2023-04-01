using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePillar : MonoBehaviour
{
    // Start is called before the first frame update


    private Vector2 openingPosition;
    void Start()
    {
        openingPosition = this.transform.position;

        openingPosition.y += transform.localScale.y;

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector2.Lerp(this.transform.position, openingPosition, 1 * Time.deltaTime);
    }
}
