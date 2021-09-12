using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteRecorder : MonoBehaviour
{
    [SerializeField] private MusicPitchController musicPitchController;

    public void ChangeMusicSpeed(float timeSpeed)
    {
        TimeScaleController.ChangeTimeScaleSpeed(timeSpeed);
        musicPitchController.ChangeMusicPitch(timeSpeed);
    }

    public void DrawNoteContent(MusicSheet musicSheetRecorded, float timeInterval, int row)
    {
        if (musicSheetRecorded.notes.Exists(note => note.moment == timeInterval && note.position == row))
        {
            Debug.Log(" - Removed Note: [" + timeInterval + "][" + (row) + "]");
            musicSheetRecorded.notes.RemoveAll(note => note.moment == timeInterval && note.position == row);
        }
        else
        {
            Debug.Log(" - Added Note: [" + timeInterval + "][" + (row) + "]");
            musicSheetRecorded.notes.Add(new Note()
            {
                moment = timeInterval,
                position = row,
                type = 1
            });
        }
    }
}
