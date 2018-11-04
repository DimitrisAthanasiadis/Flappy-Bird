using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {

    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        //παίρνουμε αναφορά στο στοιχείο RigidBody2D
        rb2d = GetComponent<Rigidbody2D>();
        //αρχίζει το αντικείμενο να κουνιέται
        rb2d.velocity = new Vector2(GameControl.instance.scrollSSpeed, 0);
	}
	
	// Update is called once per frame
	void Update () {
        //αν το παιχνίδι τελειώσει, σταμάτα το scrolling
		if(GameControl.instance.gameOver == true)
        {
            rb2d.velocity = Vector2.zero;
        }
	}
}
