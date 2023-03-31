using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float speed = 2f;

    Vector2 pushedDownPosition;

    Vector2 originalPosition;

    public enum PlateState { goingUp = 0, goingDown = 1, nothing = 2, down = 3 };
    public PlateState plateState;
    void Start()
    {
        pushedDownPosition = this.transform.position;
        pushedDownPosition.y -= this.transform.localScale.y;

        originalPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            plateState = PlateState.goingDown;
        }
        if (plateState == PlateState.goingDown)
        {
            this.transform.position = Vector2.Lerp(this.transform.position, pushedDownPosition, Time.deltaTime * speed);
            if (Vector2.Distance(this.transform.position, pushedDownPosition) < 0.01f)
            {

                plateState = PlateState.down;
            }

        }
        else if (plateState == PlateState.goingUp)
        {
            transform.position = Vector2.Lerp(this.transform.position, originalPosition, Time.deltaTime * speed);
            if (Vector2.Distance(this.transform.position, originalPosition) < 0.01f)
            {
                plateState = PlateState.nothing;
            }
        }
    }
}