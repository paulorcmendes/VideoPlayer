// Examples of VideoPlayer function

using UnityEngine;

public class VideoPlayerScript : MonoBehaviour
{
    void Start()
    {
   
        GameObject camera = GameObject.Find("Main Camera");

        var videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
        var audio = videoPlayer.GetTargetAudioSource(0);
        videoPlayer.Play();
        audio.Play();
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.playbackSpeed = vp.playbackSpeed / 10.0F;
    }
}