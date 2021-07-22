using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    private RedPieceScript RedPieceScript;
    private YellowPieceScript YellowPieceScript;
    private GreenPieceScript GreenPieceScript;
    private PieceScript PieceScript;

    private GameObject board;

    public int turnCount = 1;

    private bool blueTurn;
    private bool redTurn;
    private bool yellowTurn;
    private bool greenTurn;

    public float blueWin = 4f;
    public float greenWin = 4f;
    public float redWin = 4f;
    public float yellowWin = 4f;
    void Start()
    {
        RedPieceScript = GetComponent<RedPieceScript>();
        YellowPieceScript = GetComponent<YellowPieceScript>();
        GreenPieceScript = GetComponent<GreenPieceScript>();
        PieceScript = GetComponent<PieceScript>();
        board = GameObject.Find("LudoBoard");
    }

    // Update is called once per frame
    void Update()
    {
        if (blueWin == 0)
        {
            Application.Quit(); 
            Destroy(board);
        }
        if (redWin == 0)
        {
            Application.Quit(); 
            Destroy(board);
        }
        if (greenWin == 0)
        {
            Application.Quit();
            Destroy(board); 
        }
        if (yellowWin == 0)
        {
            Application.Quit();
            Destroy(board); 
        }

    }
}
