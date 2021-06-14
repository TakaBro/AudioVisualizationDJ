using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AudioSynchronizer : MonoBehaviour
{
    [SerializeField] private float _timeToMusicBegin;
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private AudioSource _audioPlayer;
    private bool _hasPlayed = false;

    void Start()
    {
        _timeToMusicBegin = 7 / ((MusicTrackData.instance._bpm / 60) / 2);
        Debug.Log("_timeToMusicBegin: " + _timeToMusicBegin);
    }

    void Update()
    {
        if (_timeToMusicBegin > 0) _timeToMusicBegin -= Time.deltaTime;
        
        if (_timeToMusicBegin <= 0 && !_hasPlayed)
        {
            _videoPlayer.Play();
            _audioPlayer.Play();
            _hasPlayed = true;
        }
    }
}
