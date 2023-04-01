using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ElementalTransform : MonoBehaviour
{
    public enum ElementalState { gas = 0, water = 1, ice = 2};
    public ElementalState currentState;

    private float iceSizeX = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            currentState++;
            if (currentState > ElementalState.ice)
            {
                currentState = 0;
            }
            ChangeState(currentState);
        }
    }

    public void ChangeState(ElementalState currentState)
    {
        if (currentState == ElementalState.gas)
        {
            GasState();
        }
        else if (currentState == ElementalState.water)
        {
            WaterState();
        }

        else if (currentState == ElementalState.ice)
        {
            IceState();
        }
    }

    public void WaterState()
    {
    }

    public void IceState()
    {
        this.transform.localScale = new Vector3(iceSizeX, transform.localScale.y, 0);
    }

    public void GasState()
    {
        this.transform.localScale = new Vector3(1, transform.localScale.y, 0);
    }
}
