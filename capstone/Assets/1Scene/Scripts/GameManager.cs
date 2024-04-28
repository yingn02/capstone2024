using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bowControl playerBowControl;
    public bowControl opponentBowControl;

    private bowControl currentBowControl;
    private grabPoint currentGrabPoint;

    public GameObject ScoreBoard; //점수판 UI 스크립트

    private int playerPoint, opponentPoint, playerSet, opponentSet = 0;
    private int currentTurn = 1;
    private int currentSet = 1;
    private int setLimit = 3; //1세트 게임
    public bool playerTurn = true;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        currentBowControl = playerBowControl;
        currentGrabPoint = currentBowControl.grabpoint;
        currentBowControl.reloadArrow();
        ScoreBoard.GetComponent<writeScore>().write_set(currentSet, setLimit); //점수판 UI 현재 세트 표시
        ScoreBoard.GetComponent<writeScore>().write_turn(playerTurn);//점수판 UI 누구의 턴인지 표시
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void calculateScore()
    {
        currentGrabPoint.arrow.transform.parent = currentBowControl.arrowPoint.transform;

        Debug.Log("End of Turn " + currentTurn);
        if (playerTurn)
        {
            playerPoint = playerPoint + currentGrabPoint.ArrowControl.score;
            Debug.Log("Player : " + playerPoint);
        }
        else
        {
            opponentPoint = opponentPoint + currentGrabPoint.ArrowControl.score;
            Debug.Log("Opponent: " + opponentPoint);
        }

        ScoreBoard.GetComponent<writeScore>().write_score(currentTurn, currentGrabPoint.ArrowControl.score); //점수판 UI 턴 점수 갱신
        ScoreBoard.GetComponent<writeScore>().write_total(playerPoint, opponentPoint, currentTurn); //점수판 UI 턴 점수 총점 갱신

        currentGrabPoint.ArrowControl.score = 0;
        currentTurn++;

        if (currentTurn > 6)
        {
            Debug.Log("End of Set " + currentSet+", "+playerPoint+" : "+opponentPoint);
            if (playerPoint > opponentPoint) playerSet++;
            else if (playerPoint < opponentPoint) opponentSet++;
            else Debug.Log("Draw");

            currentTurn = 1;
            currentSet++;
            playerPoint = 0;
            opponentPoint = 0;
            ScoreBoard.GetComponent<writeScore>().write_set(currentSet, setLimit); //점수판 UI 현재 세트 표시
            ScoreBoard.GetComponent<writeScore>().write_set_score(playerSet, opponentSet); //점수판 UI 세트 점수 표시

            if (currentSet > setLimit)
            {
                Debug.Log("Game Over, Set score - Player : " + playerSet + " Opponent : " + opponentSet);
                if (playerSet > opponentSet) Debug.Log("You Win!");
                else if (playerSet < opponentSet) Debug.Log("You Lose..");
                else Debug.Log("Draw");
                return;
            }
            else Debug.Log("Current Set score - Player : " + playerSet + " Opponent : " + opponentSet);
        }
        
        changePlayers();
        ScoreBoard.GetComponent<writeScore>().write_turn(playerTurn);//점수판 UI 누구의 턴인지 표시


    }
    private void changePlayers()
    {
        if (playerTurn) {
            currentBowControl = opponentBowControl;
            playerTurn = false;
            opponentBowControl.grabpoint.Invoke("invokeArrow", 2);
            Debug.Log("Opponent will shoot arrow after 2 seconds");
        }
        else
        {
            currentBowControl = playerBowControl;
            playerTurn = true;
        }
        currentBowControl.reloadArrow();
        currentGrabPoint = currentBowControl.grabpoint;
    }
}
