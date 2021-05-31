using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class NoteRecorderEditorWindow : EditorWindow
{
    [MenuItem("Window/NoteRecorder")]
    public static void ShowWindow()
    {
        GetWindow<NoteRecorderEditorWindow>();
    }

    private void OnGUI()
    {
        //Window Code
    }
}
