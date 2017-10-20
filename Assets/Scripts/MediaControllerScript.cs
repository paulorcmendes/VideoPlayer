using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediaControllerScript : MonoBehaviour {

    public GameObject[] medias;

	// Use this for initialization
	void Start () {
        Play(medias[0]);
        OnStopStart(medias[0], medias[1]);
        OnStopStart(medias[1], medias[2]);
        OnStopStart(medias[2], medias[3]);
        OnStopStart(medias[3], medias[0]);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Play(GameObject media)
    {
        media.GetComponent<MediaSettings>().Play();
    }
    private void OnStopStart(GameObject mediaCondition, GameObject mediaAction) {
        mediaCondition.GetComponent<MediaSettings>().OnStop += mediaAction.GetComponent<MediaSettings>().Play;
    }
}
