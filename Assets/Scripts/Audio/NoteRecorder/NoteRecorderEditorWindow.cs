﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Newtonsoft.Json;
using System.IO;

#if UNITY_EDITOR
public class NoteRecorderEditorWindow : EditorWindow
{
    public static string _jsonImportFileName = "MusicSheetFromNoteRecorder";

    private Vector2 _scrollPos;
    private int _notesColumn = 4;
    private int _numberOfBars = 300;
    private int _gridDivision = 4;
    private float _bpm = 120;
    private float _barNotes = 16;
    private float _labelWidth = 50f;
    private float _labelHeight = 50f;
    private float executionTimeStamp; int separationTimeStamp;
    private string _jsonExportFileName = "MusicSheetFromNoteRecorder.json";
    private NoteRecorder noteRecorder;

    [MenuItem("Window/NoteRecorder")]
    static void Init()
    {
        NoteRecorderEditorWindow window = (NoteRecorderEditorWindow)GetWindow(typeof(NoteRecorderEditorWindow));
        window.Show();
    }

    private void OnEnable()
    {
        noteRecorder = GameObject.Find("/---CONTROLLER---/NoteRecorder").GetComponent<NoteRecorder>();

        JSONReader.musicSheetInJson.notes = new List<Note>();
        JSONReader.musicSheetInJson.bpm = _bpm;
    }

    void OnGUI()
    {
        GUISkin skin = GUI.skin;

        BeginScrollBar();
        DrawAllNoteLines();
        DrawRowLabels(skin);
        EndScrollBar();

        DrawJsonImportButton(skin);
        DrawInputFields();
        DrawJsonExportFileName();
        DrawGenerateJsonButton();
        DrawTrackSpeedChangeButtons();
    }

    private void BeginScrollBar()
    {
        EditorGUILayout.BeginVertical();
        _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
    }

    private void EndScrollBar()
    {
        EditorGUILayout.EndScrollView();
        EditorGUILayout.EndVertical();
    }

    private void DrawJsonImportButton(GUISkin skin)
    {
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("IMPORT JSON", GUILayout.ExpandWidth(false)))
        {
            Debug.Log("JSON PATH: " + "JsonFiles/" + _jsonImportFileName);
            Debug.Log("JSON LOAD: " + JSONReader.LoadTextFromJsonFile("JsonFiles/" + _jsonImportFileName));
            
            JSONReader.musicSheetInJson = JsonUtility.FromJson<MusicSheet>(JSONReader.LoadTextFromJsonFile("JsonFiles/" + _jsonImportFileName));
            Debug.Log("Json loaded");
        }
        GUILayout.EndHorizontal();
    }

    private void DrawInputFields()
    {
        GUILayout.BeginHorizontal();
        _jsonImportFileName = EditorGUILayout.TextField("Import Json File Name : ", _jsonImportFileName);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        _bpm = EditorGUILayout.FloatField("BPM : ", _bpm);
        GUILayout.EndHorizontal();
        
        GUILayout.BeginHorizontal();
        _barNotes = EditorGUILayout.FloatField("1/X, X :", _barNotes);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        _numberOfBars = EditorGUILayout.IntField("Nº of Bars :", _numberOfBars);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        _gridDivision = EditorGUILayout.IntField("Grid Division :", _gridDivision);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        JSONReader.musicSheetInJson.musicDurationSecs = EditorGUILayout.FloatField("Music Duration (sec) :", JSONReader.musicSheetInJson.musicDurationSecs);
        GUILayout.EndHorizontal();
    }

    private void DrawRowLabels(GUISkin skin)
    {
        GUILayout.BeginHorizontal();
        DrawSpace(skin, _labelHeight, _labelWidth);
        for (int i = 0; i < _notesColumn; i++)
        {
            GUILayout.Label("Note" + (i + 1).ToString(), GUILayout.ExpandWidth(false),
                GUILayout.MaxHeight(_labelHeight), GUILayout.MaxWidth(_labelWidth));
        }
        GUILayout.EndHorizontal();
    }

    private void DrawSpace(GUISkin skin, float labelHeight, float labelWidth)
    {
        GUILayout.Button("", skin.label, GUILayout.ExpandWidth(false), GUILayout.MaxHeight(labelHeight), GUILayout.MaxWidth(labelWidth));
    }

    private void DrawAllNoteLines()
    {
        separationTimeStamp = (int)(CalculateBarExecutionTime(_bpm, _barNotes) * (_notesColumn * _numberOfBars));
        for (int i = ((int)(_notesColumn * _numberOfBars)); i >= 0; i--)
        {
            executionTimeStamp = CalculateBarExecutionTime(_bpm, _barNotes) * i;
            //Debug.Log(executionTimeStamp + " , " + separationTimeStamp);
            if (executionTimeStamp == separationTimeStamp && separationTimeStamp != 0)
            {
                DrawGuiLine();
                separationTimeStamp--;
                //Debug.Log(executionTimeStamp + " == " + separationTimeStamp);
            }
            DrawNoteLine(executionTimeStamp, _labelHeight, _labelWidth, i);
        }
    }

    private float CalculateBarExecutionTime(float bpm, float barDivision)
    {
        return ((barDivision / (bpm / 60)) / barDivision) / _gridDivision;
    }

    void DrawGuiLine(int i_height = 3)
    {
        Rect rect = EditorGUILayout.GetControlRect(false, i_height);
        rect.height = i_height;
        EditorGUI.DrawRect(rect, new Color(0.5f, 0.5f, 0.5f, 1));
    }

    private void DrawNoteLine(float timeInterval, float labelHeight, float labelWidth, int line)
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label(timeInterval.ToString(), GUILayout.ExpandWidth(false), GUILayout.MaxHeight(labelHeight), GUILayout.MaxWidth(labelWidth));
        for (int row = 1; row <= _notesColumn; row++)
        {

            if (GUILayout.Button(JSONReader.musicSheetInJson.notes.Exists(note => note.moment == timeInterval && note.position == row) ? "X" : "", 
                GUILayout.ExpandWidth(false), GUILayout.MaxHeight(labelHeight), GUILayout.MaxWidth(labelWidth)))
            {
                if (JSONReader.musicSheetInJson.notes.Exists(note => note.moment == timeInterval && note.position == row))
                {
                    Debug.Log(" - Removed Note: [" + timeInterval + "][" + (row) + "]");
                    JSONReader.musicSheetInJson.notes.RemoveAll(note => note.moment == timeInterval && note.position == row);
                }
                else
                {
                    Debug.Log(" - Added Note: [" + timeInterval + "][" + (row) + "]");
                    JSONReader.musicSheetInJson.notes.Add(new Note()
                    {
                        moment = timeInterval,
                        position = row,
                        type = 1
                    });
                }
            }
        }
        GUILayout.EndHorizontal();
    }

    private void DrawJsonExportFileName()
    {
        GUILayout.BeginHorizontal();
        _jsonExportFileName = EditorGUILayout.TextField("Export Json File Name : ", _jsonExportFileName);
        GUILayout.EndHorizontal();
    }

    private void DrawGenerateJsonButton()
    {
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("GENERATE JSON", GUILayout.ExpandWidth(false)))
        {
            JSONReader.musicSheetInJson.bpm = _bpm;
            OrderListByNoteMoment(JSONReader.musicSheetInJson);
            JSONWriter.ExportFile(_jsonExportFileName,
                        JSONWriter.GenerateJsonString(JSONReader.musicSheetInJson), 
                        Constants.NOTE_RECORDER_MUSIC_SHEET_JSON);
            Debug.Log("Json created");
        }
        GUILayout.EndHorizontal();
    }

    private void DrawTrackSpeedChangeButtons()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Music Preview Speed: ", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(50), GUILayout.MaxWidth(150));
        if (GUILayout.Button("2X", GUILayout.ExpandWidth(false)))
        {
            noteRecorder.ChangeMusicSpeed(2);
        }
        if (GUILayout.Button("3X", GUILayout.ExpandWidth(false)))
        {
            noteRecorder.ChangeMusicSpeed(3);
        }
        if (GUILayout.Button("NORMAL", GUILayout.ExpandWidth(false)))
        {
            noteRecorder.ChangeMusicSpeed(1);
        }
        GUILayout.EndHorizontal();
    }

    private void OrderListByNoteMoment(MusicSheet musicSheet)
    {
        musicSheet.notes.Sort((x, y) => x.moment.CompareTo(y.moment));
    }
}
#endif