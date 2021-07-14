using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPitchController : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    public void ChangeMusicPitch(float musicPitch)
    {
        audioSource.pitch = musicPitch;
    }
}
