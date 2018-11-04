using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReapeatingBackground : MonoBehaviour {

    private BoxCollider2D groundCollider; //αναφορά στον collider του εδάφους
    private float groundHorizontalLength; //ένας float που αποθηκεύει το μήκος του άξονα χ του collider2D του εδάφους

	// Use this for initialization
	void Start () {
        //αναφορά στον collider του εδάφους
        groundCollider = GetComponent<BoxCollider2D>();
        //αποθηκεύει το μέγεθος του collider στο άξονα του χ (μήκος σε μονάδες Unity)
        groundHorizontalLength = groundCollider.size.x;
	}
	
	// Update is called once per frame
	void Update () {
        //ελέγχει αν η διαφορά στον άξονα χ μεταξύ της κυρίως κάμερας και της θέσης του αντικειμένου this είναι μεγαλύτερη του groundHorizontalLength
		if(transform.position.x < -groundHorizontalLength)
        {
            //αν ισχύει, σημαίνει ότι αυτό το αντικείμενο δεν είανι πλέον ορατό και μπορούμε με ασφάλεια να το μετακινήσουμε έτσι ώστε να το επαναχρησιμοποιήσουμε
            RepositionBackground();
        }
	}

    //μετακινέι το αντικείμενο στο οποίο αυτό το script είναι συνδεδεμένο έτσι ώστε να δημιουργήσει μια λούπα του background
    private void RepositionBackground()
    {
        Vector2 groundOffset = new Vector2(groundHorizontalLength * 2f, 0);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
