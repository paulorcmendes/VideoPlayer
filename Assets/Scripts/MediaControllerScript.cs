using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediaControllerScript : MonoBehaviour {

    public GameObject[] medias;

    public delegate void MyHandler();

    public event MyHandler Port;
	// Use this for initialization
	void Start () {        
        ConnectorBase.OnEndStop(medias[1], medias[3]);
        ConnectorBase.OnEndStart(medias[3], medias[0]);
        OnEntry(medias[1]);
        ConnectorBase.OnBeginStart(medias[1], medias[3]);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump")) Play();
	}

    private void Play() {
        if(Port != null)  this.Port();
    }

    private void OnEntry(GameObject media)
    {
        this.Port += media.GetComponent<MediaSettings>().Play;
    }
}
