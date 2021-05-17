using UnityEngine;

public class JSONReader : MonoBehaviour
{
    public TextAsset jsonFile;

    public string jsonString = "{\"bpm\":120,\"rows\":[{\"id\":1,\"moment\":0.2,\"notes\":[{\"position\":1,\"type\":1},{\"position\":2,\"type\":1}]},{\"id\":2,\"moment\":5,\"notes\":[{\"position\":3,\"type\":1},{\"position\":4,\"type\":1}]},{\"id\":3,\"moment\":10,\"notes\":[{\"position\":1,\"type\":1},{\"position\":3,\"type\":1}]},{\"id\":4,\"moment\":15,\"notes\":[{\"position\":4,\"type\":1},{\"position\":2,\"type\":1}]}]}";

    public static MusicSheet musicSheetInJson;

    void Start()
    {
        //Debug.Log("Found jsonFile: " + jsonString);

        musicSheetInJson = null;
        musicSheetInJson = JsonUtility.FromJson<MusicSheet>(jsonFile.text);

        //Debug.Log("Found Music Sheet: " + musicSheetInJson1.bpm + "bpm, " + musicSheetInJson1.rows[3].id + "rows");

        for (int i = 0; i < musicSheetInJson.rows.Length; i++)
        {
            //Debug.Log("Found ROW: id:" + musicSheetInJson1.rows[i].id + " moment:" + musicSheetInJson1.rows[i].moment);

            for (int j = 0; j < musicSheetInJson.rows[i].notes.Length; j++)
            {
                //Debug.Log("Found NOTE LENGHT: " + musicSheetInJson.rows[i].notes.Length);
                //Debug.Log("Found NOTE: position: " + musicSheetInJson.rows[i].notes[j].position + " type: " + musicSheetInJson.rows[i].notes[j].type);
            }
        }
    }
}