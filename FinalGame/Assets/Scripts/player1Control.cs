using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class player1Control : MonoBehaviour
{

	public float Speed = 5.0f;
    public static int player1_sc;
    public Text play1;
    public bool blahFLAG = false;
    void Awake()
    {
        player1_sc = 0;
        blahFLAG = false;
    }
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            blahFLAG = true;
        }
        if (blahFLAG == true)
        {
            int moveh = 0;
            int movev = 0;

            if (Input.GetKey("left")) { moveh = 1; }
            if (Input.GetKey("right")) { moveh -= 1; }

            if (Input.GetKey("up")) { movev = 1; }
            if (Input.GetKey("down")) { movev -= 1; }

            gameObject.GetComponent<CharacterController>().Move(new Vector3(Speed * movev * Time.deltaTime, 0.0f, Speed * moveh * Time.deltaTime));
            play1.text = "Player1: " + player1_sc;
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "black")
        {
            player1_sc += 1;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "yellow")
        {
            player1_sc += 2;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "red")
        {
            player1_sc += 5;
            Destroy(col.gameObject);
        }
    }
}
