using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalTimer : MonoBehaviour
{
    public static event Action onMusicEnded;

    public float musicTimer = 0;
    public static GlobalTimer instance;

    private bool hasStarted = false;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        AudioSynchronizer.onMusicBegin += StartTimer;
    }

    private void OnDisable()
    {
        AudioSynchronizer.onMusicBegin -= StartTimer;
    }

    void Update()
    {
        if (hasStarted)
        {
            musicTimer += Time.deltaTime;
            Debug.Log("Timer = " + musicTimer);

            if (musicTimer >= JSONReader.musicSheetInJson.musicDurationSecs)
            {
                onMusicEnded.Invoke();
                Debug.Log("Music Ended");
                hasStarted = false;
            }
        }
    }

    private void StartTimer()
    {
        hasStarted = true;
    }
}
