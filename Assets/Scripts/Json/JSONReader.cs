using UnityEngine;

public class JSONReader : MonoBehaviour
{
    [SerializeField]
    private string _jsonFileName = "MusicSheetFromNoteRecorder";

    //public string jsonString = "{\"bpm\":120,\"rows\":[{\"id\":1,\"moment\":0.2,\"notes\":[{\"position\":1,\"type\":1},{\"position\":2,\"type\":1}]},{\"id\":2,\"moment\":5,\"notes\":[{\"position\":3,\"type\":1},{\"position\":4,\"type\":1}]},{\"id\":3,\"moment\":10,\"notes\":[{\"position\":1,\"type\":1},{\"position\":3,\"type\":1}]},{\"id\":4,\"moment\":15,\"notes\":[{\"position\":4,\"type\":1},{\"position\":2,\"type\":1}]}]}";

    public static MusicSheet musicSheetInJson;

    private void Awake()
    {
        musicSheetInJson = null;
    }

    void Start()
    {
        //musicSheetInJson = JsonUtility.FromJson<MusicSheet>(jsonFile.text);
        musicSheetInJson = JsonUtility.FromJson<MusicSheet>(LoadTextFromJsonFile("JsonFiles/" + _jsonFileName));
        Debug.Log("Found Music Sheet: " + musicSheetInJson.bpm + " bpm");

        for (int i = 0; i < musicSheetInJson.notes.Count; i++)
        {
            //Debug.Log("Found NOTE: moment:" + musicSheetInJson.notes[i].moment + " position:" 
            //    + musicSheetInJson.notes[i].position + " type:" + musicSheetInJson.notes[i].type);
        }
    }

    public static string LoadTextFromJsonFile(string path)
    {
        return Resources.Load<TextAsset>(path).text;
    }
}