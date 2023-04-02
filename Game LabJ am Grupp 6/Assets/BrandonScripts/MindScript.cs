using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindScript : MonoBehaviour
{


    public GameObject[] playerCharacters;
    public GameObject[] elemntals;
    [SerializeField] GameObject currentPlayer;
    public int characterIndex;
    int currentCharacterIndex;

    Component[] allDuckScripts;
    Component[] allWaterScripts;
    Component[] iceElemntal;
    Component[] steamElemntal;
    Component[] waterElemntal;
    
    
    
    // Start is called before the first frame update
    void Start()
    {

        playerCharacters[(currentCharacterIndex + 1) % 2].GetComponent<PlayerMovment>().ArrowVisable(false);
        playerCharacters[currentCharacterIndex].GetComponent<PlayerMovment>().ArrowVisable(true);


        allDuckScripts = playerCharacters[0].GetComponents<MonoBehaviour>();
        allWaterScripts = playerCharacters[1].GetComponents<MonoBehaviour>();


        waterElemntal = elemntals[0].GetComponents<MonoBehaviour>();
        iceElemntal = elemntals[1].GetComponents<MonoBehaviour>();
        steamElemntal = elemntals[2].GetComponents<MonoBehaviour>();




        foreach (MonoBehaviour scripts in allDuckScripts)
        {
            scripts.enabled = true;
        }
        foreach (MonoBehaviour scripts in allWaterScripts)
        {
            scripts.enabled = false;
        }


        foreach (MonoBehaviour scripts in waterElemntal)
        {
            scripts.enabled = false;
        }
        foreach (MonoBehaviour scripts in iceElemntal)
        {
            scripts.enabled = false;
        }foreach (MonoBehaviour scripts in steamElemntal)
        {
            scripts.enabled = false;
        }

        playerCharacters[0].GetComponent<PlayerMovment>().canJump = true; //Only Duck can jump
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            characterIndex++;
            currentCharacterIndex = characterIndex % 2;
            playerCharacters[(currentCharacterIndex + 1) % 2].GetComponent<PlayerMovment>().ArrowVisable(false);
            playerCharacters[currentCharacterIndex].GetComponent<PlayerMovment>().ArrowVisable(true);
            // ChangeCharacter(playerCharacters[characterIndex%2]);
            if (characterIndex % 2 == 0)
            {
                playerCharacters[1].GetComponent<Rigidbody2D>().velocity = new Vector2(0,0) ;
                foreach (MonoBehaviour scripts in allDuckScripts)
                {
                    scripts.enabled = true;
                }
                foreach (MonoBehaviour scripts in allWaterScripts)
                {
                    scripts.enabled = false;
                }


                foreach (MonoBehaviour scripts in waterElemntal)
                {
                    scripts.enabled = false;
                }
                foreach (MonoBehaviour scripts in iceElemntal)
                {
                    scripts.enabled = false;
                }
                foreach (MonoBehaviour scripts in steamElemntal)
                {
                    scripts.enabled = false;
                }
            }
            else
            {
                playerCharacters[0].GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                foreach (MonoBehaviour scripts in allWaterScripts)
                {
                    scripts.enabled = true;
                }
                foreach (MonoBehaviour scripts in waterElemntal)
                {
                    scripts.enabled = true;
                }
                foreach (MonoBehaviour scripts in iceElemntal)
                {
                    scripts.enabled = true;
                }
                foreach (MonoBehaviour scripts in steamElemntal)
                {
                    scripts.enabled = true;
                }

                foreach (MonoBehaviour scripts in allDuckScripts)
                {
                    scripts.enabled = false;
                }
            }
        }
    }

}
