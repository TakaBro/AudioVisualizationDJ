using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrackData
{
    public float _bpm = 120;
    public static MusicTrackData instance;

    private static void Init()
    {
        instance._bpm = JSONReader.musicSheetInJson.bpm;
    }

    public static MusicTrackData Singleton
    {
        get
        {
            if (instance == null)
            {
                instance = new MusicTrackData();
                Init();
            }
            return instance;
        }   
    }
}
