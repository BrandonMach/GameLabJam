using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalTransform : MonoBehaviour
{
    public enum ElementalState { gas = 0, water = 1, ice = 2};
    public ElementalState currentState;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == ElementalState.gas)
        {

        }
        else if (currentState == ElementalState.water)
        {

        }
        else if (currentState == ElementalState.ice)
        {

        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log(currentState);
            currentState++;
            if (currentState == ElementalState.ice)
            {
                currentState = 0;
            }
            Debug.Log(currentState);
        }
    }
}
