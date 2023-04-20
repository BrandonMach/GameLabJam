using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudScripts : MonoBehaviour
{
    public MindScript mindScript;
    public ElementalTransform elementalScripts;
    public GameObject duckPanel, waterElemntalPanel, duckIcons, waterElementIcons,iceElemantalPanel, iceElementalIcon, gasElementalPanel,gasElementalIcon;
    // Start is called before the first frame update
    // Update is called once per frame
    private List<GameObject> duckHUD = new List<GameObject>();
    private List<GameObject> waterHUD = new List<GameObject>();
    private List<GameObject> iceHUD = new List<GameObject>();
    private List<GameObject> gasHUD = new List<GameObject>();

    private List<List<GameObject>> hudLists = new List<List<GameObject>>();

    private void Start()
    {



        duckHUD.Add(duckPanel);
        duckHUD.Add(duckIcons);
        waterHUD.Add(waterElemntalPanel);
        waterHUD.Add(waterElementIcons);
        iceHUD.Add(iceElemantalPanel);
        iceHUD.Add(iceElementalIcon);
        gasHUD.Add(gasElementalPanel);
        gasHUD.Add(gasElementalIcon);

        hudLists.Add(duckHUD);
        hudLists.Add(waterHUD);
        hudLists.Add(iceHUD);
        hudLists.Add(gasHUD);

        
        
    }

    void Update()
    {
        
        if (mindScript.characterIndex % 2 == 0)
        {
            SetDuck();
        }
        else if(mindScript.characterIndex % 2 == 1 && elementalScripts.currentState ==  ElementalTransform.ElementalState.water)
        {
            SetWaterElemnetal();
        } 
        else if(mindScript.characterIndex % 2 == 1 && elementalScripts.currentState == ElementalTransform.ElementalState.ice)
        {
            SetIceElemnetal();
        }
        else if(mindScript.characterIndex % 2 == 1 && elementalScripts.currentState == ElementalTransform.ElementalState.gas)
        {
            SetGasElemnetal();
        }

       
    }

    public void SetDuck()
    {
        foreach (List<GameObject> HUDItems in hudLists)
        {
            foreach (GameObject DuckHUDItems in duckHUD)
            {
                DuckHUDItems.SetActive(true);
            }
            foreach (GameObject WaterHUDItems in waterHUD)
            {
                WaterHUDItems.SetActive(false);
            }
            foreach (GameObject IceHUDItems in iceHUD)
            {
                IceHUDItems.SetActive(false);
            }
            foreach (GameObject GasHUDItems in gasHUD)
            {
                GasHUDItems.SetActive(false);
            }
        }
    }

    public void SetWaterElemnetal()
    {
        foreach (List<GameObject> HUDItems in hudLists)
        {
            foreach (GameObject DuckHUDItems in duckHUD)
            {
                DuckHUDItems.SetActive(false);
            }
            foreach (GameObject WaterHUDItems in waterHUD)
            {
                WaterHUDItems.SetActive(true);
            }
            foreach (GameObject IceHUDItems in iceHUD)
            {
                IceHUDItems.SetActive(false);
            }
            foreach (GameObject GasHUDItems in gasHUD)
            {
                GasHUDItems.SetActive(false);
            }
        }
    }
    public void SetIceElemnetal()
    {

        foreach (List<GameObject> HUDItems in hudLists)
        {
            foreach (GameObject DuckHUDItems in duckHUD)
            {
                DuckHUDItems.SetActive(false);
            }
            foreach (GameObject WaterHUDItems in waterHUD)
            {
                WaterHUDItems.SetActive(false);
            }
            foreach (GameObject IceHUDItems in iceHUD)
            {
                IceHUDItems.SetActive(true);
            }
            foreach (GameObject GasHUDItems in gasHUD)
            {
                GasHUDItems.SetActive(false);
            }
        }
    }
    public void SetGasElemnetal()
    {

        foreach (List<GameObject> HUDItems in hudLists)
        {
            foreach (GameObject DuckHUDItems in duckHUD)
            {
                DuckHUDItems.SetActive(false);
            }
            foreach (GameObject WaterHUDItems in waterHUD)
            {
                WaterHUDItems.SetActive(false);
            }
            foreach (GameObject IceHUDItems in iceHUD)
            {
                IceHUDItems.SetActive(false);
            }
            foreach (GameObject GasHUDItems in gasHUD)
            {
                GasHUDItems.SetActive(true);
            }
        }
    }
}
