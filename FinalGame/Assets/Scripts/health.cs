using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour {

    
    public float guyHealth;
    public static health playerHealth;
    public Slider healthBarSlider; // reference for the slider
    public Text gameOverText;      // reference for text
    private bool isGameOver = false; // flag to see if game is over

	void Start ()
    {
        playerHealth = this;
        gameOverText.enabled = false; // disable GameOver text on start
	}
	
	
	void Update ()
    {
        // update slider
        healthBarSlider.value = guyHealth;  //update health
        if (guyHealth < 1f)
        {
            EnemyMove.Alive.isAlive = 0;
            // destroyes game object in play
            StartCoroutine("deletePlayerDelay");
         

        }
            
	}



    IEnumerator deletePlayerDelay()
    {
        print("in delete function");
        yield return new WaitForSeconds(0.01f);
        Destroy(gameObject);
        
    }
}
