using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    //3 μεταβλητές για κάθε πιθανό ήχο μέσα στο παιχνίδι
    public static AudioClip flapSound, crashedSound, scoredSound;
    //η προέλευση των ήχων
    static AudioSource audioSrc;

	// Use this for initialization
	void Start () {
        //μεταβλητές που έχουν πρόσβαση στον φάκελο με τους ήχους και τα συγκεκριμένα αρχεία
        flapSound = Resources.Load<AudioClip>("sfx_wing");
        crashedSound = Resources.Load<AudioClip>("sfx_hit");
        scoredSound = Resources.Load<AudioClip>("sfx_point");

        audioSrc = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //μέθοδος που παίζει τους ήχους ανάλογα με το γεγονός
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "flap":
                audioSrc.PlayOneShot(flapSound);
                break;
            case "hit":
                audioSrc.PlayOneShot(crashedSound);
                break;
            case "score":
                audioSrc.PlayOneShot(scoredSound);
                break;
        }
    }
}
