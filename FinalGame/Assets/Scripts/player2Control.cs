using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class player2Control : MonoBehaviour
{
	public float Speed = 5.0f;
    public static int player2_sc;
    public Text play2;
    public bool blahFLAG = false;
    void Awake()
    {
        player2_sc = 0;
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

            if (Input.GetKey(KeyCode.A)) { moveh = 1; }
            if (Input.GetKey(KeyCode.D)) { moveh -= 1; }

            if (Input.GetKey(KeyCode.W)) { movev = 1; }
            if (Input.GetKey(KeyCode.S)) { movev -= 1; }

            gameObject.GetComponent<CharacterController>().Move(new Vector3(Speed * movev * Time.deltaTime, 0.0f, Speed * moveh * Time.deltaTime));
            play2.text = "Player2: " + player2_sc;
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "black")
        {
            player2_sc += 1;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "yellow")
        {
            player2_sc += 2;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "red")
        {
            player2_sc += 5;
            Destroy(col.gameObject);
        }
    }
}
