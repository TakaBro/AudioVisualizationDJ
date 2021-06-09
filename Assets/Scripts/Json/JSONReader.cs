using UnityEngine;

public class JSONReader : MonoBehaviour
{
    public TextAsset jsonFile;

    //public string jsonString = "{\"bpm\":120,\"rows\":[{\"id\":1,\"moment\":0.2,\"notes\":[{\"position\":1,\"type\":1},{\"position\":2,\"type\":1}]},{\"id\":2,\"moment\":5,\"notes\":[{\"position\":3,\"type\":1},{\"position\":4,\"type\":1}]},{\"id\":3,\"moment\":10,\"notes\":[{\"position\":1,\"type\":1},{\"position\":3,\"type\":1}]},{\"id\":4,\"moment\":15,\"notes\":[{\"position\":4,\"type\":1},{\"position\":2,\"type\":1}]}]}";

    public static MusicSheet musicSheetInJson;

    void Start()
    {
        musicSheetInJson = null;
        musicSheetInJson = JsonUtility.FromJson<MusicSheet>(jsonFile.text);

        Debug.Log("Found Music Sheet: " + musicSheetInJson.bpm + " bpm, " + musicSheetInJson.notes[0].moment + " note.moment");

        for (int i = 0; i < musicSheetInJson.notes.Count; i++)
        {
            Debug.Log("Found NOTE: moment:" + musicSheetInJson.notes[i].moment + " position:" 
                + musicSheetInJson.notes[i].position + " type:" + musicSheetInJson.notes[i].type);

            /*for (int j = 0; j < musicSheetInJson.notes[i].notes.Length; j++)
            {
                //Debug.Log("Found NOTE LENGHT: " + musicSheetInJson.notes[i].notes.Length);
                //Debug.Log("Found NOTE: position: " + musicSheetInJson.notes[i].notes[j].position + " type: " + musicSheetInJson.notes[i].notes[j].type);
            }*/
        }
    }
}