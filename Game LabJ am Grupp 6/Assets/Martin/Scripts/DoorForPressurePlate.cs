using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PressurePlate;

public class DoorForPressurePlate : MonoBehaviour
{
    [SerializeField] private GameObject pressurePlate;

    [SerializeField] float openingFloat;

    private bool isOpening = false;

    private Vector2 openingPosition;
    // Start is called before the first frame update
    void Start()
    {
        openingPosition = transform.position;

        if (openingFloat == 0)
        {
            openingPosition.y += transform.localScale.y;
        }
        else
        {
            openingPosition.y += openingFloat;

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (pressurePlate.GetComponent<PressurePlate>().hasCompleted == true)
        {
            pressurePlate.GetComponent<PressurePlate>().enabled = false;

            isOpening = true;
        }

        if (isOpening)
        {
            this.transform.position = Vector2.Lerp(this.transform.position, openingPosition, 1 * Time.deltaTime);

            if (Vector2.Distance(this.transform.position, openingPosition) < 0.01f)
            {
                isOpening = false;
            }
        }
    }
}