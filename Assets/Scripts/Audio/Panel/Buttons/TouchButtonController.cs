using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchButtonController : MonoBehaviour, IButtonController, IPointerDownHandler, IPointerUpHandler
{
    //public event Action onButtonPressedInsideNoteHitMarker;

    [SerializeField]
    private GameObject _ButtonHitHighlight;
    [SerializeField]
    private bool _hasEnteredNoteHitMarker = false;
    private bool isButtonPressed = false;

    private void Start()
    {
        //NoteHitDetector.onEnteredNoteHitMarker += EnteredNoteHitMarker;
        //NoteHitDetector.onExitNoteHitMarker += ExitNoteHitMarker;
    }

    private void OnDisable()
    {
        //NoteHitDetector.onEnteredNoteHitMarker -= EnteredNoteHitMarker;
        //NoteHitDetector.onExitNoteHitMarker += ExitNoteHitMarker;
    }

    void Update()
    {

    }

    private void EnteredNoteHitMarker()
    {
        _hasEnteredNoteHitMarker = true;
    }

    private void ExitNoteHitMarker()
    {
        _hasEnteredNoteHitMarker = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ButtonPress();
        HighlightButtonPress();
        Debug.Log("pointer down");
        
        StartCoroutine(WaitToUnpress());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ButtonUnpress();
        HighlightButtonUnpress();
        Debug.Log("pointer up");
    }

    IEnumerator WaitToUnpress()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(.2f);

        ButtonUnpress();
        HighlightButtonUnpress();
        Debug.Log("pointer down TIME OUT");
    }

    public void ButtonPress()
    {
        isButtonPressed = true;
    }

    public void ButtonUnpress()
    {
        isButtonPressed = false;
    }

    public bool ButtonPressingState()
    {
        return isButtonPressed;
    }

    public void HighlightButtonPress()
    {
        //Debug.Log("onButtonPressedInsideNoteHitMarker");
        _ButtonHitHighlight.SetActive(true);
    }

    public void HighlightButtonUnpress()
    {
        _ButtonHitHighlight.SetActive(false);
    }
}
