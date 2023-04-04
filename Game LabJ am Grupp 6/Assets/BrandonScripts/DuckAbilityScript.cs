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
    public PlayerMovment playerMovementScript;
    float flapDuration = 0.5f;
    public PlayerController playerContorllerScript;
    public GameObject windObject;

    void Start()
    {

        windBox.enabled = false;
        windObject.SetActive(false);
        playerMovementScript = GetComponent<PlayerMovment>();
        playerContorllerScript = GetComponent<PlayerController>();
    }

    private void Update()
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
        if (Input.GetKeyDown(KeyCode.J) && !useFlabAbility)
        {
            playerContorllerScript.anim[0].SetBool("Flap", true);
            windBox.enabled = true;
            windObject.SetActive(true);
            useFlabAbility = true;
        }
        if (useFlabAbility)
        {

            flapDuration -= Time.deltaTime;
            if (flapDuration <= 0)
            {
                useFlabAbility = false;
                windBox.enabled = false;
                playerContorllerScript.anim[0].SetBool("Flap", false);
                windObject.SetActive(false);
                flapDuration = 0.5f;
            }
        }
    }
}
