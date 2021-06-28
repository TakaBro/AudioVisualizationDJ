using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private int scorePoints, perfectScorePoints, goodScorePoints;

    void Start()
    {
        scorePoints = 0;
        NoteHitDetector.onPerfectPressNote += PerfectScoreUp;
        NoteHitDetector.onGoodPressNote += GoodScoreUp;
    }

    void OnDisable()
    {
        NoteHitDetector.onPerfectPressNote -= PerfectScoreUp;
        NoteHitDetector.onGoodPressNote -= GoodScoreUp;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Text>().text = "SCORE: " + scorePoints.ToString();
    }

    private void PerfectScoreUp()
    {
        IncreaseScore(perfectScorePoints);
    }

    private void GoodScoreUp()
    {
        IncreaseScore(goodScorePoints);
    }

    private void IncreaseScore(int increasePoints)
    {
        scorePoints += increasePoints;
    }
}
