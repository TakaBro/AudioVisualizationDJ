using UnityEngine;

public class JSONReader : MonoBehaviour
{
    public static MusicSheet musicSheetInJson = new MusicSheet();

    void Start()
    {
        musicSheetInJson = JsonUtility.FromJson<MusicSheet>(LoadTextFromJsonFile("JsonFiles/" + NoteRecorderEditorWindow._jsonImportFileName));
        Debug.Log("Found Music Sheet: " + musicSheetInJson.bpm + " bpm");
    }

    public static string LoadTextFromJsonFile(string path)
    {
        return Resources.Load<TextAsset>(path).text;
    }
}