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

    void OnGUI()
    {
        GUISkin skin = GUI.skin;

        GUILayout.BeginHorizontal();
        GUILayout.Button("", skin.label, GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
        GUILayout.Label("0.5", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
        GUILayout.Label("1.0", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
        GUILayout.Label("1.5", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
        GUILayout.Label("2.0", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
        GUILayout.Label("2.5", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
        GUILayout.Label("3.0", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
        GUILayout.Button("", skin.label, GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Note 1", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
        GUILayout.Button("X", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
        GUILayout.Button("X", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
        GUILayout.Button("X", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
        GUILayout.Button("X", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
        GUILayout.Button("X", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
        GUILayout.Button("X", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Note 2", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
        GUILayout.Button("X", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
        GUILayout.Button("X", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
        GUILayout.Button("X", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
        GUILayout.Button("X", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
        GUILayout.Button("X", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
        GUILayout.Button("X", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
        GUILayout.Button("", skin.label, GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Note 3", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
        GUILayout.Button("X", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
        GUILayout.Button("X", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
        GUILayout.Button("X", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
        GUILayout.Button("X", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
        GUILayout.Button("X", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
        GUILayout.Button("X", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
        GUILayout.Button("", skin.label, GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Note 4", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
        GUILayout.Button("X", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
        GUILayout.Button("X", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
        GUILayout.Button("X", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
        GUILayout.Button("X", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
        GUILayout.Button("X", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
        GUILayout.Button("X", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
        GUILayout.Button("", skin.label, GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
        GUILayout.EndHorizontal();
    }
}
