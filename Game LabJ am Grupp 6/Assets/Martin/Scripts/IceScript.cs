using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ElementalTransform;

public class IceScript : MonoBehaviour
{
    // Start is called before the first frame update

    private float iceSizeX = 2;

    public List<GameObject> icePillars = new List<GameObject>();

    [SerializeField] private int icePillarCost = 2;

    private ElementalTransform parentScript;

    [SerializeField] GameObject icePillarPrefab;
    [SerializeField] PlayerController playerControllerScript;
    private bool spawnPillar = false;
    private bool destroyPillar = false;
    private float abilityDuration = 0.5f;

    void Start()
    {
        parentScript = this.transform.parent.GetComponent<ElementalTransform>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha8) && waterMeter >= icePillarCost && !spawnPillar)
        {
            playerControllerScript.anim[1].SetBool("IcePillar", true);    
            spawnPillar = true;
        }     
        if (spawnPillar)
        {
            abilityDuration -= Time.deltaTime;
            if (abilityDuration <= 0)
            {
                spawnPillar = false;
                playerControllerScript.anim[1].SetBool("IcePillar", false);
                abilityDuration = 0.5f;
                SpawnIcePillar();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            playerControllerScript.anim[1].SetBool("IcePillar", true);
            destroyPillar = true;
        }
        if (destroyPillar)
        {
            abilityDuration -= Time.deltaTime;
            if (abilityDuration <= 0)
            {
                destroyPillar = false;
                playerControllerScript.anim[1].SetBool("IcePillar", false);
                abilityDuration = 0.5f;
                RemoveIcePillar();
            }
        }
    }

    public void SpawnIcePillar()
    {
        Vector2 newPositionForPillar = this.transform.position;
        newPositionForPillar.y -= icePillarPrefab.transform.localScale.y - this.transform.localScale.y;
        icePillars.Add(Instantiate(icePillarPrefab, newPositionForPillar, this.transform.rotation));
        waterMeter -= icePillarCost;
    }

    public void RemoveIcePillar()
    {
        if (icePillars.Count > 0)
        {
            if (icePillars[0].GetComponent<IcePillar>().Health > 0)
            {
                waterMeter += icePillarCost / 2;
            }
            Destroy(icePillars[0]);
            icePillars.RemoveAt(0);
        }
    }
}
