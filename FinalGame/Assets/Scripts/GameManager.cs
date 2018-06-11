using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int Play1Score = 0000;
    public static int Play2Score = 0000;

    //public float moveSpeed; //speed of players movement
    public static int[] nextPoint = new int[2]; //holds next destination before reaching target
    public static int[] goalPoint = new int[2]; //holds final target position
    public static int player_num; //holds player number
    public static bool flag = false; //holds flag to determine if player is still moving or not
    public static int play1Win = 0; //holds winner doubles
    public static int play2Win = 0; //holds winner doubles

    //switch scene into minigame
    public static void minigame(string c)
    {
        SceneManager.LoadScene(c);
    }

    // Update is called once per frame
    void Update()
    {
        //exit game with escape key
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
