using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopButtonController : MonoBehaviour, IButtonController
{
    [SerializeField]
    private Sprite _buttonIdle, _buttonPressed;
    [SerializeField]
    private string _ButtonHitHighlightName, _inputButtonNote;
    private GameObject _ButtonHitHighlight;

    public event Action onButtonPressedInsideNoteHitMarker;

    private void Start()
    {
        _ButtonHitHighlight = this.transform.Find(_ButtonHitHighlightName).gameObject;
        NoteHitDetector.onEnteredNoteHitMarker += HighlightButtonPress;
    }

    private void OnDisable()
    {
        NoteHitDetector.onEnteredNoteHitMarker -= HighlightButtonPress;
    }

    void Update()
    {
        if (Input.GetButton(_inputButtonNote))
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

    public void ButtonPress()
    {
    }

    public void HighlightButtonPress()
    {
        //Debug.Log("onHit");
        //_ButtonHitHighlight.SetActive(true);
    }

    public void ButtonUnpress()
    {
        throw new System.NotImplementedException();
    }

    public void HighlightButtonUnpress()
    {
        throw new System.NotImplementedException();
    }

    public bool ButtonPressingState()
    {
        throw new NotImplementedException();
    }
}
