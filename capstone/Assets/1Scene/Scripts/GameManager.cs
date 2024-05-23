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
    public bool skill = false;
    public bool count_cool = false; //쿨타임을 1턴 넘길 것을 허용하겠는가 (턴이 넘어갈 때 true)
    public bool count_cool_enemy = false; //적팀의 쿨타임을 1턴 넘길 것을 허용하겠는가 (턴이 넘어갈 때 true)
    public bool enemy_try_skill = false; //적팀이 스킬을 쓸 것을 허용하겠는가 (적의 턴일 때 true)
    public bool enemy_add_skill = false; //적팀이 스킬을 하나 더 갖도록 허용하겠는가 (스테이지 넘어갈 때 true)
    private int temp_score = 0;

    public List<TargetSkill> activatedTargetSkills; //현재 발동중인 과녁 스킬들
    public List<ArrowSkill> activatedArrowSkills; //현재 발동중인 화살 스킬들

    public doubleArrow doubleArrow;
    public doubleArrowEnemy doubleArrowEnemy;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        if (practice) Debug.Log("Practice Start");
        else Debug.Log("Start of Stage 1");

        if (!practice) { enemyAnimator = GameObject.Find("Enemy").GetComponent<Animator>(); } //if문 없으면 연습모드에서 화살이 사라짐

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
    void deactivateTargetSkills()
    {
        for (int i = activatedTargetSkills.Count - 1; i >= 0; i--)
        {
            activatedTargetSkills[i].activeTurns--;
            if (activatedTargetSkills[i].activeTurns == 0)
            {
                activatedTargetSkills[i].disable();
                activatedTargetSkills.RemoveAt(i);
            }
        }
    }
    void deactivateArrowSkills()
    {
        for (int i = activatedArrowSkills.Count - 1; i >= 0; i--)
        {
            activatedArrowSkills[i].activeTurns--;
            if (activatedArrowSkills[i].activeTurns == 0)
            {
                activatedArrowSkills[i].disable();
                activatedArrowSkills.RemoveAt(i);
            }
        }
    }
    public void calculateScore()
    {
        //쏘아진 화살을 활의 자식 오브젝트에서 다른 오브젝트의 자식으로 변경
        currentGrabPoint.arrow.transform.parent = currentBowControl.arrowPoint.transform;

        if ((doubleArrow.activeTurns == 2) && (doubleArrow.skill))
        {
            doubleArrow.activeTurns--;

            temp_score += currentGrabPoint.ArrowControl.score;
            playerPoint = playerPoint + currentGrabPoint.ArrowControl.score;
            Debug.Log("Player : " + playerPoint);

            ScoreBoard.GetComponent<writeScore>().write_score(currentTurn, currentGrabPoint.ArrowControl.score); //점수판 UI 턴 점수 갱신
            ScoreBoard.GetComponent<writeScore>().write_total(playerPoint, opponentPoint, currentTurn); //점수판 UI 턴 점수 총점 갱신

            currentBowControl.reloadArrow();
            //currentGrabPoint = currentBowControl.grabpoint;

            return;
        }

        if ((doubleArrowEnemy.activeTurns == 2) && (doubleArrowEnemy.skill))
        {
            doubleArrowEnemy.activeTurns--;

            temp_score += currentGrabPoint.ArrowControl.score;
            opponentPoint = opponentPoint + currentGrabPoint.ArrowControl.score;
            Debug.Log("Opponent: " + opponentPoint);

            ScoreBoard.GetComponent<writeScore>().write_score(currentTurn, currentGrabPoint.ArrowControl.score); //점수판 UI 턴 점수 갱신
            ScoreBoard.GetComponent<writeScore>().write_total(playerPoint, opponentPoint, currentTurn); //점수판 UI 턴 점수 총점 갱신

            currentBowControl.reloadArrow();
            //currentGrabPoint = currentBowControl.grabpoint;

            return;
        }

        //과녁 스킬들 효과 해제
        deactivateTargetSkills();
        //화살 스킬들 효과 해제
        deactivateArrowSkills();

        //턴 종료시
        Debug.Log("End of Turn " + currentTurn);
        if (playerTurn)
        {
            temp_score += currentGrabPoint.ArrowControl.score;
            playerPoint = playerPoint + currentGrabPoint.ArrowControl.score;
            Debug.Log("Player : " + playerPoint);
        }
        else
        {
            if (practice) { currentGrabPoint.ArrowControl.score = 0; }
            temp_score += currentGrabPoint.ArrowControl.score;
            opponentPoint = opponentPoint + currentGrabPoint.ArrowControl.score;
            Debug.Log("Opponent: " + opponentPoint);
        }

        //ScoreBoard.GetComponent<writeScore>().write_score(currentTurn, currentGrabPoint.ArrowControl.score); //점수판 UI 턴 점수 갱신
        ScoreBoard.GetComponent<writeScore>().write_score(currentTurn, temp_score); //점수판 UI 턴 점수 갱신
        ScoreBoard.GetComponent<writeScore>().write_total(playerPoint, opponentPoint, currentTurn); //점수판 UI 턴 점수 총점 갱신

        temp_score = 0;
        currentGrabPoint.ArrowControl.score = 0;
        currentTurn++;
        if (skill)
        {
            count_cool = true; //모든 스킬에 대해서, 쿨타임 1턴을 넘긴다. CoolManager 스크립트에서 관리함
            count_cool_enemy = true; //모든 스킬에 대해서, '적' 쿨타임 1턴을 넘긴다. CoolManagerEnemy 스크립트에서 관리함
            enemy_try_skill = true; //적팀이 스킬 사용 시도하도록 한다. 단, 적팀의 턴에서만 스킬이 발동된다. SkillManagerEnemy 스크립트에서 관리함
        }


        //세트 종료시
        if (currentTurn > 6)
        {
            Debug.Log("End of Set " + currentSet + ", " + playerPoint + " : " + opponentPoint);
            if (playerPoint > opponentPoint) { if (!practice) playerSet++; }
            else if (playerPoint < opponentPoint) opponentSet++;
            else Debug.Log("Draw");


            currentTurn = 1;

            if (!practice) currentSet++;
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
                    if (!practice) ViewResult.GetComponent<viewResult>().viewVictory(); //승리 UI
                    Debug.Log("You Win!");
                    nextStage(false);
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
                    //Time.timeScale = 0;
                    nextStage(true);
                }

                return;
            }
            else Debug.Log("Current Set score - Player : " + playerSet + " Opponent : " + opponentSet);
        }


        changePlayers();//플레이어 변경
        ScoreBoard.GetComponent<writeScore>().write_turn(playerTurn);//점수판 UI 누구의 턴인지 표시


    }
    private void nextStage(bool draw)
    {
        if (draw) { currentStage--; }
        if (!practice) Debug.Log("Start of Stage " + (++currentStage));
        if (skill && !draw) { enemy_add_skill = true; } //적팀이 스킬을 하나 더 뽑아서 소지한다. SkillManagerEnemy 스크립트에서 관리함

        playerSet = 0;
        opponentSet = 0;
        currentSet = 1;
        destroyArrows(); // 현재 나와있는 화살 전부 지우기
        changePlayers();

        //과녁 관련 스킬들 모두 해제
        for (int i = activatedTargetSkills.Count - 1; i >= 0; i--)
        {
            activatedTargetSkills[i].disable();
            activatedTargetSkills.RemoveAt(i);
        }
        //화살 관련 스킬들 모두 해제
        for (int i = activatedArrowSkills.Count - 1; i >= 0; i--)
        {
            activatedArrowSkills[i].disable();
            activatedArrowSkills.RemoveAt(i);
        }

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

    //setSelect 함수는 게임시작 전 세트 수 선택에 대한 것임
    public void setSelect1()
    {
        setLimit = 1;
    }

    public void setSelect3()
    {
        setLimit = 3;
    }

    public void setSelect5()
    {
        setLimit = 51;
    }
}