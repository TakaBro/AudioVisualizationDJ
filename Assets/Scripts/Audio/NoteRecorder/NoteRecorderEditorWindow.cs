﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Newtonsoft.Json;
using System.IO;

public class NoteRecorderEditorWindow : EditorWindow
{
    private Vector2 _scrollPos;
    private int _notesColumn = 4;
    private int _numberOfBars = 300;
    private float _bpm = 120;
    private float _barNotes = 16;
    private float _labelWidth = 50f;
    private float _labelHeight = 50f;
    private string _jsonFileName = "MusicSheetFromNoteRecorder.json";

    public static MusicSheet musicSheetRecorded = new MusicSheet();

    [MenuItem("Window/NoteRecorder")]
    static void Init()
    {
        NoteRecorderEditorWindow window = (NoteRecorderEditorWindow)GetWindow(typeof(NoteRecorderEditorWindow));
        window.Show();
    }

    private void OnEnable()
    {
        InstatitateListNote();
    }

    private void InstatitateListNote()
    {
        musicSheetRecorded.notes = new List<Note>();
        musicSheetRecorded.bpm = _bpm;
    }

    void OnGUI()
    {
        GUISkin skin = GUI.skin;

        EditorGUILayout.BeginVertical();
        _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));

        DrawBPMBarDurationFields();
        DrawRowLabels(skin);
        DrawAllNotesLines();
        DrawJsonFileName();
        DrawGenerateJsonButton();

        EditorGUILayout.EndScrollView();
        EditorGUILayout.EndVertical();
    }

    private void DrawSpace(GUISkin skin, float labelHeight, float labelWidth)
    {
        GUILayout.Button("", skin.label, GUILayout.ExpandWidth(false), GUILayout.MaxHeight(labelHeight), GUILayout.MaxWidth(labelWidth));
    }

    private void DrawBPMBarDurationFields()
    {
        GUILayout.BeginHorizontal();
        _bpm = EditorGUILayout.FloatField("BPM = ", _bpm);
        GUILayout.EndHorizontal();
        
        GUILayout.BeginHorizontal();
        _barNotes = EditorGUILayout.FloatField("1/X, X =", _barNotes);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        _numberOfBars = EditorGUILayout.IntField("Nº of Bars =", _numberOfBars);
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

    private void DrawAllNotesLines()
    {
        for (int i = ((int)(_notesColumn * _numberOfBars)); i >= 0; i--)
        {
            DrawNoteLine(CalculateBarExecutionTime(_bpm, _barNotes) * i,
            _labelHeight, _labelWidth, i);
        }
    }

    private float CalculateBarExecutionTime(float bpm, float barDivision)
    {
        return (bpm / 60) / barDivision;
    }

    private void DrawNoteLine(float timeInterval, float labelHeight, float labelWidth, int line)
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label(timeInterval.ToString(), GUILayout.ExpandWidth(false), GUILayout.MaxHeight(labelHeight), GUILayout.MaxWidth(labelWidth));
        for (int row = 1; row <= _notesColumn; row++)
        {

            if (GUILayout.Button(musicSheetRecorded.notes.Exists(note => note.moment == timeInterval && note.position == row) ? "X" : "", 
                GUILayout.ExpandWidth(false), GUILayout.MaxHeight(labelHeight), GUILayout.MaxWidth(labelWidth)))
            {
                if (musicSheetRecorded.notes.Exists(note => note.moment == timeInterval && note.position == row + 1))
                {
                    Debug.Log(" - Removed Note: [" + timeInterval + "][" + (row) + "]");
                    musicSheetRecorded.notes.RemoveAll(note => note.moment == timeInterval && note.position == row + 1);
                }
                else
                {
                    Debug.Log(" - Added Note: [" + timeInterval + "][" + (row) + "]");
                    musicSheetRecorded.notes.Add(new Note()
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

    private void DrawJsonFileName()
    {
        GUILayout.BeginHorizontal();
        _jsonFileName = EditorGUILayout.TextField("JSON File Name = ", _jsonFileName);
        GUILayout.EndHorizontal();
    }

    private void DrawGenerateJsonButton()
    {
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("GENERATE JSON", GUILayout.ExpandWidth(false)))
        {
            OrderListByNoteMoment(musicSheetRecorded);
            ExportFile(_jsonFileName, 
                        GenerateJsonString(musicSheetRecorded), 
                        Constants.NOTE_RECORDER_MUSIC_SHEET_JSON);
            Debug.Log("Json created");
        }
        GUILayout.EndHorizontal();
    }

    private void ExportFile(string fileName, string data, string path)
    {
        File.WriteAllText(Application.dataPath + path + "/" + fileName, data);
    }

    private string GenerateJsonString(MusicSheet fullSong)
    {
        return JsonConvert.SerializeObject(fullSong);
    }

    private void OrderListByNoteMoment(MusicSheet musicSheet)
    {
        musicSheet.notes.Sort((x, y) => x.moment.CompareTo(y.moment));
    }
}