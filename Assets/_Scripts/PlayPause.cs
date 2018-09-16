using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayPause : MonoBehaviour {

    private bool isPlaying;
	// Use this for initialization
	void Start () {
        ///txt = GetComponentInChildren<Text>();
        isPlaying = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void pause(AudioSource music)
    { 
        if (isPlaying)
        {
            music.Pause();
            isPlaying = false;

        }
        else
        {
            music.Play();
            isPlaying = true;

        }
    }
}
