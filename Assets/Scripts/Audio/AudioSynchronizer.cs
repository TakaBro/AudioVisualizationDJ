using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AudioSynchronizer : MonoBehaviour
{
    [SerializeField] private float _timeToMusicBegin;
    [SerializeField] private VideoPlayer _videoPlayer;
    private bool _videoHasPlayed = false;

    // Update is called once per frame
    void Update()
    {
        if (_timeToMusicBegin > 0) _timeToMusicBegin -= Time.deltaTime;
        
        if (_timeToMusicBegin <= 0 && !_videoHasPlayed)
        {
            _videoPlayer.Play();
            _videoHasPlayed = true;
        }
    }
}
