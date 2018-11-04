using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    public float upForce = 200f; //η δύναμη που γίνεται το flap των φτερών
    private bool isDead = false; //τράκαρε ο παίκτης;
    private Rigidbody2D rb2d; //αναφορά στο στοιχείο RigidBody2D
    private Animator anim; //αναφορά στο στοιχείο Animator

	// Use this for initialization
	void Start () {
        //παίρνουμε την αναφορά στο RigidBody2D που συνδέεται σε αυτό το GameObject
        rb2d = GetComponent<Rigidbody2D>();
        //παίρνουμε την αναφορά στο Animator που συνδέεται σε αυτό το GameObject
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        //δεν επιτρέπουμε τον έλεγχο αν έχει πεθάνει το πουλί
		if(isDead == false)
        {
            //βλέπουμε για είσοδο για να κάνουμε trigger το flap
            if (Input.GetMouseButtonDown(0))
            {
                //μηδενίζουμε την ταχύτητα του πουλιού
                rb2d.velocity = Vector2.zero;
                //δίνουμε ώθηση προς τα πάνω στο πουλί
                rb2d.AddForce(new Vector2(0, upForce));
                //το λέμε στον Animator
                anim.SetTrigger("Flap");
                SoundManager.PlaySound("flap");
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb2d.velocity = Vector2.zero;
        isDead = true;
        anim.SetTrigger("Die");
        GameControl.instance.BirdDied();
    }
}
