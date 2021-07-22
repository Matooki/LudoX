using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceZone : MonoBehaviour
{
    Vector3 diceVelocity;


    private DiceScript DiceScript;

    public float diceValue = 0;

    void Awake()
    {
        DiceScript = GameObject.Find("Dice").GetComponent<DiceScript>();
    }
    
    void FixedUpdate()
    {
        diceVelocity = DiceScript.diceVelocity;
    }

    public void OnTriggerStay (Collider col)
    {
        if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f)
        {
            switch (col.gameObject.name)
            {
                case "Side1":
                diceValue = 6;
                break;
                case "Side2":
                diceValue = 5;
                break;
                case "Side3":
                diceValue = 4;
                break;
                case "Side4":
                diceValue = 3;
                break;
                case "Side5":
                diceValue = 2;
                break;
                case "Side6":
                diceValue = 1;
                break;


            }
        }
    }
    void Update()
    {
        
    }
}
