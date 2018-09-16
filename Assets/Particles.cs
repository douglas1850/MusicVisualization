using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour {

    public AudioPeerScript _audioPeer;
    public int scale;
    public Transform particle;
    public double beatThreshold;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        double amp = AudioPeerScript._Amplitude;
        if (amp > beatThreshold) 
		    for (int i = 0; i < 8; i++)
            {
                var xyz = Random.insideUnitSphere * scale;
                var newObject = Instantiate(particle, new Vector3(xyz.x, xyz.y, xyz.z + this.transform.position.z), Quaternion.identity);
                newObject.localScale *= _audioPeer._audioBand[i];
                newObject.localRotation = Quaternion.Euler(90, 180, 0);
                Destroy(newObject.gameObject, 5);
            }
	}
}
