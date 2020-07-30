using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Tetris : MonoBehaviour
{
    int[,] tetrisBoard;
    [SerializeField, Range(10, 100)] int boardWidth = 10;
    [SerializeField, Range(20, 100)] int boardHeight = 20;
    float squareWidth = 1;
    float givenHeight, givenWidth;
    public GameObject box;
    [SerializeField, Range(0f, 1f)] float shrinkWidth = 0.6f, shrinkHeight = 0.9f;
    GameObject board;
    [SerializeField] Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        //GetHeightAndWidth();
        //MakeBoard();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetHeightAndWidth())
        {
            MakeBoard();
        }
       
    }

    
    void MakeBoard()
    {
        tetrisBoard = new int[boardWidth, boardHeight];
        squareWidth = givenHeight / 20;


        GameObject.Destroy(board);
        
        board = new GameObject("Board");

        for (float x = boardWidth * -.5f; x < boardWidth / 2; x++)
        {
            for (float y = boardHeight * -.5f; y < boardHeight / 2; y++)
            {
                GameObject temp = Instantiate(box, new Vector3(x * squareWidth + squareWidth * .5f, y * squareWidth + squareWidth * .5f, -5f), Quaternion.identity);
                temp.transform.parent = board.transform;
                temp.transform.localScale *= squareWidth * .95f;
                //print(temp.transform.position);
            }
        }
        
        
        
    }
    bool GetHeightAndWidth()
    {
        bool change = false;
        if(givenHeight != Mathf.Floor(mainCamera.orthographicSize * 2f * shrinkHeight))
        {
            givenHeight = Mathf.Floor(mainCamera.orthographicSize * 2f * shrinkHeight);
            change = true;
        }
        if(givenWidth != Mathf.Floor(givenHeight * Camera.main.aspect * shrinkWidth))
        {
            givenWidth = Mathf.Floor(givenHeight * Camera.main.aspect * shrinkWidth);
            change = true;
        }
        return change;
    }
}
