using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CyclePauseText : MonoBehaviour {
    bool isPlaying;

    public Text text;
	// Use this for initialization
	void Start () {
        isPlaying = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Cycle()
    {
        if (isPlaying)
        {
            isPlaying = false;
            GetComponent < TextMeshProUGUI >().text = "Play";
        }
        else
        {
            isPlaying = true;
            GetComponent<TextMeshProUGUI>().text = "Pause";
        }
    }
}
