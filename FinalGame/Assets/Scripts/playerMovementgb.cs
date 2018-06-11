using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovementgb : MonoBehaviour
{
    private int ranNumber; //random number generated
    private int ranWIN = 0; //random number generated
    public Transform[] patrolPoints; //holds space positions
    public Transform[] player; //holds players
    public float moveSpeed; //speed of players movement
    public Text textValue; //holds text variable for position
    public Text textRandom; //holds text variable for random number
    public Text textPlay; //holds text for game Instructions
    public Text score_P1; //holds text variable for position
    public Text score_P2; //holds text variable for random number
    public Camera[] cam; //UPDATED: holds all cameras
    public GameObject Panel;
    public Text message; //holds message to player
    private bool gamePlayFLAG = true;
    public Canvas canvas; //holds canvas for text camera view
    private bool pauseFlag = false;
    private bool miniGamePlay;
    private bool backFlag = false;


    void Awake()
    {
        textRandom.text = "";
        textValue.text = "";
        textPlay.text = "";
        score_P1.text = "Player1: "+GameManager.Play1Score.ToString();
        score_P2.text = "Player2: "+GameManager.Play2Score.ToString();
        player[0].position = patrolPoints[GameManager.goalPoint[0]].position;
        player[1].position = patrolPoints[GameManager.goalPoint[1]].position;
        miniGamePlay = false;
        backFlag = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (cam[0].enabled == true && gamePlayFLAG)
        {
            if (GameManager.player_num == 0)
            {
                textPlay.text = "P1: Blue";
            }
            else if (GameManager.player_num == 1)
            {
                textPlay.text = "P2: Pink";
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && !GameManager.flag && gamePlayFLAG && !pauseFlag)
        {
            //rollADie
            rollADie(GameManager.player_num);
            gamePlayFLAG = false;
            message.text = "Press right Arrow to Move Along...";
        }
        if (Input.GetKeyDown("right") && !GameManager.flag && !gamePlayFLAG && !pauseFlag)
        {
            Panel.gameObject.SetActive(false);
            textValue.text = "";
            textRandom.text = "";
            textPlay.text = "";
            SwitchCam(GameManager.player_num+1);//CHANGE CAMERA TO NEXT PLAYER
            //Ensuring winner won't try moving to unexistent position on game board
            if (GameManager.goalPoint[GameManager.player_num] >= patrolPoints.Length - 1)
            {
                GameManager.goalPoint[GameManager.player_num] = patrolPoints.Length - 1;
            }
            GameManager.flag = true; //set flag to start moving player
            gamePlayFLAG = true;
        }
        //AT THIS POINT PLAYER REACHES TARGET POSITION
        if (player[GameManager.player_num].position == patrolPoints[GameManager.goalPoint[GameManager.player_num]].position && GameManager.flag && !pauseFlag)
        {
            textRandom.text = ""; //clear random
            //STATEMENTS TO CHECK WHERE PLAYER LANDED TO DETERMINE WHAT WILL HAPPEN NEXT
            if (patrolPoints[GameManager.goalPoint[GameManager.player_num]].tag == "Yellow" && GameManager.flag && !backFlag)
            {
                GameManager.flag = false; //set flag to switch player
            }
            else if (patrolPoints[GameManager.goalPoint[GameManager.player_num]].tag == "Green" && GameManager.flag && !backFlag)
            {
                GameManager.flag = false; //set flag to switch player
            }
            else if (patrolPoints[GameManager.goalPoint[GameManager.player_num]].tag == "Blue" && GameManager.flag && !backFlag)
            {
                StartCoroutine(switchScene("BlueMinigame"));
                miniGamePlay = true;
                GameManager.flag = false; //set flag to switch player
            }
            else if (patrolPoints[GameManager.goalPoint[GameManager.player_num]].tag == "Skip" && GameManager.flag && !backFlag)
            {
                GameManager.flag = false; //set flag to switch player
            }
            else if (patrolPoints[GameManager.goalPoint[GameManager.player_num]].tag == "Back Random" && GameManager.flag && !backFlag)
            {
                GameManager.flag = false; //set flag to switch player;
                ranNumber = Random.Range(1, 7);
                textPlay.text = "Going Back..."+ranNumber;
                GameManager.goalPoint[GameManager.player_num] -= ranNumber;
                GameManager.nextPoint[GameManager.player_num] -= ranNumber;
                TextEdit(GameManager.player_num);
                GameManager.flag = true; //set flag to NOT switch player and move back
                backFlag = true;
            }
            backFlag = false;
            //STATEMENT THAT WILL SWITCH TO NEXT PLAYER
            if (!GameManager.flag)
            {
                GameManager.player_num++;
                if (GameManager.player_num == player.Length)
                {
                    GameManager.player_num = 0;
                }
                backFlag = false;
            }
            if (!miniGamePlay  && !GameManager.flag)
            {
                StartCoroutine(Example());
            }
        }
        //updating player's next position to have a smooth transition
        else if (player[GameManager.player_num].position == patrolPoints[GameManager.nextPoint[GameManager.player_num]].position)
        {
            GameManager.nextPoint[GameManager.player_num]++;
        }
        //if player hasn't reached destination...keep moving
        if (GameManager.flag == true)
        {
            TextEdit(GameManager.player_num);
            player[GameManager.player_num].position = Vector3.MoveTowards(player[GameManager.player_num].position, patrolPoints[GameManager.nextPoint[GameManager.player_num]].position, moveSpeed * Time.deltaTime);
        }
        //checking if player reached last point in game
        if (GameManager.nextPoint[GameManager.player_num] >= patrolPoints.Length - 1)
        {
            textValue.text = "You Win!";
            Panel.gameObject.SetActive(true);
            message.text = "Player 1: "+GameManager.Play1Score.ToString()+ "  Player 2: " + GameManager.Play2Score.ToString();
            textPlay.text = "";
            textRandom.text = "";
        }
    }
    //this function updates the player position text display
    void TextEdit(int x)
    {
        textValue.text = GameManager.nextPoint[x].ToString();
    }
    //this function replaced all other functions that would switch camera for player view
    public void SwitchCam(int x)
    {
        for (int i = 0; i < cam.Length; i++)
        {
            cam[i].enabled = false;
        }
        cam[x].enabled = true;
        canvas.worldCamera = cam[x];
    }
    public void rollADie(int x)
    {
        ranNumber = Random.Range(1, 7);//random number generator
        textRandom.text = "You hit..." + ranNumber.ToString(); //text random # update
        if (x == 0 && GameManager.play1Win != 0)
        {
            ranWIN = Random.Range(1, 7);//random number generator
            textRandom.text = "You hit..." + ranNumber.ToString() + "  +  " + ranWIN.ToString(); //text random # update
            GameManager.play1Win--;
        }
        else if (x == 1 && GameManager.play2Win != 0 )
        {
            ranWIN = Random.Range(1, 7);//random number generator
            textRandom.text = "You hit..." + ranNumber.ToString() + "  +  " + ranWIN.ToString(); //text random # update
            GameManager.play2Win--;
        }
        textValue.text = "";
        ranNumber += ranWIN;
        GameManager.goalPoint[GameManager.player_num] += ranNumber; //target update
        textPlay.text = "New Goal: " + GameManager.goalPoint[x].ToString();
        ranWIN = 0;
    }
    IEnumerator Example()
    {
        pauseFlag = true;
        yield return new WaitForSeconds(1.3f);
        SwitchCam(0);
        Panel.gameObject.SetActive(true);
        message.text = "Press Space to roll Die.";
        textPlay.text = "";
        textValue.text = "";
        pauseFlag = false;
    }

    IEnumerator switchScene(string c)
    {
        pauseFlag = true;
        yield return new WaitForSeconds(1.3f);
        GameManager.minigame(c);
        pauseFlag = false;
    }
}