using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    [Range(0f, 5f)]
    [SerializeField] private float _sampleSensibility;

    private float timer;
    private int _rowsIndex, _notesIndex;

    void Start()
    {
        _notesIndex = 0;
        timer = 0; 
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (_notesIndex < JSONReader.musicSheetInJson.notes.Count)
        {
            if (JSONReader.musicSheetInJson.notes[_notesIndex].moment <= timer/*GlobalTimer.instance.musicTimer*/)
            {
                Debug.Log("Found NOTE: moment: " + JSONReader.musicSheetInJson.notes[_notesIndex].moment+
                    "position: " + JSONReader.musicSheetInJson.notes[_notesIndex].position +
                    " type: " + JSONReader.musicSheetInJson.notes[_notesIndex].type);

                    switch (JSONReader.musicSheetInJson.notes[_notesIndex].position)
                    {
                        case 1:
                            GetFromPool("Note1");
                            break;
                        case 2:
                            GetFromPool("Note2");
                            break;
                        case 3:
                            GetFromPool("Note3");
                            break;
                        case 4:
                            GetFromPool("Note4");
                            break;
                        default:
                            break;
                    }
                _notesIndex++;
            }
        }

        // AUTO GENERATE NOTES FROM FREQUENCY
        /*if ((AudioPeer.samples[25] * _sampleSensibility) > 30)
        {
            InstatiateNotePrefab(_notePrefab1);
        }

        if ((AudioPeer.samples[22] * _sampleSensibility) > 40)
        {
            InstatiateNotePrefab(_notePrefab2);
        }

        if ((AudioPeer.samples[16] * _sampleSensibility) > 40)
        {
            InstatiateNotePrefab(_notePrefab3);
        }

        if ((AudioPeer.samples[3] * _sampleSensibility) > 105)
        {
            InstatiateNotePrefab(_notePrefab4);
        }*/

        // GENERATE NOTES FROM KEY PRESS
        /*switch (Input.inputString)
        {
            case "1":
                //InstatiateNotePrefab(_notePrefab1);
                GetFromPool("Note1");
                break;
            case "2":
                //InstatiateNotePrefab(_notePrefab2);
                GetFromPool("Note2");
                break;
            case "3":
                //InstatiateNotePrefab(_notePrefab3);
                GetFromPool("Note3");
                break;
            case "4":
                //InstatiateNotePrefab(_notePrefab4);
                GetFromPool("Note4");
                break;
            default:
                //Debug.Log(Input.inputString);
                break;
        }*/
    }

    private void InstatiateNotePrefab(GameObject notePrefab)
    {
        GameObject noteChildPrefab = Instantiate(notePrefab);
        noteChildPrefab.transform.SetParent(gameObject.transform);
        noteChildPrefab.GetComponent<RectTransform>().localPosition = new Vector3(0f, 7f, 0f);
        noteChildPrefab.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
    }

    private void GetFromPool(string tag)
    {
        GameObject b = Pool.Instance.Get(tag);
        if (b != null)
        {
            b.transform.SetParent(gameObject.transform);
            b.GetComponent<RectTransform>().localPosition = new Vector3(0f, 7f, 0f);
            b.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
            b.SetActive(true);
        }
    }
}
