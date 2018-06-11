using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScore : MonoBehaviour {

    float timeLeft = 31.0f;
    float sec = 0;
    public Text timer;
    public Text win;
    Vector3 position;
    public GameObject Bball;
    public GameObject Rball;
    public GameObject Yball;
    public float BspawnTime = 0f;
    public float RspawnTime = 10f;
    public float YspawnTime = 5f;
    public bool blahFLAG;
    public GameObject Panel;

    // Use this for initialization
    void Start ()
    {
        timer.text = "Timer: " + timeLeft;
        win.text = "";
        InvokeRepeating("BSpawnball",.0f, BspawnTime);
        InvokeRepeating("RSpawnball", .3f, RspawnTime);
        InvokeRepeating("YSpawnball", .1f, YspawnTime);
        blahFLAG = false;
        Panel.gameObject.SetActive(true);
    }
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            blahFLAG = true;
            Panel.gameObject.SetActive(false);
        }

        if (blahFLAG == true)
        {
            timeLeft -= Time.deltaTime;
            sec = (int)timeLeft;
            timer.text = "Timer: " + sec;
            if (timeLeft < 0)
            {
                //TimeUp 
                print("TIMEUP");
                if (player1Control.player1_sc > player2Control.player2_sc)
                {
                    win.text = "Player 1 Winner!!";
                    GameManager.Play1Score += 100;
                    GameManager.play1Win++;
                    print("p1 wins the points");
                }
                else if (player1Control.player1_sc < player2Control.player2_sc)
                {
                    win.text = "Player 2 Winner!!";
                    GameManager.Play2Score += 100;
                    GameManager.play2Win++;
                    print("player two takes a share of points");
                }
                else if (player1Control.player1_sc == player2Control.player2_sc)
                {
                    win.text = "Draw!!";
                    GameManager.Play1Score += 50;
                    GameManager.Play2Score += 50;
                }
                GameManager.minigame("board");
            }
        }
    }
    void BSpawnball()
    {
        if (blahFLAG == true)
        {
            position = new Vector3(Random.Range(-13, 13), 2, Random.Range(-13, 13));
            var newBall = GameObject.Instantiate(Bball, position, Quaternion.identity);
        }
    }
    void RSpawnball()
    {
        if (blahFLAG == true)
        {
            position = new Vector3(Random.Range(-13, 13), 2, Random.Range(-13, 13));
            var newBall = GameObject.Instantiate(Rball, position, Quaternion.identity);
        }
    }
    void YSpawnball()
    {
        if (blahFLAG == true)
        {
            position = new Vector3(Random.Range(-13, 13), 2, Random.Range(-13, 13));
            var newBall = GameObject.Instantiate(Yball, position, Quaternion.identity);
        }
    }
}