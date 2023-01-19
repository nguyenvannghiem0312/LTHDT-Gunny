using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Character : MonoBehaviour1
{
    static bool isCharacter1 = false;
    static bool isCharacter2 = false;
    public GameObject Character1;
    public GameObject Character2;
    public void SetTurn()
    {
        if(isCharacter1 == true)
        {
            Character1.GetComponent<Character1>().enabled = true;
            Character2.GetComponent<Character2>().enabled = false;
            // Debug.Log("Turn 1");
        }
        else if(isCharacter2 == true)
        {
            Character1.GetComponent<Character1>().enabled = false;
            Character2.GetComponent<Character2>().enabled = true;
            // Debug.Log("Turn 2");
        }
    }

    public void ChangeTurn()
{     
        bool isTurn = isCharacter1;
        isCharacter1 = isCharacter2;
        isCharacter2 = isTurn;
        SetTurn();
    }
    // Start is called before the first frame update
    void Start()
    {
        isCharacter1 = true;
        SetTurn();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Cancel"))
        {
            ChangeTurn();
        }
    }
}
