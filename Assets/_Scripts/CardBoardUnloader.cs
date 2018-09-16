using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CardBoardUnloader : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(LoadDevice(""));
    }

    IEnumerator LoadDevice(string newDevice)
    {
        XRSettings.LoadDeviceByName(newDevice);
        yield return null;
        XRSettings.enabled = false;
    }
}
