using UnityEngine;
using UnityEngine.Video;

public enum VIDEO_STATE {PLAYING, STOPED}

public class MediaSettings : MonoBehaviour {
    private VideoPlayer videoPlayer;
    private AudioSource audioSource;
    private new Camera camera;

    public bool isPlaying;
    public int frameCount;
    public int frame;

    public string url;
    [Range(0f, 100f)]
    public float volume;
    public Rect rect;

    // Use this for initialization
    void Start () {
        InitialConfiguration();
        SetMediaSize();
        SetMediaVolume();
        videoPlayer.loopPointReached += VideoPlayer_loopPointReached;
        Play();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump")) { // space
            Play();
        }
        if (Input.GetButtonDown("Fire1")) //left ctrl
        {
            this.videoPlayer.Pause();
        }
        if (Input.GetButtonDown("Fire2")) //left alt
        {
            this.videoPlayer.Stop();
        }

        isPlaying = (videoPlayer.frame == (int)videoPlayer.frameCount);
        frameCount = (int)videoPlayer.frameCount;
        frame = (int)videoPlayer.frame;        
    }

    private void VideoPlayer_loopPointReached(VideoPlayer source)
    {
        Debug.Log(url + " cabou");
    }

    private void InitialConfiguration()
    {
        this.audioSource = this.gameObject.AddComponent<AudioSource>();
        this.videoPlayer = this.gameObject.AddComponent<VideoPlayer>();
        this.videoPlayer.playOnAwake = false;
        this.camera = this.gameObject.AddComponent<Camera>();

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
    
    private void Play()
    {        
        if(videoPlayer.isPlaying) videoPlayer.Stop();
        videoPlayer.Play();

        Debug.Log(url+" comecou");
    }

    
}
