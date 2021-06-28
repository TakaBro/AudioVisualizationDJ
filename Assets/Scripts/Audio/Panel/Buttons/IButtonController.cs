using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IButtonController
{
    //public event Action onButtonPressedInsideNoteHitMarker;
    void ButtonPress();
    void ButtonUnpress();
    bool ButtonPressingState();
    void HighlightButtonPress();
    void HighlightButtonUnpress();
}
