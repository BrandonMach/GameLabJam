using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ElementalTransform;

public class IceScript : MonoBehaviour
{
    // Start is called before the first frame update

    private float iceSizeX = 2;

    private List<GameObject> icePillars = new List<GameObject>();

    private int icePillarCost = 4;

    private ElementalTransform parentScript;

    [SerializeField] GameObject icePillarPrefab;
    void Start()
    {
        parentScript = this.transform.parent.GetComponent<ElementalTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha8) && waterMeter >= icePillarCost)
        {
            SpawnIcePillar();
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            RemoveIcePillar();
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
            Destroy(icePillars[0]);
            icePillars.RemoveAt(0);

            waterMeter += icePillarCost / 2;
        }
    }
}
