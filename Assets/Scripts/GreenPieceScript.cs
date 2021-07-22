using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPieceScript : MonoBehaviour
{
    public Rigidbody rb;
    private GameObject gb;

    public GameObject lastHit;

    public Vector3 col = Vector3.zero;

    private RaycastHit click;

    public bool inBlue;

    public bool inRed;

    public bool inGreen;

    public bool inYellow;
    public LayerMask layer;

    public GameObject[] spots;

    private DiceZone DiceZone;

    private DiceScript DiceScript;

    private RedPieceScript RedPieceScript;
    private GameManager GameManager;

    public float diceValue = 0;

    private GameObject redpiece1;

    private GameObject redpiece2;
    private GameObject redpiece3;
    private GameObject redpiece4;

    private GameObject redhome1;
    private GameObject redhome2;
    private GameObject redhome3;
    private GameObject redhome4;

    private GameObject bluepiece1;

    private GameObject bluepiece2;
    private GameObject bluepiece3;
    private GameObject bluepiece4;

    private GameObject bluehome1;
    private GameObject bluehome2;
    private GameObject bluehome3;
    private GameObject bluehome4;

    private GameObject  yellowpiece1;

    private GameObject yellowpiece2;
    private GameObject yellowpiece3;
    private GameObject yellowpiece4;

    private GameObject yellowhome1;
    private GameObject yellowhome2;
    private GameObject yellowhome3;
    private GameObject yellowhome4;

    public bool isTurn;

    int piecePos;

    public int turnCount;

    private bool canRoll;

    private float greenWin;

    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gb = GameObject.Find("Spot27");
        DiceZone = GameObject.Find("DiceCheck").GetComponent<DiceZone>();

        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        DiceScript = GameObject.Find("Dice").GetComponent<DiceScript>();

        redpiece1 = GameObject.Find("RedPiece1");
        redhome1 = GameObject.Find("RedHome1");
        redpiece2 = GameObject.Find("RedPiece2");
        redhome2 = GameObject.Find("RedHome2");
        redpiece3 = GameObject.Find("RedPiece3");
        redhome3 = GameObject.Find("RedHome3");
        redpiece4 = GameObject.Find("RedPiece4");
        redhome4 = GameObject.Find("RedHome4");

        bluepiece1 = GameObject.Find("BluePiece1");
        bluehome1 = GameObject.Find("blueHome1");
        bluepiece2 = GameObject.Find("BluePiece2");
        bluehome2 = GameObject.Find("blueHome2");
        bluepiece3 = GameObject.Find("BluePiece3");
        bluehome3 = GameObject.Find("blueHome3");
        bluepiece4 = GameObject.Find("BluePiece4");
        bluehome4 = GameObject.Find("blueHome4");

        yellowpiece1 = GameObject.Find("YellowPiece1");
        yellowhome1 = GameObject.Find("YellowHome1");
        yellowpiece2 = GameObject.Find("YellowPiece2");
        yellowhome2 = GameObject.Find("YellowHome2");
        yellowpiece3 = GameObject.Find("YellowPiece3");
        yellowhome3 = GameObject.Find("YellowHome3");
        yellowpiece4 = GameObject.Find("YellowPiece4");
        yellowhome4 = GameObject.Find("YellowHome4");
        
        
    }

   

    // Update is called once per frame
    void Update()
    {
        diceValue = DiceZone.diceValue;
        turnCount = GameManager.turnCount;
        canRoll = DiceScript.canRoll;
        if (turnCount == 3)
        {
            isTurn = true;
        }
        else
        {
            isTurn = false;
        }

        greenWin = GameManager.greenWin;
    } 
    void OnMouseOver(){
        if(Input.GetMouseButtonDown(0) && inGreen && diceValue == 6 && isTurn && !canRoll){
            transform.position  = gb.GetComponent<Rigidbody>().position;
            piecePos = 0;
            GameManager.turnCount = 4;
            DiceScript.canRoll = true;
        }

        else if(inGreen && diceValue != 6 && isTurn && !canRoll)
        {
            GameManager.turnCount = 4;
            DiceScript.canRoll = true;
        }
       
        if(Input.GetMouseButtonDown(0) && !inGreen && isTurn && !canRoll){
            transform.position  = spots[piecePos + (int)diceValue].GetComponent<Rigidbody>().position;
            piecePos = piecePos + (int)diceValue;
            GameManager.turnCount = 4;
            DiceScript.canRoll = true;
            if (transform.position == redpiece1.transform.position)
            {
                redpiece1.transform.position = redhome1.GetComponent<Rigidbody>().position;
            }
            if (transform.position == redpiece2.transform.position)
            {
                redpiece2.transform.position = redhome2.GetComponent<Rigidbody>().position;
            }
            if (transform.position == redpiece3.transform.position)
            {
                redpiece3.transform.position = redhome3.GetComponent<Rigidbody>().position;
            }
            if (transform.position == redpiece4.transform.position)
            {
                redpiece4.transform.position = redhome4.GetComponent<Rigidbody>().position;
            }


            if (transform.position == bluepiece1.transform.position)
            {
                bluepiece1.transform.position = bluehome1.GetComponent<Rigidbody>().position;
            }
            if (transform.position == bluepiece2.transform.position)
            {
                bluepiece2.transform.position = bluehome2.GetComponent<Rigidbody>().position;
            }
            if (transform.position == bluepiece3.transform.position)
            {
                bluepiece3.transform.position = bluehome3.GetComponent<Rigidbody>().position;
            }
            if (transform.position == bluepiece4.transform.position)
            {
                bluepiece4.transform.position = bluehome4.GetComponent<Rigidbody>().position;
            }


            if (transform.position == yellowpiece1.transform.position)
            {
                yellowpiece1.transform.position = yellowhome1.GetComponent<Rigidbody>().position;
            }
            if (transform.position == yellowpiece2.transform.position)
            {
                yellowpiece2.transform.position = yellowhome2.GetComponent<Rigidbody>().position;
            }
            if (transform.position == yellowpiece3.transform.position)
            {
                yellowpiece3.transform.position = yellowhome3.GetComponent<Rigidbody>().position;
            }
            if (transform.position == yellowpiece4.transform.position)
            {
                yellowpiece4.transform.position = yellowhome4.GetComponent<Rigidbody>().position;
            }
        }
       
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "greenHome")
        {
            inGreen = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "greenHome")
        {
            inGreen = false;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GreenFinish")
        {
            GameManager.greenWin -= 1;
        }

    }


}
