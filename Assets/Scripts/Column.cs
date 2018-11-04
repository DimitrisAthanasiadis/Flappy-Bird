using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Bird>() != null)
        {
            //αν το πουλί κάνει trigger τον collider μεταξύ των στηλών τότε
            //λέμε ότι σκόραρε το πουλί
            GameControl.instance.BirdScored();
        }
    }
}
