using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteRecorderEditor : MonoBehaviour
{
    [SerializeField] private MusicPitchController musicPitchController;

    public void ChangeMusicSpeed(float timeSpeed)
    {
        TimeScaleController.ChangeTimeScaleSpeed(timeSpeed);
        musicPitchController.ChangeMusicPitch(timeSpeed);
    }
}
