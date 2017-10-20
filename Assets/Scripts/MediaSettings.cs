﻿using UnityEngine;
using UnityEngine.Video;

public enum VIDEO_STATE {PLAYING, STOPED}

public class MediaSettings : MonoBehaviour {
    private VideoPlayer videoPlayer;
    private AudioSource audioSource;
    private new Camera camera;

    //public bool isPlaying;
    //public int frameCount;
    //public int frame;

    public string url;
    [Range(0f, 100f)]
    public float volume;
    public Rect rect;

    public delegate void MyHandler();

    public event MyHandler OnBegin;
    public event MyHandler OnStop;


    // Use this for initialization
    void Awake () {
        InitialConfiguration();
        SetMediaSize();
        SetMediaVolume();
        videoPlayer.loopPointReached += Stopped;
    }
	
	// Update is called once per frame
	void Update () {
        //isPlaying = (videoPlayer.frame == (int)videoPlayer.frameCount);
        //frameCount = (int)videoPlayer.frameCount;
        //frame = (int)videoPlayer.frame;        
    }

    

    private void InitialConfiguration()
    {
        this.audioSource = this.gameObject.AddComponent<AudioSource>();
        this.videoPlayer = this.gameObject.AddComponent<VideoPlayer>();
        this.videoPlayer.playOnAwake = false;
        this.camera = this.gameObject.AddComponent<Camera>();
        this.camera.enabled = false;

        this.videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        this.videoPlayer.source = VideoSource.Url;
        this.videoPlayer.SetTargetAudioSource(0, this.audioSource);
        this.videoPlayer.renderMode = VideoRenderMode.CameraFarPlane;
        this.videoPlayer.aspectRatio = VideoAspectRatio.Stretch;
        this.videoPlayer.targetCamera = this.camera;
        

        this.videoPlayer.isLooping = false;
        this.videoPlayer.url = this.url;        
    }
    
    private void SetMediaSize()
    {
        this.camera.rect = rect;
    }
    private void SetMediaVolume()
    {
        this.audioSource.volume = volume / 100;
    }
    
    public void Play()
    {        
        if(videoPlayer.isPlaying) videoPlayer.Stop();        
        videoPlayer.Play();
        this.camera.enabled = true;
        Debug.Log(url + " comecou");       

        if (OnBegin != null) OnBegin();
    }

    public void Stop() {
        videoPlayer.Stop();
        this.camera.enabled = false;
        Debug.Log(url + " stopou");
        if (OnStop != null) OnStop();
    }

    private void Stopped(VideoPlayer source)
    {
        if (OnStop != null) OnStop();
        Debug.Log(url + " stopou");
        this.camera.enabled = false;
    }


}
