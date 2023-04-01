using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject waterDroplet;

    List<GameObject> waterDroplets;

    [SerializeField] int amountOfWaterDroplets = 1000;

    private GameObject newGameObjectWaterDroplets;
    void Start()
    {
        waterDroplets = new List<GameObject>();

        newGameObjectWaterDroplets = new GameObject();
        newGameObjectWaterDroplets.name = "Water droplets";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Vector2 newPosition = this.transform.position;

            newPosition.x = newPosition.x - (this.transform.parent.localScale.x * 1.2f);

            for (int i = 0; i < amountOfWaterDroplets; i++)
            {
                waterDroplets.Add(Instantiate(waterDroplet, newPosition, this.transform.rotation, newGameObjectWaterDroplets.transform));
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            for (int i = 0; i < waterDroplets.Count; i++)
            {
                Destroy(waterDroplets[i]);
            }
            waterDroplets.Clear();
            waterDroplets = new List<GameObject>();
        }
    }
}
