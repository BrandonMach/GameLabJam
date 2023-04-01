using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckAbilityScript : MonoBehaviour
{
    // Start is called before the first frame update
    //Flapping
    [Header("Flapp Ability")]
    public AreaEffector2D windBox;
    bool useFlabAbility = false;
    PlayerMovment playerMovementScript;
    float flapDuration = 0.5f;
    

    void Start()
    {
        windBox.enabled = false;
        playerMovementScript = GetComponent<PlayerMovment>();
    }

    // Update is called once per frame
    void Update()
    {

        if (playerMovementScript.isFaceingRight)
        {
            windBox.forceAngle = 0;
        }
        else
        {
            windBox.forceAngle = 180;
        }
       
        //Timer
        if (Input.GetKeyDown(KeyCode.L) && !useFlabAbility)
        {
            windBox.enabled = true;
            useFlabAbility = true;
        }
        if (useFlabAbility)
        {
            flapDuration -= Time.deltaTime;
            if(flapDuration <= 0)
            {
                useFlabAbility = false;
                windBox.enabled = false;
                flapDuration = 1;
            }
        }
    }
}
