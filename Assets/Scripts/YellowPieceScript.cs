using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPieceScript : MonoBehaviour
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

    private GameObject bluepiece1;
    private GameObject bluepiece2;
    private GameObject bluepiece3;
    private GameObject bluepiece4;
    private GameObject bluehome1;
    private GameObject bluehome2;
    private GameObject bluehome3;
    private GameObject bluehome4;

    private GameObject greenpiece1;
    private GameObject greenpiece2;
    private GameObject greenpiece3;
    private GameObject greenpiece4;
    private GameObject greenhome1;
    private GameObject greenhome2;
    private GameObject greenhome3;
    private GameObject greenhome4;

    public bool isTurn;

    int piecePos;

    private bool canRoll;
    private float yellowWin;
    public int turnCount;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gb = GameObject.Find("Spot14");
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
        canRoll = DiceScript.canRoll;
         diceValue = DiceZone.diceValue;
         turnCount = GameManager.turnCount;
         if (turnCount == 2)
        {
            isTurn = true;
        }
        else{
            isTurn = false;
        }
        yellowWin = GameManager.yellowWin;
    } 
    void OnMouseOver(){
        if(Input.GetMouseButtonDown(0) && inYellow && diceValue == 6 && isTurn && !canRoll){
            transform.position  = gb.GetComponent<Rigidbody>().position;
            piecePos = 0;
            GameManager.turnCount = 3;
            DiceScript.canRoll = true;
        }
        else if(inYellow && diceValue != 6 && isTurn && !canRoll)
        {
            GameManager.turnCount = 3;
            DiceScript.canRoll = true;
        }
       
        if(Input.GetMouseButtonDown(0) && !inYellow && isTurn && !canRoll){
            transform.position  = spots[piecePos + (int)diceValue].GetComponent<Rigidbody>().position;
            piecePos = piecePos + (int)diceValue;
            GameManager.turnCount = 3;
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
        if (other.tag == "yellowHome")
        {
            inYellow = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "yellowHome")
        {
            inYellow = false;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "YellowFinish")
        {
            GameManager.yellowWin -= 1;
        }

    }


}