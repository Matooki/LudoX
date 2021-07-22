using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceScript : MonoBehaviour
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

    private bool canRoll;
    public LayerMask layer;

    public GameObject[] spots;

    private DiceZone DiceZone;

    private RedPieceScript RedPieceScript;

    private DiceScript DiceScript;

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

    private GameObject  yellowpiece1;
    private GameObject yellowpiece2;
    private GameObject yellowpiece3;
    private GameObject yellowpiece4;
    private GameObject yellowhome1;
    private GameObject yellowhome2;
    private GameObject yellowhome3;
    private GameObject yellowhome4;

    private GameObject greenpiece1;
    private GameObject greenpiece2;
    private GameObject greenpiece3;
    private GameObject greenpiece4;
    private GameObject greenhome1;
    private GameObject greenhome2;
    private GameObject greenhome3;
    private GameObject greenhome4;
    private GameObject bluepiece1;
    private GameObject bluepiece2;
    private GameObject bluepiece3;
    private GameObject bluepiece4;

    
    public bool isTurn;

    public int turnCount;

    private float blueWin;
    public int piecePos;

    

    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gb = GameObject.Find("Spot1");
        DiceZone = GameObject.Find("DiceCheck").GetComponent<DiceZone>();
        DiceScript = GameObject.Find("Dice").GetComponent<DiceScript>();

        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        bluepiece1 = GameObject.Find("BluePiece1");
        
        bluepiece2 = GameObject.Find("BluePiece2");
        
        bluepiece3 = GameObject.Find("BluePiece3");
        
        bluepiece4 = GameObject.Find("BluePiece4");
    


        redpiece1 = GameObject.Find("RedPiece1");
        redhome1 = GameObject.Find("RedHome1");
        redpiece2 = GameObject.Find("RedPiece2");
        redhome2 = GameObject.Find("RedHome2");
        redpiece3 = GameObject.Find("RedPiece3");
        redhome3 = GameObject.Find("RedHome3");
        redpiece4 = GameObject.Find("RedPiece4");
        redhome4 = GameObject.Find("RedHome4");

        yellowpiece1 = GameObject.Find("YellowPiece1");
        yellowhome1 = GameObject.Find("YellowHome1");
        yellowpiece2 = GameObject.Find("YellowPiece2");
        yellowhome2 = GameObject.Find("YellowHome2");
        yellowpiece3 = GameObject.Find("YellowPiece3");
        yellowhome3 = GameObject.Find("YellowHome3");
        yellowpiece4 = GameObject.Find("YellowPiece4");
        yellowhome4 = GameObject.Find("YellowHome4");

        greenpiece1 = GameObject.Find("GreenPiece1");
        greenhome1 = GameObject.Find("GreenHome1");
        greenpiece2 = GameObject.Find("GreenPiece2");
        greenhome2 = GameObject.Find("GreenHome2");
        greenpiece3 = GameObject.Find("GreenPiece3");
        greenhome3 = GameObject.Find("GreenHome3");
        greenpiece4 = GameObject.Find("GreenPiece4");
        greenhome4 = GameObject.Find("GreenHome4");
        
        
    }

   

    // Update is called once per frame
    void Update()
    {
        diceValue = DiceZone.diceValue;
        turnCount = GameManager.turnCount;
        blueWin = GameManager.blueWin;
        canRoll = DiceScript.canRoll;
        
        if (turnCount == 1)
        {
            isTurn = true;
        }
        else{
            isTurn = false;
        }

        

        

    } 
    void OnMouseOver(){
        if(Input.GetMouseButtonDown(0) && inBlue && diceValue == 6 && isTurn && !canRoll ){
            transform.position  = gb.GetComponent<Rigidbody>().position;
            piecePos = 0;
            GameManager.turnCount = 2;
            DiceScript.canRoll = true;
        }
        else if(inBlue && diceValue != 6 && isTurn && !canRoll)
        {
            GameManager.turnCount = 2;
            DiceScript.canRoll = true;
        }
       
        if(Input.GetMouseButtonDown(0) && !inBlue && isTurn && !canRoll){
            transform.position  = spots[piecePos + (int)diceValue].GetComponent<Rigidbody>().position;
            piecePos = piecePos + (int)diceValue;

            GameManager.turnCount = 2;
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


            if (transform.position == greenpiece1.transform.position)
            {
                greenpiece1.transform.position = greenhome1.GetComponent<Rigidbody>().position;
            }
            if (transform.position == greenpiece2.transform.position)
            {
                greenpiece2.transform.position = greenhome2.GetComponent<Rigidbody>().position;
            }
            if (transform.position == greenpiece3.transform.position)
            {
                greenpiece3.transform.position = greenhome3.GetComponent<Rigidbody>().position;
            }
            if (transform.position == greenpiece4.transform.position)
            {
                greenpiece4.transform.position = greenhome4.GetComponent<Rigidbody>().position;
            }
        }
       
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "blueHome")
        {
            inBlue = true;
        }
        

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "blueHome")
        {
            inBlue = false;
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BlueFinish")
        {
            GameManager.blueWin -= 1;
        }

    }

    


}
