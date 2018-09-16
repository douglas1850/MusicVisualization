using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CardBoardLoader : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        StartCoroutine(LoadDevice("cardboard"));
    }

    IEnumerator LoadDevice(string newDevice)
    {
        XRSettings.LoadDeviceByName(newDevice);
        yield return null;
        XRSettings.enabled = true;
    }
}
