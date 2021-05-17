using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioInitValues", menuName = "ScriptableObjects/AudioInitValues", order = 1)]

public abstract class AudioValuesScriptableObject<T> : ScriptableObject where T: ScriptableObject
{
    [SerializeField]
    private static T _instance = null;
    public int sampleLenght;
    public static T GetInstance()
    {
        if (_instance == null)
        {
            _instance = Resources.FindObjectsOfTypeAll<T>().FirstOrDefault();
        }
        return _instance;
    }
}