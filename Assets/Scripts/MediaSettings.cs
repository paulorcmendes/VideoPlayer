using UnityEngine;
using UnityEngine.Video;

public class MediaSettings : MonoBehaviour {
    private VideoPlayer videoPlayer;
    private AudioSource audioSource;
    private new Camera camera;

    public string url;
    [Range(0f, 100f)]
    public float volume;
    public Rect rect;

    // Use this for initialization
    void Start () {
        InitialConfiguration();
        SetMediaSize();
        SetMediaVolume();        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump")) {
            this.videoPlayer.Play();
        }
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
    void OnMovieFinished(VideoPlayer player)
    {
        Debug.Log("Event for movie end called");
    }
    private void SetMediaSize()
    {
        this.camera.rect = rect;
    }
    private void SetMediaVolume()
    {
        this.audioSource.volume = volume / 100;
    }
}
