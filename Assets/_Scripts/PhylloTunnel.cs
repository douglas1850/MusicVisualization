using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhylloTunnel : MonoBehaviour {
	public Transform _tunnel;
	public AudioPeerScript _audioPeer; //change speed based on music
	public float _tunnelSpeed, _cameraDistance;
	
	// Update is called once per frame
	void Update () {
		_tunnel.position = new Vector3 (_tunnel.position.x, _tunnel.position.y, 
			_tunnel.position.z + (AudioPeerScript._AmplitudeBuffer * _tunnelSpeed));

		this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, _tunnel.transform.position.z + _cameraDistance);
	}
}
