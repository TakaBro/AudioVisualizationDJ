using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayMenu : MonoBehaviour
{
    [SerializeField] private GameObject _endMenuPanel, 
        _starPoint1, _starPoint2, _starPoint3, _pointsBarFill;
    private float fillTime = 2.5f;
    private bool fillBar = false;

    void Start()
    {
        GlobalTimer.onMusicEnded += StopGameTime;
    }

    private void OnDisable()
    {
        GlobalTimer.onMusicEnded -= StopGameTime;
    }

    private void StopGameTime()
    {
        StartCoroutine(WaitToShowEndPanel());
    }

    IEnumerator WaitToShowEndPanel()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);
        Debug.Log("TIME OUT");

        //Time.timeScale = 0;
        ShowEndPanel();
    }

    private void ShowEndPanel()
    {
        _endMenuPanel.SetActive(true);
        Debug.Log("ShowEndPanel");

        StartCoroutine(WaitToShowStatsPoints());
    }

    IEnumerator WaitToShowStatsPoints()
    {
        fillBar = true;

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(.5f);        

        _starPoint1.SetActive(true);

        yield return new WaitForSeconds(1f);

        _starPoint2.SetActive(true);

        yield return new WaitForSeconds(1f);

        _starPoint3.SetActive(true);
    }

    void Update()
    {
        if (fillBar)
        {
            _pointsBarFill.GetComponent<Image>().fillAmount += 1.0f / fillTime * Time.deltaTime;
        }
    }
}
