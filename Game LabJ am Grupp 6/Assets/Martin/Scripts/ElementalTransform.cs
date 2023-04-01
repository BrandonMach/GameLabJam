using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ElementalTransform : MonoBehaviour
{
    public enum ElementalState { gas = 0, water = 1, ice = 2};
    public ElementalState currentState;

    [SerializeField] GameObject ice;
    [SerializeField] GameObject water;
    [SerializeField] GameObject gas;

    [SerializeField] public static int waterMeter = 10;

    private bool canChangeState = true;

    [SerializeField] private float speedDownInWater = 2f;

    
    // Start is called before the first frame update
    void Start()
    {
        currentState = ElementalState.water;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0) && canChangeState)
        {
            currentState++;

            if (currentState > ElementalState.ice)
            {
                currentState = 0;
            }
            ChangeState(currentState);
        }

        if (currentState == ElementalState.gas)
        {
            
        }


        if (this.transform.GetChild(2).GetComponent<IceScript>().icePillars.Count > 0)
        {
            for (int i = 0; i < this.transform.GetChild(2).GetComponent<IceScript>().icePillars.Count; i++)
            {
                if (this.transform.GetChild(2).GetComponent<IceScript>().icePillars[i].GetComponent<IcePillar>().Health < 0)
                {
                    Destroy(this.transform.GetChild(2).GetComponent<IceScript>().icePillars[i]);
                    this.transform.GetChild(2).GetComponent<IceScript>().icePillars.RemoveAt(i);
                }
            }
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
        water.SetActive(true);
        ice.SetActive(false);
        gas.SetActive(false);
    }

    public void IceState()
    {
        water.SetActive(false);
        ice.SetActive(true);
        gas.SetActive(false);
    }

    public void GasState()
    {
        water.SetActive(false);
        ice.SetActive(false);
        gas.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 && currentState == ElementalState.gas)
        {
            canChangeState = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 && currentState == ElementalState.gas)
        {
            canChangeState = false;
        }

        if (collision.CompareTag("Water"))
        {
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.down * Time.deltaTime * speedDownInWater);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 && currentState == ElementalState.gas)
        {
            canChangeState = true;
        }
    }
}
