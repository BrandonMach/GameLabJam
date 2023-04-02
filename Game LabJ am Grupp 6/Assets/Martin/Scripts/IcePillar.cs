using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePillar : MonoBehaviour
{
    // Start is called before the first frame update


    private Vector2 openingPosition;

    private Vector2 originalPosition;

    [SerializeField] private float health = 10;

    [SerializeField] private bool shouldTakeDamage = true;

    [SerializeField] private float deteriationSpeed = 1f;

    [SerializeField] private float upSpeed = 1f;
    [SerializeField] private float downSpeed = 0.25f;

    public bool shouldDie = false;

    public float Health
    {
        get { return health; }
    }
    void Start()
    {
        openingPosition = this.transform.position;

        openingPosition.y += transform.localScale.y/1.5f;

        originalPosition = this.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        

        if (shouldTakeDamage)
        {
            health -= Time.deltaTime * deteriationSpeed;
        }

        if (health < 0)
        {
            this.transform.position = Vector2.Lerp(this.transform.position, originalPosition, downSpeed * Time.deltaTime);
            if (Vector2.Distance(this.transform.position, originalPosition) < 0.1f)
            {
                shouldDie = true;
            }
        }
        else
        {
            this.transform.position = Vector2.Lerp(this.transform.position, openingPosition, upSpeed * Time.deltaTime);
        }
    }
}
