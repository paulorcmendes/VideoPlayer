using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediaControllerScript : MonoBehaviour {

    public GameObject[] medias;
    public delegate void MyHandler();

    public event MyHandler Port;
	// Use this for initialization
	void Start () {
        
        OnEndStart(medias[0], medias[1]);
        OnEndStart(medias[1], medias[2]);
        OnEndStart(medias[2], medias[3]);
        OnEndStart(medias[3], medias[0]);
        OnPort(medias[0]);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump")) Play();
	}

    private void Play() {
        this.Port();
    }

    private void OnPort(GameObject media)
    {
        this.Port += media.GetComponent<MediaSettings>().Play;
    }
    private void OnEndStart(GameObject mediaCondition, GameObject mediaAction) {
        mediaCondition.GetComponent<MediaSettings>().OnEnd += mediaAction.GetComponent<MediaSettings>().Play;
    }
    private void OnEndStop(GameObject mediaCondition, GameObject mediaAction) {
        mediaCondition.GetComponent<MediaSettings>().OnEnd += mediaAction.GetComponent<MediaSettings>().Stop;
    }
    private void OnBeginStart(GameObject mediaCondition, GameObject mediaAction)
    {
        mediaCondition.GetComponent<MediaSettings>().OnBegin += mediaAction.GetComponent<MediaSettings>().Play;
    }
    private void OnBeginStop(GameObject mediaCondition, GameObject mediaAction)
    {
        mediaCondition.GetComponent<MediaSettings>().OnBegin += mediaAction.GetComponent<MediaSettings>().Stop;
    }
}
