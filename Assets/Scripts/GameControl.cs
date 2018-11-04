using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    public static GameControl instance; //αναφορά στο GameControl για να έχουμε πρόσβαση σε αυτό στατικά
    public GameObject gameOverText;  //αναφορά στο text του UI που λέει GameOver
    public bool gameOver = false; //τελείωσε το παιχνίδι;
    public float scrollSSpeed = -1.5f;
    private int score = 0; //το σκορ του παίκτη
    public Text scoreText; //αναφόρά στο στοιχείο text του UI που απεικονίζει το σκορ του παίκτη

    // Use this for initialization
    void Awake () {
        //αν δεν έχουμε τον έλεγχο του παιχνιδιού...
		if(instance == null)
        {
            //θέτουμε να είναι αυτό...
            instance = this;
            //αλλιώς...
        }else if(instance != this){
            //το καταστρέφουμε
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
        //αν το παιχνίδι έχει τελειώσει και ο παίκτης πατήσει κάτι...
		if(gameOver == true && Input.GetMouseButtonDown(0))
        {
            //κάνουμε ανανέωση της σκηνής
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        } 
	}

    public void BirdScored()
    {
        //το πουλί δεν μπορεί να μαζέψει πόντους αν έχει τελειώσει το παιχνίδι
        if (gameOver)
        {
            return;
        }

        //αν πάλι δεν έχει τελειώσει, αύξησε το σκορ...
        score++;
        ///και προσάρμοσε το κείμενο
        scoreText.text = "Score: " + score.ToString();
        SoundManager.PlaySound("score");
    }

    public void BirdDied()
    {
        SoundManager.PlaySound("hit");
        gameOverText.SetActive(true);
        gameOver = true;
    }
}
