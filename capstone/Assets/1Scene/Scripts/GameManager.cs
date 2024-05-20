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
    public GameObject ViewResult; //승리/패배 등 UI 스크립트

    private int playerPoint, opponentPoint, playerSet, opponentSet = 0;
    private int currentTurn = 1;
    private int currentSet = 1;
    private int currentStage = 1;
    private int setLimit = 3;
    public Animator enemyAnimator; //enemy의 Animator
    public bool playerTurn = true;
    public bool practice = false;
    public SkillManager skillManager;

    public string currentSkill = "none";
    public bool skillActivated = false;
    public bool skillUsedByPlayer = true;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        if (practice) Debug.Log("Practice Start");
        else Debug.Log("Start of Stage 1");

        if(GameObject.Find("Enemy") != null)
        {
            enemyAnimator = GameObject.Find("Enemy").GetComponent<Animator>();
        }
        

        currentBowControl = playerBowControl;
        currentGrabPoint = currentBowControl.grabpoint;
        currentBowControl.reloadArrow();
        ScoreBoard.GetComponent<writeScore>().write_stage(currentStage);//점수판 UI 현재 스테이지 표시
        ScoreBoard.GetComponent<writeScore>().write_set(currentSet, setLimit); //점수판 UI 현재 세트 표시
        ScoreBoard.GetComponent<writeScore>().write_turn(playerTurn);//점수판 UI 누구의 턴인지 표시  
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void timeOut()
    {
        currentGrabPoint.arrow.transform.position = currentBowControl.arrowPoint.transform.position;
    }
    void destroyArrows()
    {
        GameObject[] arrows = GameObject.FindGameObjectsWithTag("Arrow");

        foreach (GameObject obj in arrows)
        {
            Destroy(obj);
        }
        
    }
    public void calculateScore()
    {
        

        //자신에게 유리한 스킬일 경우
        if (skillActivated && currentSkill != "none")
        {
            //턴 종료시 효과를 해제
            skillActivated = false;
            skillManager.disableSkill(currentSkill);
            currentSkill = "none";
        }
        //상대방을 방해하는 스킬일 경우
        if (!skillActivated && currentSkill != "none")
        {
            //다음 턴에 해제됨
            skillActivated = true;
        }
        

        //쏘아진 화살을 활의 자식 오브젝트에서 다른 오브젝트의 자식으로 변경
        currentGrabPoint.arrow.transform.parent = currentBowControl.arrowPoint.transform;
        

        //턴 종료시
        Debug.Log("End of Turn " + currentTurn);
        if (playerTurn)
        {
            playerPoint = playerPoint + currentGrabPoint.ArrowControl.score;
            Debug.Log("Player : " + playerPoint);
        }
        else
        {
            if(practice) { currentGrabPoint.ArrowControl.score = 0; }
            opponentPoint = opponentPoint + currentGrabPoint.ArrowControl.score;
            Debug.Log("Opponent: " + opponentPoint);
        }

        ScoreBoard.GetComponent<writeScore>().write_score(currentTurn, currentGrabPoint.ArrowControl.score); //점수판 UI 턴 점수 갱신
        ScoreBoard.GetComponent<writeScore>().write_total(playerPoint, opponentPoint, currentTurn); //점수판 UI 턴 점수 총점 갱신

        currentGrabPoint.ArrowControl.score = 0;
        currentTurn++;

        //세트 종료시
        if (currentTurn > 6)
        {
            Debug.Log("End of Set " + currentSet + ", " + playerPoint + " : " + opponentPoint);
            if (playerPoint > opponentPoint) { if (!practice) playerSet++; }
            else if (playerPoint < opponentPoint) opponentSet++;
            else Debug.Log("Draw");


            currentTurn = 1;

            if(!practice) currentSet++;
            else destroyArrows(); //연습모드는 1세트마다 화살을 지움

            playerPoint = 0;
            opponentPoint = 0;
            ScoreBoard.GetComponent<writeScore>().write_set(currentSet, setLimit); //점수판 UI 현재 세트 표시
            ScoreBoard.GetComponent<writeScore>().write_set_score(playerSet, opponentSet); //점수판 UI 세트 점수 표시

            //스테이지 종료시
            if (currentSet > setLimit || playerSet >= 2 || opponentSet >= 2)
            {
                Debug.Log("Game Over, Set score - Player : " + playerSet + " Opponent : " + opponentSet);
                if (playerSet > opponentSet)
                {
                    if(!practice) ViewResult.GetComponent<viewResult>().viewVictory(); //승리 UI
                    Debug.Log("You Win!");
                    nextStage();
                }
                else if (playerSet < opponentSet)
                {
                    Debug.Log("You Lose..");
                    ViewResult.GetComponent<viewResult>().viewDefeat(); //패배 UI
                    Time.timeScale = 0;
                }
                else
                {
                    Debug.Log("Draw");
                    ViewResult.GetComponent<viewResult>().viewDraw(); //패배 UI
                    Time.timeScale = 0;
                }

                return;
            }
            else Debug.Log("Current Set score - Player : " + playerSet + " Opponent : " + opponentSet);
        }

        
        changePlayers();//플레이어 변경
        ScoreBoard.GetComponent<writeScore>().write_turn(playerTurn);//점수판 UI 누구의 턴인지 표시


    }
    private void nextStage()
    {
        if(!practice) Debug.Log("Start of Stage " + (++currentStage));
        playerSet = 0;
        opponentSet = 0;
        currentSet = 1;
        destroyArrows(); // 현재 나와있는 화살 전부 지우기
        changePlayers();
        
        StartCoroutine(WaitAndClearAll()); //모든 것을 새스테이지에 맞게 초기화
    }

    public IEnumerator WaitAndClearAll()
    {
        yield return new WaitForSeconds(2); //2초 대기
        ScoreBoard.GetComponent<writeScore>().write_set(currentSet, setLimit); //점수판 UI 현재 세트 표시
        ScoreBoard.GetComponent<writeScore>().write_set_score(playerSet, opponentSet); //점수판 UI 세트 점수 표시
        ScoreBoard.GetComponent<writeScore>().write_turn(playerTurn); //점수판 UI 누구의 턴인지 표시
        ScoreBoard.GetComponent<writeScore>().write_stage(currentStage);//점수판 UI 현재 스테이지 표시
        ViewResult.GetComponent<viewResult>().viewNothing();//승패UI 초기화
    }
    void startAnimation()
    {
        enemyAnimator.SetTrigger("Draw");
    }

    private void changePlayers()
    {
        if (playerTurn)
        {
            currentBowControl = opponentBowControl;
            playerTurn = false;
            if (practice) calculateScore();
            else
            {
                opponentBowControl.grabpoint.Invoke("invokeArrow", 1.4f);
                if (enemyAnimator != null) Invoke("startAnimation", 1); // enemy 모션 출력
            }
            Debug.Log("Opponent will shoot arrow after 2 seconds");
        }
        else
        {
            currentBowControl = playerBowControl;
            playerTurn = true;
        }
        if (practice) //화살을 안보이게 함
        {
            GameObject[] arrows = GameObject.FindGameObjectsWithTag("Arrow");
            foreach (GameObject obj in arrows)
            {
                obj.transform.parent = currentBowControl.arrowPoint.transform;
                obj.transform.position = currentBowControl.arrowPoint.transform.position;
            }
        }
        currentBowControl.reloadArrow();
        currentGrabPoint = currentBowControl.grabpoint;
        
    }
}
