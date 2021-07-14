using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollDown : MonoBehaviour
{
    [SerializeField] private float beatTempo;
    [SerializeField] private MusicTrackData musicData;


    void Start()
    {
        beatTempo = musicData._bpm / 60f;
        Debug.Log("Music Track Data: bpm = " + musicData._bpm + " bpm/60 = " + beatTempo);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<RectTransform>().anchoredPosition -= new Vector2(0f, beatTempo * Time.deltaTime);
    }
}
