using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrackData : MonoBehaviour
{
    [SerializeField]
    public float _bpm = 120;

    public static MusicTrackData instance;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
