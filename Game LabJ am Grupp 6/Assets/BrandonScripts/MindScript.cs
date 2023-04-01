using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindScript : MonoBehaviour
{


    public GameObject[] playerCharacters;
    [SerializeField] GameObject currentPlayer;
    int characterIndex;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < playerCharacters.Length; i++)
        {
            playerCharacters[i].GetComponent<PlayerMovment>().enabled = false;
        }
        currentPlayer = playerCharacters[0];
        currentPlayer.GetComponent<PlayerMovment>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            characterIndex++;
            ChangeCharacter(playerCharacters[characterIndex%2]);
        }
    }

    public void ChangeCharacter(GameObject newCharacter)
    {
        currentPlayer.GetComponent<PlayerMovment>().enabled = false;
        currentPlayer = newCharacter;
        currentPlayer.GetComponent<PlayerMovment>().enabled = true;
    }
}
