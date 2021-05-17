using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField]
    private Sprite _buttonIdle, _buttonPressed;
    [SerializeField]
    private string _ButtonHitHighlightName, _inputButtonNote;
    private GameObject _ButtonHitHighlight;

    private void Start()
    {
        _ButtonHitHighlight = this.transform.Find(_ButtonHitHighlightName).gameObject;
        NoteHitDetector.onHit += HighlightButtonHit;
    }

    private void OnDisable()
    {
        NoteHitDetector.onHit -= HighlightButtonHit;
    }

    private void HighlightButtonHit()
    {
        //Debug.Log("onHit");
        //_ButtonHitHighlight.SetActive(true);
    }

    void Update()
    {
        if(Input.GetButton(_inputButtonNote))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = _buttonPressed;
            _ButtonHitHighlight.SetActive(true);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = _buttonIdle;
            _ButtonHitHighlight.SetActive(false);
        }

    }
}
