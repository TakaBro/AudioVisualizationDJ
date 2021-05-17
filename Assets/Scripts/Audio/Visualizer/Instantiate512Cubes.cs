using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate512Cubes : MonoBehaviour
{
    [SerializeField] private GameObject _sampleCubePrefabLightBlue, _sampleCubePrefabBlue, _sampleCubePrefabPurple;
    [SerializeField] private GameObject[] _sampleCubes = new GameObject[64];
    public float _maxScale;
    void Start()
    {
        for(int i = 0; i < 64; i++)
        {
            GameObject _instanceSampleCube = InstantiateSampleCubePrefab(i);
            _instanceSampleCube.transform.position = this.transform.position;
            _instanceSampleCube.transform.eulerAngles = new Vector3(-30, 
                _instanceSampleCube.transform.eulerAngles.y, _instanceSampleCube.transform.eulerAngles.z);
            _instanceSampleCube.transform.parent = this.transform;
            _instanceSampleCube.name = "SampleCube" + i;
            this.transform.eulerAngles = new Vector3(-30, /*-5.625f*/ -8f * i, 0);
            _instanceSampleCube.transform.position = Vector3.forward * 80;
            _sampleCubes[i] = _instanceSampleCube;
        }
        this.transform.eulerAngles = new Vector3(-85.2f, 0, 0);
    }

    private GameObject InstantiateSampleCubePrefab(int i)
    {
        if (i <= 14)
        {
            return (GameObject)Instantiate(_sampleCubePrefabLightBlue);
        }
        else if (i > 14 && i <= 21)
        {
            return (GameObject)Instantiate(_sampleCubePrefabBlue);
        }
        else
        {
            return (GameObject)Instantiate(_sampleCubePrefabPurple);
        }
    }

    void Update()
    {
        for (int i = 0; i < 64; i++)
        {
            if(_sampleCubes != null)
            {
                if ( i == 0 || i == 1 || i == 2 || i == 3 || i == 4|| i == 5)
                {
                    _sampleCubes[i].transform.localScale = new Vector3(20, AudioPeer.samples[i] * 250 + 2, 10);
                }
                else
                {
                    _sampleCubes[i].transform.localScale = new Vector3(20, AudioPeer.samples[i] * 5000 + 2, 10);
                }
            }
        }
    }
}
