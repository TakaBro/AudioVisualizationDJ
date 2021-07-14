using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AudioSynchronizer : MonoBehaviour
{
    public static event Action onMusicBegin;

    [SerializeField] private float _timeToMusicBegin;
    [SerializeField] private GameObject _videoPlayer;
    [SerializeField] private AudioSource _audioPlayer;
    [SerializeField] private MusicTrackData musicData;
    private bool _hasPlayed = false;

    private void OnEnable()
    {
        GlobalTimer.onMusicEnded += StopVideoPlayer;
        GlobalTimer.onMusicEnded += StopAudioPlayer;
    }

    private void OnDisable()
    {
        GlobalTimer.onMusicEnded -= StopVideoPlayer;
        GlobalTimer.onMusicEnded -= StopAudioPlayer;
    }

    private void StopVideoPlayer()
    {
        _videoPlayer.SetActive(false);
    }

    private void StopAudioPlayer()
    {
        _audioPlayer.Stop();
    }

    void Start()
    {
        _timeToMusicBegin = 7 / ((musicData._bpm / 60) / 2);
        Debug.Log("_timeToMusicBegin: " + _timeToMusicBegin);
    }

    void Update()
    {
        if (_timeToMusicBegin > 0) _timeToMusicBegin -= Time.deltaTime;
        
        if (_timeToMusicBegin <= 0 && !_hasPlayed)
        {
            onMusicBegin.Invoke();
            _videoPlayer.SetActive(true);
            _audioPlayer.Play();
            _hasPlayed = true;
        }
    }
}
